using System.Reactive.Linq;using System.Reactive.Subjects;using Domain.Entities;using Domain.Repositories;namespace Data.Repositories;public class TimetablesRepository : SerializationRepository<Timetable>, ITimetablesRepository<Timetable>{    private static TimetablesRepository? _globalRepositoryInstance;    protected TimetablesRepository(string path) : base(path)    {    }    public static TimetablesRepository GetInstance()    {        return _globalRepositoryInstance ??= new TimetablesRepository("../../../../Data/DataSets/Timetable.json");    }    public void Delete(Timetable delEntity)    {        Remove(delEntity);    }    public void Add(Timetable newEntity)    {        Append(newEntity);    }    public List<Timetable> Read()    {        var disciplines = DeserializationJson();        return disciplines;    }    public List<string> GetDisciplines(string day, string classNumber)    {        var disciplines = new List<string>();        foreach (var t in DeserializationJson())        {            if (t.Day == day && t.ClassOne == classNumber)            {                disciplines.Add(t.DisciplineOne);                disciplines.Add(t.DisciplineTwo);                disciplines.Add(t.DisciplineThree);                disciplines.Add(t.DisciplineFour);                disciplines.Add(t.DisciplineFive);                disciplines.Add(t.DisciplineSix);            }        }        return disciplines;    }    public List<string> GetTeacher(string day, string classNumber)    {        var teachers = new List<string>();        foreach (var t in DeserializationJson())            if (t.Day == day && t.ClassOne == classNumber)            {                teachers.Add(t.TeacherOne);                teachers.Add(t.TeacherTwo);                teachers.Add(t.TeacherThree);                teachers.Add(t.TeacherFour);                teachers.Add(t.TeacherFive);                teachers.Add(t.TeacherSix);            }        return teachers;    }    public List<string> GetCabinet(string day, string classNumber)    {        var cabinets = new List<string>();        foreach (var t in DeserializationJson())            if (t.Day == day && t.ClassOne == classNumber)            {                cabinets.Add(t.CabinetOne);                cabinets.Add(t.CabinetTwo);                cabinets.Add(t.CabinetThree);                cabinets.Add(t.CabinetFour);                cabinets.Add(t.CabinetFive);                cabinets.Add(t.CabinetSix);            }        return cabinets;    }    public List<string> GetClass(string day, string classNumber)    {        var classes = new List<string>();        foreach (var t in DeserializationJson())            if (t.Day == day && t.ClassOne == classNumber)            {                classes.Add(t.ClassOne);                classes.Add(t.ClassTwo);                classes.Add(t.ClassThree);                classes.Add(t.ClassFour);                classes.Add(t.ClassFive);                classes.Add(t.ClassSix);            }        return classes;    }    public override bool CompareEntities(Timetable entity1, Timetable entity2)    {        return entity1.CabinetOne.Equals(entity2.CabinetOne)               && entity1.Day.Equals(entity2.Day)               && entity1.TeacherOne.Equals(entity2.TeacherOne);    }}