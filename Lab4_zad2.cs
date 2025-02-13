using System;
using System.Collections.Generic;
using System.Linq;

interface IOsoba
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string ZwrocPelnaNazwe();
}

abstract class Osoba : IOsoba
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }

    public void SetFirstName(string firstName) => FirstName = firstName;
    public void SetLastName(string lastName) => LastName = lastName;
    public void SetPesel(string pesel) => Pesel = pesel;

    public int GetAge()
    {
        int year = int.Parse(Pesel.Substring(0, 2));
        int month = int.Parse(Pesel.Substring(2, 2));
        year += (month > 12) ? 2000 : 1900;
        return DateTime.Now.Year - year;
    }

    public string GetGender()
    {
        int gender = int.Parse(Pesel.Substring(9, 1));
        return gender % 2 == 0 ? "Kobieta" : "Mężczyzna";
    }

    public abstract string GetEducationInfo();
    public abstract string GetFullName();
    public abstract bool CanGoAloneToHome();
    public string ZwrocPelnaNazwe() => GetFullName();
}

class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWracacDoDomu { get; set; }

    public void SetSchool(string school) => Szkola = school;
    public void ChangeSchool(string newSchool) => Szkola = newSchool;
    public void SetCanGoHomeAlone(bool decision) => MozeSamWracacDoDomu = decision;

    public override string GetEducationInfo() => $"Uczeń szkoły: {Szkola}";
    public override string GetFullName() => $"{FirstName} {LastName}";
    public override bool CanGoAloneToHome() => GetAge() >= 12 || MozeSamWracacDoDomu;
}

class Nauczyciel : Uczen
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

    public void AddStudent(Uczen student) => PodwladniUczniowie.Add(student);

    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
    {
        Console.WriteLine($"Lista uczniów, którzy mogą wracać sami do domu ({dateToCheck.ToShortDateString()}):");
        foreach (var student in PodwladniUczniowie)
        {
            if (student.CanGoAloneToHome())
            {
                Console.WriteLine(student.GetFullName());
            }
        }
    }
}

static class OsobaExtensions
{
    public static void WypiszOsoby(this List<IOsoba> osoby)
    {
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.ZwrocPelnaNazwe());
        }
    }

    public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
    {
        osoby.Sort((o1, o2) => o1.LastName.CompareTo(o2.LastName));
    }
}

interface IStudent : IOsoba
{
    string Uczelnia { get; set; }
    string Kierunek { get; set; }
    int Rok { get; set; }
    int Semestr { get; set; }
    string WypiszPelnaNazweIUczelnie();
}

class Student : Osoba, IStudent
{
    public string Uczelnia { get; set; }
    public string Kierunek { get; set; }
    public int Rok { get; set; }
    public int Semestr { get; set; }

    public override string GetEducationInfo() => $"Student {Uczelnia}, kierunek: {Kierunek}, rok: {Rok}, semestr: {Semestr}";
    public override string GetFullName() => $"{FirstName} {LastName}";
    public override bool CanGoAloneToHome() => true;
    public string WypiszPelnaNazweIUczelnie() => $"{GetFullName()} – {Kierunek} {Rok} {Uczelnia}";
}

class StudentWSIiZ : Student
{
    public StudentWSIiZ()
    {
        Uczelnia = "WSIiZ";
    }
}

class Program
{
    static void Main()
    {
        Nauczyciel teacher = new Nauczyciel() { FirstName = "Jan", LastName = "Nowak", TytulNaukowy = "mgr" };

        List<(string firstName, string lastName, string pesel)> uczniowie = new List<(string, string, string)>
        {
            ("Janina", "Nowak", "93081969382"),
            ("Adam", "Nowak", "76020316533"),
            ("Jan", "Nowakowski", "60080945835"),
            ("Magda", "Nowak", "68061686939"),
            ("Paulina", "Król", "79040788872")
        };

        foreach (var (firstName, lastName, pesel) in uczniowie)
        {
            Uczen student = new Uczen { FirstName = firstName, LastName = lastName, Pesel = pesel };
            student.SetCanGoHomeAlone(student.GetAge() >= 12);
            teacher.AddStudent(student);
        }

        teacher.WhichStudentCanGoHomeAlone(DateTime.Now);

        List<IOsoba> osoby = new List<IOsoba> { new StudentWSIiZ { FirstName = "Anna", LastName = "Kowalska", Kierunek = "Informatyka", Rok = 2, Semestr = 3 } };
        osoby.WypiszOsoby();
        osoby.PosortujOsobyPoNazwisku();
        osoby.WypiszOsoby();
    }
}
