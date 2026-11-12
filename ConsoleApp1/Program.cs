using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
class Data
{
    public int DD;
    public int MM;
    public int RR;

    public Data(int dd, int mm, int rr)
    {
        if (mm >= 1 && mm <= 12)
        {
            MM = mm;
        }
        else
        {
            MM = 1;
        }
        if (MM == 1 || MM == 3 || MM == 5 || MM == 7 || MM == 8 || MM == 10 || MM == 12)
        {
            if (dd >= 1 && dd <= 31)
            {
                DD = dd;
            }
            else
            {
                DD = 1;
            }
        }
        else if (MM == 4 || MM == 6 || MM == 9 || MM == 11)
        {
            if (dd >= 1 && dd <= 30)
            {
                DD = dd;
            }
            else
            {
                DD = 1;
            }
        }
        else
        {
            if ((rr % 4 == 0 && rr % 100 != 0) || rr % 400 == 0)
            {
                if (dd >= 1 && dd <= 29)
                {
                    DD = dd;
                }
                else
                {
                    DD = 1;
                }
            }
            else
            {
                if (dd >= 1 && dd <= 28)
                {
                    DD = dd;
                }
                else
                {
                    DD = 1;
                }
            }
        }
        RR = rr;
    }
    public void Print()
    {
        Console.WriteLine($"DATA: {DD}-{MM}-{RR}");
    }
}
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
    public Data DataWypozycenia;
    public Wypozycenie(Film film, Klient klient, Data dataWypozycenia)
    {
        Film = film;
        Klient = klient;
        DataWypozycenia = dataWypozycenia;
    }
    public void Print()
    {
        Console.WriteLine($"FILM: {Film.Nazwa}");
        Console.WriteLine($"KLIENT: {Klient.Imie} {Klient.Nazwisko}");
        DataWypozycenia.Print();
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<");
    }
}
class Wypozycalnia
{
    public List<Film> flimy = new List<Film>();
    public List<Klient> klienci = new List<Klient>();
    public List<Wypozycenie> wypozycenia = new List<Wypozycenie>();

    private int idcf = 1;
    private int idck = 1;
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
    //Klient
    public void DodajKlienta()
    {
        string imie, nazwisko;
        Console.Write("[imie]: ");
        imie = Console.ReadLine();
        Console.Write("[nazwisko]: ");
        nazwisko = Console.ReadLine();
        klienci.Add(new Klient(idck, imie, nazwisko));
        idck++;
    }
    public void WyswietlKlientow()
    {
        foreach(Klient e in klienci)
        {
            e.Print();
        }
    }
    public Klient ZnajdzKlienta(int id)
    {
        foreach (Klient e in klienci)
        {
            if (e.Id == id)
            {
                return e;
            }
        }
        return null;
    }
    public bool UsunKlienta(int id)
    {
        Klient tmp = ZnajdzKlienta(id);
        if (tmp != null)
        {
            klienci.Remove(tmp);
            return true;
        }
        return false;
    }
    //Wypożyczenia
    public void WypozyczFilm(int idf, int idk)
    {
        Film tmpf = ZnajdzFlim(idf);
        if (tmpf == null || !tmpf.Dostepny)
        {
            Console.WriteLine("[BRAK FLIMU]");
            return;
        }
        Klient tmpk = ZnajdzKlienta(idk);
        if(tmpk == null)
        {
            Console.WriteLine("[BRAK KLIENTA]");
            return;
        }
        flimy[flimy.IndexOf(tmpf)].Dostepny = false;
        Console.WriteLine("Podaj datę");
        Console.Write("[dzień]: ");
        int dd = int.TryParse(Console.ReadLine(), out int x) ? x: 1;
        Console.Write("[miesiąc]: ");
        int mm = int.TryParse(Console.ReadLine(), out x) ? x : 1;
        Console.Write("[rok]: ");
        int rr = int.TryParse(Console.ReadLine(), out x) ? x : 2026;
        wypozycenia.Add(new Wypozycenie(tmpf, tmpk, new Data(dd, mm, rr)));
    }
    public void ZwrocFilm(int id)
    {
        Film tmp = ZnajdzFlim(id);

        if (tmp == null)
        {
            Console.WriteLine("[BRAK FILMU]");
            return;
        }

        if (tmp.Dostepny)
        {
            Console.WriteLine("Film nie został wypożyczony");
            return;
        }

        for (int i = 0; i < wypozycenia.Count; i++)
        {
            if (wypozycenia[i].Film.Id == id)
            {
                wypozycenia.RemoveAt(i);
                tmp.Dostepny = true;

                Console.WriteLine("Film został zwrócony");
                return;
            }
        }
    }
    public void PokazWypozyczenia()
    {
        foreach(Wypozycenie e in wypozycenia)
        {
            e.Print();
        }
    }

}
class Program
{
    static void Main()
    {
        bool dziala = true;
        Wypozycalnia wypozycalnia = new Wypozycalnia();
        while(dziala)
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("[1] Dodaj film");
            Console.WriteLine("[2] Wyświetl filmy");
            Console.WriteLine("[3] Edytuj film");
            Console.WriteLine("[4] Usuń film");
            Console.WriteLine("[5] Dodaj klienta");
            Console.WriteLine("[6] Wyświetl klientów");
            Console.WriteLine("[7] Usuń klienta");
            Console.WriteLine("[8] Wypożycz film");
            Console.WriteLine("[9] Zwróć film");
            Console.WriteLine("[10] Wyświetl wypożyczenia");
            Console.WriteLine("[0] Zakończ");
            Console.WriteLine("==========================");
            Console.Write("<USER>: ");
            int n = int.TryParse(Console.ReadLine(), out int x) ? x : 11;
            Console.Clear();
            switch(n)
            {
                case 1:
                    wypozycalnia.DodajFilm();
                    break;
                case 2:
                    wypozycalnia.PokazFlimy();
                    Console.ReadKey();
                    break;
                case 3:
                    {
                        Console.Write("[ID]: ");
                        int id = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        wypozycalnia.EdytujFilm(id);
                    }
                    break;
                case 4:
                    {
                        Console.Write("[ID]: ");
                        int id = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        if(!wypozycalnia.UsunFlim(id))
                        {
                            Console.WriteLine("[BRAK FILMU]");
                        }
                    }
                    break;
                case 5:
                    wypozycalnia.DodajKlienta();
                    break;
                case 6:
                    wypozycalnia.WyswietlKlientow();
                    Console.ReadLine();
                    break;
                case 7:
                    {
                        Console.Write("[ID]: ");
                        int id = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        if (!wypozycalnia.UsunKlienta(id))
                        {
                            Console.WriteLine("[BRAK FILMU]");
                        }
                    }
                    break;
                case 8:
                    {
                        Console.Write("[ID FLIMU]: ");
                        int idf = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        Console.Write("[ID KLIENTA]: ");
                        int idk = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        wypozycalnia.WypozyczFilm(idf, idk);
                    }
                    break;
                case 9:
                    {
                        Console.Write("[ID FLIMU]: ");
                        int idf = int.TryParse(Console.ReadLine(), out x) ? x : 0;
                        wypozycalnia.ZwrocFilm(idf);
                    }
                    break;
                case 10:
                    wypozycalnia.PokazWypozyczenia();
                    Console.ReadKey();
                    break;
                case 0:
                    dziala = false;
                    break;
                default:
                    Console.WriteLine("Brak takiej opcji");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
        }
    }
}