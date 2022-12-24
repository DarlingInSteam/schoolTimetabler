using System.Collections;using System.Reactive.Linq;using System.Reactive.Subjects;using System.Text.Encodings.Web;using System.Text.Json;using System.Text.Unicode;using Domain.Entities;namespace Data.Repositories;public abstract class SerializationRepository<T>{    private Stream? _fs;    private readonly string _path;    protected IObservable<List<T>> AsObservable { get; }    protected private BehaviorSubject<List<T>> EntitiesSubject { get; }    protected SerializationRepository(string path)    {        _path = path;        EntitiesSubject = new BehaviorSubject<List<T>>(new List<T>());        AsObservable = EntitiesSubject.AsObservable();    }    private void SerializationJson(List<T>? entities)    {        if (entities is null) return;        _fs = GetStream();        _fs.SetLength(0);        _fs.Flush();        JsonSerializer.SerializeAsync(_fs, entities, _options);        _fs.Close();        EntitiesSubject.OnNext(entities);    }    public abstract bool CompareEntities(T entity1, T entity2);    protected void Change(T changedEntity)    {        var newEntities = DeserializationJson();        var oldEntities = DeserializationJson();        foreach (var entity in oldEntities)        {            if (!CompareEntities(changedEntity, entity)) continue;            for (int i = 0; i < oldEntities.Count; i++)            {                if (CompareEntities(oldEntities[i], entity))                {                    newEntities.RemoveAt(i);                    break;                }            }            newEntities.Add(changedEntity);            SerializationJson(newEntities);            break;        }    }    private void SetOnNext(List<T> entities)    {        if (entities.Count != 0)        {            EntitiesSubject.OnNext(entities);        }    }    protected void Remove(T delitingEmtity)    {        var newEntities = DeserializationJson();        var oldEntities = DeserializationJson();        foreach (var entity in oldEntities)        {            if (!CompareEntities(delitingEmtity, entity)) continue;            for (int i = 0; i < oldEntities.Count; i++)            {                if (CompareEntities(oldEntities[i], delitingEmtity))                {                    newEntities.RemoveAt(i);                    break;                }            }            EntitiesSubject.OnNext(newEntities);            SerializationJson(newEntities);            break;        }    }    private readonly JsonSerializerOptions _options = new()    {        WriteIndented = true,        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)    };    protected void Append(T entity)    {        var newEntities = DeserializationJson();        newEntities.Add(entity);        SerializationJson(newEntities);    }    protected List<T> DeserializationJson()    {        List<T>? deserialized = null;        try        {            _fs = GetStream();            deserialized = JsonSerializer.Deserialize<List<T>>(_fs, _options);        }        catch (Exception)        {            // ignored        }        finally        {            _fs?.Close();            deserialized ??= new List<T>();        }        return deserialized;    }    private Stream GetStream() => new FileStream    (        _path,        FileMode.OpenOrCreate,        FileAccess.ReadWrite,        FileShare.ReadWrite,        4096,        FileOptions.None    );}