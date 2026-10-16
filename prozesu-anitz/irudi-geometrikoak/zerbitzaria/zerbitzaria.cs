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
                var server = new NamedPipeServerStream("geometria");

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

                    double emaitza = 0;

                    switch (operazioa)
                    {
                        case "0": // ZIRKULUA
                            Console.WriteLine("\nZirkuluaren erradioa jasotzen...");
                            var r1 = reader.ReadLine();
                            int radio1 = int.Parse(r1);
                            emaitza = Math.PI * Math.Pow(radio1, 2);
                            Console.WriteLine($"Zirkuluaren azalera bidalita ({emaitza})");
                            break;
                        case "1": // TRIANGULUA
                            Console.WriteLine("\nTriangeluaren oinarria eta altuera jasotzen...");
                            var z1 = reader.ReadLine();
                            var z2 = reader.ReadLine();
                            int zenbaki1 = int.Parse(z1);
                            int zenbaki2 = int.Parse(z2);
                            emaitza = (zenbaki1 * zenbaki2) / 2.0;
                            Console.WriteLine($"Triangeluaren azalera bidalita ({emaitza})");
                            break;
                        case "2": // LAUKIZUZENA
                            Console.WriteLine("\nLaukizuzenaren luzera eta zabalera jasotzen...");
                            var z3 = reader.ReadLine();
                            var z4 = reader.ReadLine();
                            int zenbaki3 = int.Parse(z3);
                            int zenbaki4 = int.Parse(z4);
                            emaitza = zenbaki3 * zenbaki4;
                            Console.WriteLine($"Laukizuzenaren azalera bidalita ({emaitza})");
                            break;
                        case "3": // PENTAGONOA
                            Console.WriteLine("\nPentagonoaren aldea eta apotema jasotzen...");
                            var z5 = reader.ReadLine();
                            var z6 = reader.ReadLine();
                            int zenbaki5 = int.Parse(z5);
                            int zenbaki6 = int.Parse(z6);
                            emaitza = (5 * zenbaki5 * zenbaki6) / 2.0;
                            Console.WriteLine($"Pentagonoaren azalera bidalita ({emaitza})");
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
            //Console.ReadLine();
        }
    }
}