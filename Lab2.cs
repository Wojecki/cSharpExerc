class Osoba
{
    private string imie;
    private string nazwisko;
    private int wiek;

    public string Imie
    {
        get { return imie; }
        set
        {
            if (value.Length >= 2)
            {
                imie = value;
            }
            else
            {
                Console.WriteLine("imię musi mieć wiecej niż 1 znak!");
            }
        }
    }
    public string Nazwisko
    {
        get { return nazwisko; }
        set
        {
            if (value.Length >= 2)
            {
                nazwisko = value;
            }
            else
            {
                Console.WriteLine("nazwisko musi mieć wiecej niż 1 znak!");
            }
        }
    }
    public int Wiek
    {
        get { return wiek; }
        set
        {
            if (value > 0)
            {
                wiek = value;
            }
            else
            {
                Console.WriteLine("Wiek musi być wiekszy niż 0");
            }
        }
    }
    public Osoba(string imie, string nazwisko, int wiek)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię:{Imie},\n Nazwisko:{Nazwisko},\nWiek: {Wiek} ");
    }

}

class usage
{
    static void Main()
    {
        Osoba Wojtek = new Osoba("Wojciech", "Nycz", 23);
        Wojtek.WyswietlInformacje();
    }
}
==============================================
class BankAccount
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
    }
    public string Wlasciciel
    {
        get;
        private set;
    }

    public BankAccount(string wlasciciel, decimal poczSaldo)
    {
        Wlasciciel = wlasciciel;
        saldo = poczSaldo;
    }

    public void Wplata(decimal kwota)
    {
        if (kwota <= 0)
        {
            Console.WriteLine("Kwota wpłaty musi być wieksza niż 0!");
        }
        else {
            saldo += kwota;
            Console.WriteLine($"Wpłacono: {kwota}, aktualne saldo: {saldo}");
        }
    }
    public void Wyplata(decimal kwota)
    {
        if (kwota <= 0)
        {
            Console.WriteLine("Kwota wypłaty musi być wieksza niż 0!");
        }
        else if (kwota > saldo) {

            Console.WriteLine($"Brak wystarczających środków na koncie.");
        }
        else
        {
            saldo -= kwota;
            Console.WriteLine($"Wypłącono: {kwota}, obecne saldo: {saldo}");
        }
    }
}

class usage
{
    static void Main()
    {
        BankAccount konto = new BankAccount("Jan Kowalski", 1000);
        konto.Wplata(500);
        konto.Wyplata(200);
        Console.WriteLine($"Saldo: {konto.Saldo}");
    }
}
==============================================
class Student
{
    private string imie;
    private string nazwisko;
    private List<int> oceny;


    public double SredniaOcen
    {
        get {
            if (oceny.Count == 0)
            {
                return 0;
            }
            else return oceny.Average();
        }
    }

    public Student(string imie, string nazwisko)
    {

        this.imie = imie;
        this.nazwisko = nazwisko;
        this.oceny = new List<int>();
    }

    public void DodajOcene(int ocena)
    {
        if (ocena < 2 || ocena > 5)
        {
            Console.WriteLine("Ocena musi być w zakresie od 2 do 5!");
        }
        else
        {
            oceny.Add(ocena);
            Console.WriteLine($"Dodano nową ocenę: {ocena}");
        }
    }

    public void GetInfo()
    {
        Console.WriteLine($"Student: {imie} {nazwisko}");
        Console.WriteLine($"Średnia ocen: {SredniaOcen:F2}");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Jan", "Kowalski");

        student.DodajOcene(5);
        student.DodajOcene(3);
        student.DodajOcene(4);

        student.GetInfo();
    }
}
==============================================
class Licz
{
    public int value;

    public void Dodaj(int liczba)
    {
        Console.WriteLine($"Do liczby {this.value} dodano {liczba}, nowa liczba to {this.value = this.value + liczba} ");
    }
    public void Odejmij(int liczba)
    { 
        Console.WriteLine($"Od liczby: {this.value} odjęto {liczba}, nowa liczba to {this.value = this.value - liczba} ");
    }
}
class Program
{
    static void Main()
    {
        Licz liczi = new Licz();
        liczi.Dodaj(3);
        liczi.Odejmij(2);
    }
}

using System;

class Sumator
{
    private float[] Liczby;

    public Sumator(float[] liczby)
    {
        this.Liczby = liczby;
    }

    public void Suma()
    {
        float sum = 0;
        foreach (float i in Liczby)
        {
            sum += i;
        }
        Console.WriteLine($"Suma: {sum}");
    }

    public void SumaPodziel2()
    {
        float sum = 0;
        foreach (float i in Liczby)
        {
            sum += (i / 2);
        }
        Console.WriteLine($"Suma podzielona przez 2: {sum}");
    }

    public int IleElementow()
    {
        return Liczby.Length;
    }

    public void WypiszElementy()
    {
        Console.WriteLine("Elementy tablicy:");
        foreach (float liczba in Liczby)
        {
            Console.Write(liczba + " ");
        }
        Console.WriteLine();
    }

    public void WypiszZakres(int firstI, int lastI)
    {
        Console.WriteLine($"Elementy w zakresie indeksów {firstI} - {lastI}:");
        for (int i = firstI; i <= lastI; i++)
        {
            if (i >= 0 && i < Liczby.Length) 
            {
                Console.Write(Liczby[i] + " ");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        float[] liczby = { 2, 4, 5, 3, 2, 1, 1 };
        Sumator sumator = new Sumator(liczby);

        sumator.Suma();
        sumator.SumaPodziel2();

        Console.WriteLine($"Liczba elementów: {sumator.IleElementow()}");

        sumator.WypiszElementy();
        sumator.WypiszZakres(2, 5);
        sumator.WypiszZakres(-1, 10);
    }
}
