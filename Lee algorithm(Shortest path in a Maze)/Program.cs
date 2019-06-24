using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeeAlgorithm
{
    class Program
    {
        public struct Locatie
        {
            public int Linie, Coloana;
        }
        public static List<Locatie> Lee(int[,] labirint, Locatie start, Locatie stop)
        {
            int n = labirint.GetLength(0);
            int m = labirint.GetLength(1);
            int[] dLinie = { 0, 0, 1, -1 };
            int[] dColoana = { 1, -1, 0, 0 };
            Queue<Locatie> coada = new Queue<Locatie>();
            coada.Enqueue(start);
            labirint[start.Linie, start.Coloana] = 1;
            while (coada.Count > 0)
            {
                Locatie curent = coada.Dequeue();
                for (int t = 0; t < dLinie.Length; t++)
                {
                    int linieVecin = curent.Linie + dLinie[t];
                    int coloanaVecin = curent.Coloana + dColoana[t];
                    if (linieVecin >= 0 && linieVecin < n && coloanaVecin >= 0 && coloanaVecin < m && labirint[linieVecin, coloanaVecin] == 0)
                    {
                        labirint[linieVecin, coloanaVecin] = labirint[curent.Linie, curent.Coloana] + 1;
                        coada.Enqueue(new Locatie() { Linie = linieVecin, Coloana = coloanaVecin });

                    }
                }
            }
        

            List<Locatie> drum = new List<Locatie>();
            int lungimeDrum = labirint[stop.Linie,stop.Coloana];//din matricea labirint ia numarul de pe pozitia indicata(fiind pozitia de stop)-daca numaratoareae din algoritmul de mai sus a ajuns in pozitia aceasta atunci ea trebuie sa contina numarul de pasi facuti pana la aceasta pozitie
            Console.WriteLine(lungimeDrum);
            int linie = stop.Linie;
            int coloana = stop.Coloana;
            while(!(linie==start.Linie && coloana==start.Coloana))
            {
                drum.Add(new Locatie() { Linie = linie, Coloana = coloana });
                /*drum.Add(new Locatie()
                {
                    Linie = linie,
                    Coloana = coloana
                });*/
                for (int i=0;i<dLinie.Length;i++)
                {
                    int linieVecin = linie + dLinie[i];
                    int coloanaVecin = coloana + dColoana[i];
                    if (linieVecin >= 0 && linieVecin < n && coloanaVecin >= 0 && coloanaVecin < m && labirint[linieVecin,coloanaVecin]==lungimeDrum-1)
                    {
                        linie = linieVecin;
                        coloana = coloanaVecin;
                        lungimeDrum--;
                        break;
                    }
                }
            }
            drum.Add(start);
            drum.Reverse();
            return drum;

        }
        static void Main(string[] args)
        {
            int[,] lab;
            int n, m;
            Locatie start, stop;
            List<Locatie> drum = new List<Locatie>();
            string[] s;
            StreamReader reader;
            reader = new StreamReader("date.txt");
            s = reader.ReadLine().Trim().Split(' ');
            n = int.Parse(s[0]);
            m = int.Parse(s[1]);
            Console.WriteLine(n + " " + m);
            lab = new int[n, m];
            for(int i=0;i<n;i++)
            {
                //string line = reader.ReadLine();
                //Console.WriteLine(line);
                Console.WriteLine();
                s = reader.ReadLine().Trim().Split(' ');
                for(int j=0;j<m;j++)
                {
                    lab[i, j] = int.Parse(s[j]);
                    Console.Write(lab[i, j] + " ");
                }
                
            }
            s = reader.ReadLine().Trim().Split(' ');
            start.Linie = int.Parse(s[0]);
            start.Coloana = int.Parse(s[1]);
            s = reader.ReadLine().Trim().Split(' ');
            stop.Linie = int.Parse(s[0]);
            stop.Coloana = int.Parse(s[1]);
            Console.WriteLine("\nStart:"+start.Linie+" "+start.Coloana);
            Console.WriteLine(" Stop:"+stop.Linie+" "+stop.Coloana);
            drum = Lee(lab, start, stop);
            Console.WriteLine("Lungimea drumului cel mai scurt este:"+drum.Count);
            foreach(Locatie p in drum)
            {
                Console.WriteLine(p.Linie+" "+p.Coloana);
            }

            //Console.WriteLine(lab[1, 2]);
            Console.ReadKey();



            /*string text = File.ReadAllText(@"date.txt");
            Console.WriteLine(text);
            Console.ReadKey();
            StreamReader reader;
            reader = new StreamReader("date.txt");
            try
            {
                int T = int.Parse(reader.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                
            }
            Console.ReadKey();*/
        }
    }
}
