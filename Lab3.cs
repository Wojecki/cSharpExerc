using System;
using System.Collections.Generic;

class Person
{
    private string firstName;
    private string lastName;
    private int wiek;

    public string FirstName => firstName;
    public string LastName => lastName;
    public int Wiek => wiek;

    public Person(string firstName, string lastName, int wiek)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.wiek = wiek;
    }

    public virtual void View()
    {
        Console.WriteLine($"Imię: {FirstName}, Nazwisko: {LastName}, Wiek: {Wiek}");
    }
}

class Book
{
    protected string title;
    protected Person author;
    protected string data;

    public string Title => title;
    public Person Author => author;
    public string Data => data;

    public Book(string title, Person author, string data)
    {
        this.title = title;
        this.author = author;
        this.data = data;
    }

    public virtual void View()
    {
        Console.WriteLine($"Tytuł: {Title}, Autor: {Author.FirstName} {Author.LastName}, Data: {Data}");
    }
}

class AdventureBook : Book
{
    private string location;

    public string Location => location;

    public AdventureBook(string title, Person author, string data, string location)
        : base(title, author, data)
    {
        this.location = location;
    }

    public override void View()
    {
        base.View();
        Console.WriteLine($"Miejsce akcji: {Location}");
    }
}

class DocumentaryBook : Book
{
    private string topic;

    public string Topic => topic;

    public DocumentaryBook(string title, Person author, string data, string topic)
        : base(title, author, data)
    {
        this.topic = topic;
    }

    public override void View()
    {
        base.View();
        Console.WriteLine($"Temat dokumentu: {Topic}");
    }
}

class Reader : Person
{
    private List<Book> readBooks;

    public Reader(string firstName, string lastName, int wiek)
        : base(firstName, lastName, wiek)
    {
        readBooks = new List<Book>();
    }

    public void AddBook(Book book)
    {
        readBooks.Add(book);
    }

    public List<Book> GetReadBooks()
    {
        return new List<Book>(readBooks);
    }

    public override void View()
    {
        base.View();
        ViewBooks();
    }

    protected void ViewBooks()
    {
        Console.WriteLine("Lista przeczytanych książek:");
        if (readBooks.Count == 0)
        {
            Console.WriteLine(" - Brak przeczytanych książek.");
        }
        else
        {
            foreach (var book in readBooks)
            {
                book.View();
            }
        }
    }
}

class Reviewer : Reader
{
    private Random random;

    public Reviewer(string firstName, string lastName, int wiek)
        : base(firstName, lastName, wiek)
    {
        random = new Random();
    }

    public override void View()
    {
        base.View();
        ViewBooksWithRatings();
    }

    private void ViewBooksWithRatings()
    {
        var books = GetReadBooks();
        Console.WriteLine("\nOceny książek:");
        if (books.Count == 0)
        {
            Console.WriteLine(" - Brak przeczytanych książek.");
        }
        else
        {
            foreach (var book in books)
            {
                int rating = random.Next(1, 11);
                book.View();
                Console.WriteLine($"Ocena: {rating}/10");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Person autor = new Person("Henryk", "Sienkiewicz", 76);

        Book ksiazka1 = new Book("Quo Vadis", autor, "1900");
        Book ksiazka2 = new AdventureBook("W pustyni i w puszczy", autor, "1905", "Afryka");
        Book ksiazka3 = new DocumentaryBook("Królestwa Zwierząt", autor, "1903", "Zoologia");

        List<Person> osoby = new List<Person>();

        Reader czytelnik = new Reader("Jan", "Kowalski", 30);
        czytelnik.AddBook(ksiazka1);

        Reviewer recenzent1 = new Reviewer("Anna", "Nowak", 28);
        recenzent1.AddBook(ksiazka2);
        recenzent1.AddBook(ksiazka3);

        Reviewer recenzent2 = new Reviewer("Michał", "Wiśniewski", 35);
        recenzent2.AddBook(ksiazka1);
        recenzent2.AddBook(ksiazka2);

        osoby.Add(czytelnik);
        osoby.Add(recenzent1);
        osoby.Add(recenzent2);

        Console.WriteLine("\n=== Lista osób i ich książek ===");
        foreach (Person osoba in osoby)
        {
            Console.WriteLine("\n-------------------------------");
            osoba.View();
        }
    }
}

using System;

class Samochod
{
    private string marka;
    private string model;
    private string nadwozie;
    private string kolor;
    private string rokProdukcji;
    private float przebieg;

    public string Marka => marka;
    public string Model => model;
    public string Nadwozie => nadwozie;
    public string Kolor => kolor;
    public string RokProdukcji => rokProdukcji;

    public float Przebieg
    {
        get { return przebieg; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Przebieg nie może być ujemny!");
            }
            else
            {
                przebieg = value;
            }
        }
    }
    public Samochod(string marka, string model, string nadwozie, string kolor, string rokProdukcji, float przebieg)
    {
        this.marka = marka;
        this.model = model;
        this.nadwozie = nadwozie;
        this.kolor = kolor;
        this.rokProdukcji = rokProdukcji;
        Przebieg = przebieg;
    }

    public Samochod()
    {
        Console.WriteLine("Podaj markę samochodu:");
        marka = Console.ReadLine();

        Console.WriteLine("Podaj model samochodu:");
        model = Console.ReadLine();

        Console.WriteLine("Podaj nadwozie samochodu:");
        nadwozie = Console.ReadLine();

        Console.WriteLine("Podaj kolor samochodu:");
        kolor = Console.ReadLine();

        Console.WriteLine("Podaj rok produkcji samochodu:");
        rokProdukcji = Console.ReadLine();

        Console.WriteLine("Podaj przebieg samochodu:");
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out przebieg) && przebieg >= 0)
                break;
            else
                Console.WriteLine("Przebieg nie może być ujemny! Podaj ponownie:");
        }
    }

    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"Marka: {Marka}, Model: {Model}, Nadwozie: {Nadwozie}, Kolor: {Kolor}, Rok produkcji: {RokProdukcji}, Przebieg: {Przebieg} km");
    }
}

