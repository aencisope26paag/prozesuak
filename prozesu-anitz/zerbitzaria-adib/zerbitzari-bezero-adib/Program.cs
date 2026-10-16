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
                Console.ReadLine(); //---ReadLine gertatzen dena jakiteko

                //Zerbitzaria ireki, pipe bat sortu eta bezero baten zai jarri
                Console.WriteLine("Zerbitzaria irekita");
                var server = new NamedPipeServerStream("ZPP_1UDa_Pipe");

                Console.ReadLine(); //---ReadLine gertatzen dena jakiteko

                server.WaitForConnection();

                //Bezeroa konektatzean sarrera eta irterako PIPEak sortu.
                Console.WriteLine("Zerbitzaria konektatua");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                Console.WriteLine("Datuen zai");

                Console.ReadLine(); //---ReadLine gertatzen dena jakiteko

                var line = reader.ReadLine(); //Honek uzten du kodea mezua jasotzearen zai.
                Console.WriteLine("Jasotako datuak: {0}.", line);

                String erantzuna = "Jaso det mezua";
                writer.WriteLine("Emaitza: " + erantzuna);
                writer.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            Console.ReadLine(); //Bestela lehioa automatikoki isten da amaitzean.
        }


    }
}
