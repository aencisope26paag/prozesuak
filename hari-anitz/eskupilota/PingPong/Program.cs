using System;
using System.Threading;

class Program
{
    public static readonly object kandadoa = new object();

    static void Main(string[] args)
    {
        Jokalaria ander = new Jokalaria(true, "Ander");
        Jokalaria oier = new Jokalaria(false, "Oier");
        ander.aurkaria = oier;
        oier.aurkaria = ander;

        Thread tander = new Thread(ander.jolastu);
        Thread toier = new Thread(oier.jolastu);

        tander.Start();
        toier.Start();

        tander.Join();
        toier.Join();
    }
}

class Jokalaria
{
    bool pilotaDauka;
    string izena;
    public Jokalaria aurkaria;

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
                while (!this.pilotaDauka)
                {
                    Console.WriteLine(this.izena + " zai dago");
                    Monitor.Wait(Program.kandadoa);
                }

                Thread.Sleep(1000);
                Console.WriteLine(this.izena + " pilotari jo dio");

                this.pilotaDauka = false;
                aurkaria.pilotaDauka = true;

                Monitor.PulseAll(Program.kandadoa);
            }
        }
    }
}