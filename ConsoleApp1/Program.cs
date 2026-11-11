using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
class Film
{
    public int Id;
    public string Nazwa;
    public string Gatunek;
    public int RokProdukcji;
    public bool Dostepny = true;

    public Film(int id, string nazwa, string gatunek, int rokProdukcji)
    {
        Id = id;
        Nazwa = nazwa;
        Gatunek = gatunek;
        RokProdukcji = rokProdukcji;
    }
    public void Print()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"NAZWA: {Nazwa}");
        Console.WriteLine($"GATUNEK: {Gatunek}");
        Console.WriteLine($"ROK PRODUKCJI: {RokProdukcji}");
        if (Dostepny)
        {
            Console.WriteLine("Film dostępny w asortymencie");
        }
        else
        {
            Console.WriteLine("Brak filmu w asortymencie");
        }
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<");
    }
}
class Klient
{
    public int Id;
    public string Imie;
    public string Nazwisko;

    public Klient(int id, string imie, string nazwisko)
    {
        Id = id;
        Imie = imie;
        Nazwisko = nazwisko;
    }
    public void Print()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"IMIE: {Imie}");
        Console.WriteLine($"NAZWISKO: {Nazwisko}");
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<");
    }
}
class Wypozycenie
{
    public Film Film;
    public Klient Klient;
    public string DataWypozycenia;
    public Wypozycenie(Film film, Klient klient, string dataWypozycenia)
    {
        Film = film;
        Klient = klient;
        DataWypozycenia = dataWypozycenia;
    }
    public void Print()
    {
        Console.WriteLine($"FILM: {Film.Nazwa}");
        Console.WriteLine($"KLIENT: {Klient.Imie} {Klient.Nazwisko}");
        Console.WriteLine($"DATA: {DataWypozycenia}");
    }
}
class Wypozycalnia
{
    public List<Film> flimy = new List<Film>();
    public List<Klient> klienci = new List<Klient>();
    public List<Wypozycenie> wypozycenia = new List<Wypozycenie>();

    private int idcf = 1;
    //Flim
    public void DodajFilm()
    {
        string nazwa, gatunek;
        int rok;
        Console.Write("[nazwa]: ");
        nazwa = Console.ReadLine();
        Console.Write("[gatunek]: ");
        gatunek = Console.ReadLine();
        Console.Write("[rok produkcji]: ");
        rok = int.TryParse(Console.ReadLine(), out int x) ? x : 2026;
        flimy.Add(new Film(idcf, nazwa, gatunek, rok));
        idcf++;
    }
    public void PokazFlimy()
    {
        foreach (Film e in flimy)
        {
            e.Print();
        }
    }
    public Film ZnajdzFlim(int id)
    {
        foreach(Film e in flimy)
        {
            if(e.Id == id)
            {
                return e;
            }
        }
        return null;
    }
    public void EdytujFilm(int id)
    {
        Film tmp = ZnajdzFlim(id);
        if(tmp !=  null)
        {
            string nazwa, gatunek;
            int rok;
            Console.Write("[nazwa]: ");
            nazwa = Console.ReadLine();
            Console.Write("[gatunek]: ");
            gatunek = Console.ReadLine();
            Console.Write("[rok produkcji]: ");
            rok = int.TryParse(Console.ReadLine(), out int x) ? x : 2026;
            flimy.Add(new Film(idcf, nazwa, gatunek, rok));
            for (int i = 0; i < flimy.Count; i++)
            {
                if(flimy[i].Id == id)
                {
                    flimy[i] = tmp;
                    break;
                }
            }
        }
    }
    public bool UsunFlim(int id)
    {
        Film tmp = ZnajdzFlim(id);
        if(tmp != null)
        {
            flimy.Remove(tmp);
            return true;
        }
        return false;
    }

}
class Program
{
    static void Main()
    {

        Console.ReadKey();
    }
}