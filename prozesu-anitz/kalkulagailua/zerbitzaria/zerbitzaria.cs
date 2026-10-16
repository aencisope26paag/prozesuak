using System.IO.Pipes;

namespace pipeServer
{
    class Zerbitzaria
    {
        static void Main(String[] args)
        {
            Console.WriteLine("=====> ZERBITZARIA <=====");
            try
            {
                //Zerbitzaria ireki, pipe bat sortu eta bezero baten zai jarri
                Console.WriteLine("Zerbitzaria irekita");
                var server = new NamedPipeServerStream("kalkulagailua");

                server.WaitForConnection();

                //Bezeroa konektatzean sarrera eta irterako PIPEak sortu.
                Console.WriteLine("Zerbitzaria prest");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                Console.WriteLine("Kalkuluen zai");


                // kalkulagailua martxan
                while (true)
                {
                    var operazioa = reader.ReadLine();
                    if (operazioa == null) break;

                    var z1 = reader.ReadLine();
                    var z2 = reader.ReadLine();

                    int zenbaki1 = int.Parse(z1);
                    int zenbaki2 = int.Parse(z2);
                    double emaitza = 0;

                    switch (operazioa)
                    {
                        case "0":
                            emaitza = zenbaki1 + zenbaki2;
                            break;
                        case "1":
                            emaitza = zenbaki1 - zenbaki2;
                            break;
                        case "2":
                            emaitza = zenbaki1 * zenbaki2;
                            break;
                        case "3":
                            emaitza = zenbaki1 / zenbaki2;
                            break;
                        case "4":
                            emaitza = Math.Pow(zenbaki1, zenbaki2);
                            break;
                    }

                    writer.WriteLine(emaitza);
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Zerbitzaria itxi da.");
            Console.ReadLine();
        }
    }
}