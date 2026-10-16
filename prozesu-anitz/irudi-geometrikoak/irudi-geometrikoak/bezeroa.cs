using System.Diagnostics;
using System.IO.Pipes;
using System.Security.Cryptography;

namespace pipe
{
    class Bezeroa
    {
        static void Main(String[] args)
        {
            Console.WriteLine("=====> GEOMETRIA BEZEROA <=====");

            //Segundu bat itxaron Zerbitzariari hasteko denbora emateko,
            // pipea sortu (ZERBITZARIAREN IZEN BERBERA)
            // eta zerbitzarira konektatu

            Task.Delay(1000).Wait();

            var client = new NamedPipeClientStream("geometria");
            client.Connect();
            Console.WriteLine("Kalkulagailuaren zerbitzariarekin konektatuta");

            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {

                var z1 = "0";
                var z2 = "0";
                var operazioa = "0";

                Console.WriteLine("\nIrudi geometrikoak");
                Console.WriteLine("Operazioa: (-1 irteteko)");
                Console.WriteLine("> Zirkulu (0)");
                Console.WriteLine("> Triangelu (1)");
                Console.WriteLine("> laukizuzen (2)");
                Console.WriteLine("> Pentagono (3)");

                operazioa = Console.ReadLine();
                if (operazioa == "-1")
                {
                    break;
                }
                else if (operazioa == "0") // ZIRKULUA
                {
                    Console.WriteLine("Eman zirkuluaren erradioa:");
                    z1 = Console.ReadLine();

                    if (z1 == "")
                    {
                        Console.WriteLine("Zenbakia ezin da hutsik egon. Saiatu berriro.");
                    }
                    else
                    {
                        Console.WriteLine("Operazioa prozesatzen...");
                        String[] mezu = { operazioa, z1 };
                        foreach (String zenbaki in mezu)
                        {
                            writer.WriteLine(zenbaki);
                        }
                        writer.Flush();
                        var erantzuna = reader.ReadLine();
                        Console.WriteLine($"Zirkuluaren azalera: {erantzuna}");
                    }
                }
                else if (operazioa == "1") // TRIANGELUA 
                {
                    Console.WriteLine("Eman triangeluaren oinarria:");
                    z1 = Console.ReadLine();
                    Console.WriteLine("Eman triangeluaren altuera:");
                    z2 = Console.ReadLine();

                    if (z1 == "" || z2 == "")
                    {
                        Console.WriteLine("Zenbakiak ezin dira hutsik egon. Saiatu berriro.");
                    }
                    else
                    {
                        Console.WriteLine("Operazioa prozesatzen...");

                        String[] mezu = { operazioa, z1, z2 };
                        foreach (String zenbaki in mezu)
                        {
                            writer.WriteLine(zenbaki);
                        }
                        writer.Flush();

                        var erantzuna = reader.ReadLine();
                        Console.WriteLine($"Triangeluaren azalera: {erantzuna}");
                    }
                }
                else if (operazioa == "2") // LAUKIZUZENA
                {
                    Console.WriteLine("Eman laukizuzenaren luzera:");
                    z1 = Console.ReadLine();
                    Console.WriteLine("Eman laukizuzenaren zabalera:");
                    z2 = Console.ReadLine();

                    if (z1 == "" || z2 == "")
                    {
                        Console.WriteLine("Zenbakiak ezin dira hutsik egon. Saiatu berriro.");
                    }
                    else
                    {
                        Console.WriteLine("Operazioa prozesatzen...");
                        String[] mezu = { operazioa, z1, z2 };
                        foreach (String zenbaki in mezu)
                        {
                            writer.WriteLine(zenbaki);
                        }
                        writer.Flush();
                        var erantzuna = reader.ReadLine();
                        Console.WriteLine($"Laukizuzenaren azalera: {erantzuna}");
                    }
                }
                else if (operazioa == "3") // PENTAGONOA
                {
                    Console.WriteLine("Eman pentagonoaren aldearen luzera:");
                    z1 = Console.ReadLine();
                    Console.WriteLine("Eman pentagonoaren apotema:");
                    z2 = Console.ReadLine();

                    if (z1 == "" || z2 == "")
                    {
                        Console.WriteLine("Zenbakiak ezin dira hutsik egon. Saiatu berriro.");
                    }
                    else
                    {
                        Console.WriteLine("Operazioa prozesatzen...");
                        String[] mezu = { operazioa, z1, z2 };
                        foreach (String zenbaki in mezu)
                        {
                            writer.WriteLine(zenbaki);
                        }
                        writer.Flush();
                        var erantzuna = reader.ReadLine();
                        Console.WriteLine($"Pentagonoaren azalera: {erantzuna}");
                    }
                }
                else
                {
                    Console.WriteLine("\nOperazio okerra. Saiatu berriro.");

                }
            }
        }
    }
}