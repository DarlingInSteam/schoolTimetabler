namespace Data.Models;public class SchoolClass{    public SchoolClass(string number, string symbol, string classroom)    {        Number = number;        Symbol = symbol;        Classroom = classroom;    }    public string Number { get; set; }    public string Symbol { get; set; }    public string Classroom { get; set; }}