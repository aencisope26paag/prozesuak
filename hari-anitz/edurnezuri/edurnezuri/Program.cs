using System;
using System.Threading;
class Program
{

    static int aulkiLibreak = 4;
    static int zainIpotxak = 0;
    static object kandadoa = new object();

    static void Main(string[] args)
    {

        


        while (true)
        {
            Edurnezuri e = new Edurnezuri();





        }

        

    }




}

class Ipotx
{

}

class Edurnezuri
{
    private static int aulkiLibreak = 4;
    private object k1 = new object();
    private object k2 = new object();
    private object k3 = new object();
    private object k4 = new object();

    public void eseri()
    {
        Console.WriteLine("Ipotxaren jateko ordua da, ba al dago aulki librerik?");
        if (aulkiLibreak > 0)
        {
                Console.WriteLine("Badago aulki librea");
                aulkiLibreak -= 1;
                Console.WriteLine("Ipotxa eseri da");
                Thread.Sleep(2000);
                Console.WriteLine("Ipotxa lanera itzuli da");
                Thread.Sleep(1000);
                aulkiLibreak += 1;
        }
    }
}