class SamochodOsobowy : Samochod
{
    private float waga;
    private float pojemnoscSilnika;
    private int iloscOsob;

    public float Waga
    {
        get { return waga; }
        set
        {
            if (value < 2 || value > 4.5)
            {
                Console.WriteLine("Waga musi być z przedziału 2 t - 4,5 t!");
            }
            else
            {
                waga = value;
            }
        }
    }

    public float PojemnoscSilnika
    {
        get { return pojemnoscSilnika; }
        set
        {
            if (value < 0.8 || value > 3.0)
            {
                Console.WriteLine("Pojemność silnika musi być z przedziału 0,8 - 3,0!");
            }
            else
            {
                pojemnoscSilnika = value;
            }
        }
    }

    public int IloscOsob
    {
        get { return iloscOsob; }
        set { iloscOsob = value; }
    }
    public SamochodOsobowy(string marka, string model, string nadwozie, string kolor, string rokProdukcji, float przebieg,
                           float waga, float pojemnoscSilnika, int iloscOsob)
        : base(marka, model, nadwozie, kolor, rokProdukcji, przebieg)
    {
        Waga = waga;
        PojemnoscSilnika = pojemnoscSilnika;
        IloscOsob = iloscOsob;
    }

    public SamochodOsobowy() : base()
    {
        Console.WriteLine("Podaj wagę samochodu (z przedziału 2 - 4,5 t):");
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out waga) && waga >= 2 && waga <= 4.5)
                break;
            else
                Console.WriteLine("Waga musi być z przedziału 2 t - 4,5 t! Podaj ponownie:");
        }

        Console.WriteLine("Podaj pojemność silnika (z przedziału 0,8 - 3,0):");
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out pojemnoscSilnika) && pojemnoscSilnika >= 0.8 && pojemnoscSilnika <= 3.0)
                break;
            else
                Console.WriteLine("Pojemność silnika musi być z przedziału 0,8 - 3,0! Podaj ponownie:");
        }

        Console.WriteLine("Podaj ilość osób w samochodzie:");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out iloscOsob) && iloscOsob > 0)
                break;
            else
                Console.WriteLine("Ilość osób musi być liczbą dodatnią! Podaj ponownie:");
        }
    }

    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine($"Waga: {Waga} t, Pojemność silnika: {PojemnoscSilnika} l, Ilość osób: {IloscOsob}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Tworzenie samochodu osobowego:");
        SamochodOsobowy samochodOsobowy = new SamochodOsobowy();
        samochodOsobowy.WyswietlInformacje();

        Console.WriteLine("\nTworzenie samochodu osobowego z parametrami:");
        SamochodOsobowy samochodOsobowy2 = new SamochodOsobowy("Toyota", "Supra", "Coupe", "Czarny", "2021", 3231, 3.5f, 2.5f, 2);
        samochodOsobowy2.WyswietlInformacje();

        Console.WriteLine("\nTworzenie standardowego samochodu:");
        Samochod samochod = new Samochod("Subaru", "Impreza", "Sedan", "Niebieski", "2018", 60232);
        samochod.WyswietlInformacje();
    }
}
