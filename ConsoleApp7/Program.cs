using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] osvenyek = File.ReadAllLines("osvenyek.txt");
        int[] dobasok = File.ReadAllText("dobasok.txt")
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();

        Console.WriteLine("2. feladat");
        Console.WriteLine($"Az osvenyek.txt fajl {osvenyek.Length} osvenyt tartalmaz.");
        Console.WriteLine($"A dobasok.txt fajl {dobasok.Length} dobast tartalmaz.");

        Console.WriteLine("3. feladat");
        LegtobbMezo(osvenyek);
        Console.WriteLine(LegtobbMezoSorszam(osvenyek));

        Console.WriteLine("4. feladat");
        int osvenySzama = 0;
        int jatekosokSzama = 0;
        while (jatekosokSzama >= 2 || jatekosokSzama <= 5)
        {
            Console.WriteLine("Adja meg az osveny sorszamat:");
            jatekosokSzama = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg a jatekosok szamat:");
            osvenySzama = int.Parse(Console.ReadLine());

            break;
            
        }

        Console.WriteLine("5. feladat");
        Statisztika(osvenyek[osvenySzama - 1]);

        Console.WriteLine("6. feladat");
       // KiiroFajlba(osvenyek[osvenySzama - 1], "kulonleges.txt");

        Console.ReadKey();
    }

    static void LegtobbMezo(string[] osvenyek)
    {
        int legtobbMezo = osvenyek.Max(o => o.Count(c => c == 'M' || c == 'V' || c == 'E'));
        Console.WriteLine($"A legtobb mezot tartalmazo osvenyben : {legtobbMezo} mezo van.");
    }

    static string LegtobbMezoSorszam(string[] osvenyek)
    {
        int legtobbMezoIndex = Array.IndexOf(osvenyek, osvenyek.OrderByDescending(o => o.Count(c => c == 'M')).First());
        return $"Az osveny sorszama: {legtobbMezoIndex + 1}";
    }

    static void Statisztika(string osveny)
    {
        
        int mBetu = 0;
        int eBetu = 0;
        int vBetu = 0;
        foreach (char c in osveny)
        {
            if (c == 'M')
            {
                mBetu++;
            }
            if (c == 'E')
            {
                eBetu++;
            }
            if (c == 'V')
            {
                vBetu++;
            }
        }

        
        if (mBetu != 0)
        {
            Console.WriteLine($"M: {mBetu} db");
        }

        if (vBetu != 0)
        {
            Console.WriteLine($"V: {vBetu} db");
        }

        if (eBetu != 0)
        {
            Console.WriteLine($"E: {eBetu} db");
        }

    }

    /*static void KiiroFajlba(string osveny, string fajlNev)
    {
        
        using (StreamWriter writer = new StreamWriter(fajlNev))
        {
            for (int i = 0; i < osveny.Length; i++)
            {
                if (osveny[i] != 'M')
                {
                    writer.WriteLine($"{i + 1}\t{osveny[i]}");
                }
            }
        }
    }*/
}
