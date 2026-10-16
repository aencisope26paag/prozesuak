using System;
using System.Threading;


class Hariak
{
    static void Main()
    {
        Thread t1 = new Thread(aimar);
        Thread t2 = new Thread(nerea);
        Thread t3 = new Thread(jurgi);

        t1.Start();
        t2.Start();
        t3.Start(); 

        t1.Join();  
        t2.Join();  
        t3.Join();

        Console.WriteLine("Hariek bukatu dute.");
    }

    static void aimar()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Aimar");
            Thread.Sleep(300);
        }
    }

    static void nerea()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Nerea");
            Thread.Sleep(1000);
        }
    }

    static void jurgi()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Jurgi");
            Thread.Sleep(500);
        }
    }
}