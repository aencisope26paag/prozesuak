using System.Diagnostics;
using System.IO.Pipes;
using System.Security.Cryptography;

namespace pipe
{
    class Bezeroa
    {
        static void Main(String[] args)
        {
            Console.WriteLine("=====> KALKULAGAILU BEZEROA <=====");

            //Segundu bat itxaron Zerbitzariari hasteko denbora emateko,
            // pipea sortu (ZERBITZARIAREN IZEN BERBERA)
            // eta zerbitzarira konektatu

            Task.Delay(1000).Wait();

            var client = new NamedPipeClientStream("kalkulagailua");
            client.Connect();
            Console.WriteLine("Kalkulagailuaren zerbitzariarekin konektatuta");

            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            while (true)
            {

                var z1 = "0";
                var z2 = "0";
                var operazioa = "0";

                Console.WriteLine("\nKalkulagailua");
                Console.WriteLine("Operazioa: (-1 irteteko)");
                Console.WriteLine("> Batuketa (0)");
                Console.WriteLine("> Kenketa (1)");
                Console.WriteLine("> Biderketa (2)");
                Console.WriteLine("> Zatiketa (3)");
                Console.WriteLine("> Berreketa (4)");

                operazioa = Console.ReadLine();
                if (operazioa == "-1")
                {
                    break;
                }
                else if (operazioa == "0" || operazioa == "1" || operazioa == "2" || operazioa == "3" || operazioa == "4")
                {
                    Console.WriteLine("Eman lehen zenbakia:");
                    z1 = Console.ReadLine();
                    Console.WriteLine("Eman bigarren zenbakia:");
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
                        Console.WriteLine($"Zerbitzariaren erantzuna: {erantzuna}");
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