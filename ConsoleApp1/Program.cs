using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ismetles01
{
    class Program
    {
        static string[] lehetoseg = new string[] { "Kő", "Papír", "Olló" };
        static int gepNyer = 0;
        static int jatekosNyer = 0;
        static int menet = 0;

        static int GepValasztas()
        {
            Random vel = new Random();
            return vel.Next(0, 3);
        }
        static int JatekosValasztas()
        {
            Console.WriteLine("Kő (0), Papír (1), Olló (2)");
            Console.Write("Válasz: ");
            return Convert.ToInt32(Console.ReadLine());

        }
        static void EredmenyKiiras(int gep, int ember)
        {
            Console.WriteLine("Gép: {0} --- Játékos: {1}", lehetoseg[gep], lehetoseg[ember]);
            switch (EmberNyer(gep, ember))
            {
                case 0:
                    Console.WriteLine("Döntetlen!");
                    break;
                case 1:
                    Console.WriteLine("Skynet nyert!");
                    break;
                case 2:
                    Console.WriteLine("Játékos nyert!");
                    break;
            }
        }
        static int EmberNyer(int gep, int ember)
        {
            if (gep == 0 && ember == 1 || gep == 1 && ember == 2 || gep == 2 && ember == 0)
            {
                jatekosNyer++;
                return 2;
                
            }
            else if (gep == ember)
            {
                return 0;
            }
            
            else gepNyer++;
            return 1;
            
                
            
            

        }

        private static bool akarJatszani()
        {
            Console.WriteLine("-----");
            Console.Write("Igen/nem:");
            string valasz = Console.ReadLine().ToLower();
            Console.WriteLine("\n---------");
            if (valasz == "i")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static void statisztika()
        {
            Console.WriteLine("\t Menetek száma: {0}"+
                "Játékos győzelmek {1}"+
                "Gép győzelem {2}",menet,jatekosNyer,gepNyer);

            StreamWriter sw = new StreamWriter("Statisztika.txt");
            sw.WriteLine(menet+";");
            sw.WriteLine(jatekosNyer + ";");
            sw.WriteLine(gepNyer + ";");


        }

         private static void statisztikafajlbol()
        {
            StreamReader sr = new StreamReader("Statisztika.txt");
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                int[] adat = new int[3];
                //adat[0] = int.Parse(sor[0]);
                //adat[1] = int.Parse(sor[1]);
                //adat[2] = int.Parse(sor[2]);

                for (int i = 0; i < adat.Length; i++)
                {
                    adat[i] = int.Parse(sor[i]);
                }
                Console.WriteLine("{0} {1} {2}",adat[0],adat[1],adat[2]);

            }
            Console.WriteLine("Statisztika vége");
            sr.Close();
        }


        

    static void Main(string[] args)   
        {
            statisztikafajlbol();
            bool tovabb = true;
            while (tovabb)
            {
             menet++;
            int jatekosValasz = JatekosValasztas();
            int gepValasz = GepValasztas();
            EredmenyKiiras(gepValasz, jatekosValasz);
                tovabb = akarJatszani();
            }

            
            Console.ReadKey();

            
        }
        
}
}
