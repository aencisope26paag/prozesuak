using System;
using System.Threading;

class Program
{
    public static readonly object kandadoa = new object();

    static void Main(string[] args)
    {
        // --------------  Talde gorria  --------------
        Jokalaria ander = new Jokalaria(true, "Ander");
        Jokalaria beñat = new Jokalaria(false, "Beñat");
        Jokalaria[] taldeGorria = { ander, beñat };

        // --------------  Talde urdina  --------------
        Jokalaria aimar = new Jokalaria(false, "Aimar");
        Jokalaria jokin = new Jokalaria(false, "Jokin");
        Jokalaria[] taldeUrdina = { aimar, jokin };

        ander.taldeAurkaria = taldeUrdina;
        beñat.taldeAurkaria = taldeUrdina;
        aimar.taldeAurkaria = taldeGorria;
        jokin.taldeAurkaria = taldeGorria;

        Thread tander = new Thread(ander.jolastu);
        Thread tbeñat = new Thread(beñat.jolastu);
        Thread taimar = new Thread(aimar.jolastu);
        Thread tjokin = new Thread(jokin.jolastu);

        tander.Start();
        tbeñat.Start();
        taimar.Start();
        tjokin.Start();
        
        tander.Join();
        tbeñat.Join();
        taimar.Join();
        tjokin.Join();
        
    }
}

class Jokalaria
{
    bool pilotaDauka;
    string izena;
    public Jokalaria[] taldeAurkaria;

    public Jokalaria(bool pilotaEgoera, string name)
    {
        pilotaDauka = pilotaEgoera;
        izena = name;
    }

    public void jolastu()
    {
        while (true)
        {
            lock (Program.kandadoa)
            {
                while (!pilotaDauka)
                {
                    Monitor.Wait(Program.kandadoa);
                }

                Thread.Sleep(1000);
                Console.WriteLine(izena + " pilotari jo dio");

                int randomZenb = Random.Shared.Next(0, 2);

                pilotaDauka = false;
                // talde bereko ez den bati "pasako" dio pilota
                taldeAurkaria[Random.Shared.Next(taldeAurkaria.Length)].pilotaDauka = true;

                Monitor.PulseAll(Program.kandadoa);
            }
        }
    }
}