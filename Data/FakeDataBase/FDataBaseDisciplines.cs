using Data.Models;namespace Data.FakeDataBase;public class FDataBaseDisciplines{    private readonly List<SchoolDiscipline> _schoolDisciplines;    public IEnumerable<SchoolDiscipline> SchoolDisciplines { get; set; }    private FDataBaseDisciplines()    {        _schoolDisciplines = new List<SchoolDiscipline>();        SchoolDisciplines = _schoolDisciplines;    }        public void AddClass(SchoolDiscipline schoolDiscipline)    {        _schoolDisciplines.Add(schoolDiscipline);        SchoolDisciplines = _schoolDisciplines;    }    public static FDataBaseDisciplines GetInstance()    {        return _instance ??= new FDataBaseDisciplines();    }    private static FDataBaseDisciplines? _instance = null;}