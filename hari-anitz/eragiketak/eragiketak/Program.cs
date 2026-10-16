using System;
using System.Threading;

class Hariak
{
    static int emaitza1 = 0;
    static int emaitza2 = 0;

    static void Main()
    {
        Thread t1 = new Thread(batu);
        Thread t2 = new Thread(biderkatu);
        Thread t3 = new Thread(batu);

        t1.Start(new int[] { 3, 5 });
        t2.Start(new int[] { 4, 6 });

        t1.Join();
        t2.Join();

        t3.Start(new int[] { emaitza1, emaitza2 });

        t3.Join();

        Console.WriteLine("Hariek bukatu dute.");
    }

    static void batu(object obj)
    {
        int[] zenbakiak = (int[])obj;
        int z1 = zenbakiak[0];
        int z2 = zenbakiak[1];

        int emaitza = z1 + z2;
        emaitza1 = emaitza;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Batuketa ({z1} + {z2}): {emaitza}");
            Thread.Sleep(300);
        }
    }

    static void biderkatu(object obj)
    {
        int[] zenbakiak = (int[])obj;
        int z1 = zenbakiak[0];
        int z2 = zenbakiak[1];

        int emaitza = z1 * z2;
        emaitza2 = emaitza;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Biderketa ({z1} * {z2}): {emaitza}");
            Thread.Sleep(1000);
        }
    }
}