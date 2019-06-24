using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadFirstSearch
{
    class Program
    {
        public static int prim;
        public static int ultim;
        public static int comp;
        public static int[] vizitat;
        public static int gr = 0;
        public static int ind;

        public static int exista_nod_nevizitat(int[] v)
        {
            int n = vizitat.Length;
            for (int i = 0; i < n; i++)
            {
                if (v[i] == 0)
                    return i;
            }
            return 0;

        }

        public static void ComponenteConvexe(int[,] a, int n)
        {
            Array.Clear(vizitat, 0, n);
            bool nodnevizitat = true;
            int compCon = 0;
            while (nodnevizitat)
            {
                nodnevizitat = false;
                for (int i = 0; i < n; i++)
                {
                    if (vizitat[i] == 0)
                    {
                        ind = 0;
                        nodnevizitat = true;
                        compCon = compCon + 1;
                        DF(a, i, compCon);
                    }
                }
            }
        }
        public static List<int> BF(int[,] a, int start)
        {
            List<int> ordineBF = new List<int>();
            int n = a.GetLength(0);
            int[] vizitat = new int[n];
            Array.Clear(vizitat, 0, n);
            Queue<int> coada = new Queue<int>();
            coada.Enqueue(start);
            vizitat[start] = 1;

            while (coada.Count > 0)
            {
                int curent = coada.Dequeue();
                ordineBF.Add(curent);
                for (int i = 0; i < n; i++)
                {
                    if (a[curent, i] == 1 && vizitat[i] == 0)
                    {
                        coada.Enqueue(i);
                        vizitat[i] = 1;
                    }
                }
            }
            return ordineBF;
        }
        public static void DF(int[,] a, int start, int c)
        {
            int n = a.GetLength(0);
            vizitat[start] = c;
            Console.Write(start + " ");
            for (int i = 0; i < n - 1; i++)
            {
                if (a[start, i] == 1 && vizitat[i] == 0)
                {
                    ind++;
                    DF(a, i, c);
                    gr = ind;
                }
            }
        }
        static void Main(string[] args)
        {
            List<int> drum = new List<int>();
            StreamReader reader = new StreamReader("input.txt");
            StreamWriter writer = new StreamWriter("output.txt");
            int n, m;
            int start;

            string[] elem;
            elem = reader.ReadLine().Trim().Split(' ');
            n = int.Parse(elem[0]);
            m = int.Parse(elem[1]);
            int[,] date = new int[n, n];
            vizitat = new int[n];
            //grafuri = new int[n];
            Console.WriteLine(n + " " + m);
            for (int i = 0; i < n; i++)
            {
                //elem = reader.ReadLine().Trim().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    date[i, j] = 0;
                }
            }
            for (int i = 0; i < m; i++)
            {
                int nod1, nod2;
                elem = reader.ReadLine().Trim().Split(' ');
                nod1 = int.Parse(elem[0]);
                nod2 = int.Parse(elem[1]);
                Console.WriteLine(nod1 + " " + nod2);
                date[nod1, nod2] = 1;
                date[nod2, nod1] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                {
                    Console.Write(date[i, j] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Nodurile accesebile folosind BF:");
            ComponenteConvexe(date, n);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
