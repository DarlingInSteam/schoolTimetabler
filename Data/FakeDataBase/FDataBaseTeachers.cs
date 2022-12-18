using System.Collections.ObjectModel;using Data.Models;namespace Data.FakeDataBase;public class FDataBaseTeachers{    private readonly List<SchoolTeachers> _schoolTeachers;    public IEnumerable<SchoolTeachers> SchoolTeachers { get; private set; }    private FDataBaseTeachers()    {        _schoolTeachers = new List<SchoolTeachers>();        SchoolTeachers = _schoolTeachers;    }    public void AddTeacher(SchoolTeachers schoolTeachers)    {        _schoolTeachers.Add(schoolTeachers);        SchoolTeachers = _schoolTeachers;    }    public void DeleteDiscipline(int index)    {        _schoolTeachers.Remove(_schoolTeachers[index]);        SchoolTeachers = _schoolTeachers;    }    public ObservableCollection<string> GetTeacherDiscipline(int index)    {        var buf = new ObservableCollection<string>();        foreach (var t in _schoolTeachers[index].TeacherDisciplines)        {            buf.Add(t);        }        return buf;    }    public void AddDiscipline(List<string> str, int index)    {        //_schoolTeachers[index].TeacherDisciplines = str;        _schoolTeachers[index].TeacherDisciplines = new List<string>();        foreach (var t in str)        {            _schoolTeachers[index].TeacherDisciplines.Add(t);        }        SchoolTeachers = _schoolTeachers;    }    public static FDataBaseTeachers GetInstance()    {        return _instance ??= new FDataBaseTeachers();    }    private static FDataBaseTeachers? _instance = null;}