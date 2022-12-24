using System.Reactive.Linq;using System.Reactive.Subjects;using Domain.Entities;using Domain.Repositories;namespace Data.Repositories;public class CabinetsRepository : SerializationRepository<Cabinet>, ICabinetsRepository<Cabinet>{    protected IObservable<IEnumerable<Cabinet>> Cabinets;    private readonly BehaviorSubject<List<Cabinet>> _cabinets;    private static CabinetsRepository? _globalRepositoryInstance;    protected CabinetsRepository(string path) : base(path)    {        _cabinets = new BehaviorSubject<List<Cabinet>>(new List<Cabinet>());        Cabinets = _cabinets.AsObservable();        path = "/home/darling/RiderProjects/Avalonia.schoolTimetabler/Data/DataSets/Cabinets.json";    }    public static CabinetsRepository GetInstance()    {        return _globalRepositoryInstance ??=            new CabinetsRepository("/home/darling/RiderProjects/Avalonia.schoolTimetabler/Data/DataSets/Cabinets.json");    }    public void Delete(Cabinet delCabinet)    {        Remove(delCabinet);    }    public void Add(Cabinet newCabinet)    {        Append(newCabinet);    }    public List<Cabinet> Read()    {        return DeserializationJson();    }    public override bool CompareEntities(Cabinet entity1, Cabinet entity2)    {        return entity1.CabinetNumber == entity2.CabinetNumber;    }}