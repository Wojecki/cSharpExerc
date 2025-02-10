using System;
using static System.Net.Mime.MediaTypeNames;

class Zad1
{
    static void Main()
    {
        Console.WriteLine("Podaj współczynniki a, b oraz c:");
        Console.WriteLine("a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("To nie jest równanie kwadratowe.");
            return;
        }

        double delta = b * b - 4 * a * c;
        Console.WriteLine($"Delta: {delta}");

        if (delta > 0)
        {
            double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Równanie ma dwa pierwiastki: x1 = {x1}, x2 = {x2}");
        }
        else if (delta == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Równanie ma jeden pierwiastek: x = {x}");
        }
        else
        {
            Console.WriteLine("Równanie nie ma pierwiastków rzeczywistych.");
        }
    }
}
class zad2
{
    public static void Main()
    {
        static void dodaj()
        {
            Console.WriteLine("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWynik to:" + a + b);
        }
        static void odejmij()
        {
            Console.WriteLine("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWynik to:" + (a - b));
        }
        static void mnoz()
        {
            Console.WriteLine("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWynik to:" + a * b);
        }
        static void dziel()
        {
            Console.WriteLine("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę: ");
            double b = Convert.ToDouble(Console.ReadLine());
            if (b == 0) { Console.WriteLine("Nie można dzielić przez zero!!"); }
            else { Console.WriteLine("\nWynik to:" + a / b); }
        }
        static void potega()
        {
            Console.WriteLine("Podaj pierwszą liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Podaj drugą liczbę: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWynik to:" + Math.Pow(a, b));
        }
        static void pierw()
        {
            Console.WriteLine("Podaj liczbę: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nWynik to:" + Math.Sqrt(a));
        }
        static void tryg()
        {
            Console.WriteLine("Podaj kąt: ");
            double a = Convert.ToDouble(Console.ReadLine());
            double sinValue = Math.Sin(a);
            double cosValue = Math.Cos(a);
            double tanValue = Math.Tan(a);
            double cotValue = 1.0 / tanValue;

            Console.WriteLine($"Sinus: {sinValue}");
            Console.WriteLine($"Cosinus: {cosValue}");
            Console.WriteLine($"Tangens: {tanValue}");
            Console.WriteLine($"Cotangens: {cotValue}");
        }
        int switch_on = 0;
        while (switch_on != 8)
        {

            Console.WriteLine("===========Kalkulator===========");
            Console.WriteLine("1. Dodawanie");
            Console.WriteLine("2. Odejmowanie");
            Console.WriteLine("3. Mnożenie");
            Console.WriteLine("4. Dzielenie");
            Console.WriteLine("5. Potęgowanie");
            Console.WriteLine("6. Pierwiastek");
            Console.WriteLine("7. Funkcje trygonometryczne");
            Console.WriteLine("8. Zamknij program");
            Console.WriteLine("================================");
            Console.WriteLine("Wybierz operacje: ");

            switch_on = Convert.ToInt32(Console.ReadLine());

            if (switch_on > 0 && switch_on < 9)
            {
                switch (switch_on)
                {
                    case 1:
                        dodaj();
                        break;
                    case 2:
                        odejmij();
                        break;
                    case 3:
                        mnoz();
                        break;
                    case 4:
                        dziel();
                        break;
                    case 5:
                        potega();
                        break;
                    case 6:
                        pierw();
                        break;
                    case 7:
                        tryg();
                        break;
                    case 8:
                        Environment.Exit(1);
                        break;
                }
            }
            else { Console.WriteLine("Nie ma operacji o takim numerze!"); }
        }
    }
}
class zad3
{
    static void Main()
    {
        double[] numbers = new double[10];
        do
        {
            Console.WriteLine("Podaj 10 liczb:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Liczba {i + 1}: ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("===========Menu===========");
            Console.WriteLine("1. Wyświetlanie tablicy od pierwszego do ostatniego indeksu");
            Console.WriteLine("2. Wyświetlanie tablicy od ostatniego do pierwszego indeksu");
            Console.WriteLine("3. Wyświetlanie elementów o nieparzystych indeksach");
            Console.WriteLine("4. Wyświetlanie elementów o parzystych indeksach");
            Console.WriteLine("5. Zamknij program");
            Console.WriteLine("==========================");
            Console.WriteLine("Wybierz operacje: ");
            int opt = Convert.ToInt32(Console.ReadLine());

            if (opt == 1)
            {
                Console.WriteLine("\nTablica od pierwszego do ostatniego indeksu:");
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            else if (opt == 2)
            {
                Console.WriteLine("\nTablica od ostatniego do pierwszego indeksu:");
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            else if (opt == 3)
            {
                Console.WriteLine("\nElementy o nieparzystych indeksach:");
                for (int i = 1; i < numbers.Length; i += 2)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            else if (opt == 4)
            {
                Console.WriteLine("\nElementy o parzystych indeksach:");
                for (int i = 0; i < numbers.Length; i += 2)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
            else if (opt == 5)
            {
                Environment.Exit(1);
            }
            else { Console.WriteLine("Nie ma takiej opcji!"); }


        } while (true);
    }
}
class zad4
{
    static void Main()
    {
        double[] numbers = new double[10];

        Console.WriteLine("Podaj 10 liczb:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            numbers[i] = Convert.ToDouble(Console.ReadLine());
        }

        double sum = 0, product = 1, min = numbers[0], max = numbers[0];
        foreach (double num in numbers)
        {
            sum += num;
            product *= num;
            if (num < min) min = num;
            if (num > max) max = num;
        }
        double average = sum / numbers.Length;

        Console.WriteLine("\nSuma elementów: " + sum);
        Console.WriteLine("Iloczyn elementów: " + product);
        Console.WriteLine("Średnia wartość: " + average);
        Console.WriteLine("Minimalna wartość: " + min);
        Console.WriteLine("Maksymalna wartość: " + max);
    }
}
class zad5
{
    static void Main()
    {
        for (int i = 20; i >= 0; i--)
        {
            if (i == 2 || i == 6 || i == 9 || i == 15 || i == 19)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}
class zad6
{
    static void Main()
    {
        while (true)
        {
            double a;
            Console.WriteLine("Podaj liczbę całkowitą:");
            a = Convert.ToDouble(Console.ReadLine());
            if (a < 0) { break; }
        }
    }
}
class zad7
{
    static void Main()
    {
        Console.Write("Podaj liczbę elementów do posortowania: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[] numbers = new double[n];

        Console.WriteLine("Podaj liczby:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Liczba {i + 1}: ");
            numbers[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    double temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("\nPosortowane liczby:");
        foreach (double num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
