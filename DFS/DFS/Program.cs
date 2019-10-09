using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] labirint = CreateLabirint();
            PrintLabirint(labirint);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Graph graph = new Graph();
            Verterx input = new Verterx(0,9);
            Verterx output = new Verterx(15, 9);
            graph = DFS(labirint, graph, input, output);


        }

        static int[,] CreateLabirint()
        {
            int[,] labirint = {  { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                                 { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};
                               
            return labirint;
                                    
        }

        static Graph DFS (int[,] labirint, Graph graph, Verterx input, Verterx output)
        {
            //Dictionary<int, string> countries = new Dictionary<int, string>(5)
            int i = input.Y + 1;
            int j = input.X;
            graph.Get().Add(input);

            for (; ;)
            {
                if(output.X == j && output.Y == i)
                {
                    Console.WriteLine("Output Findet");
                    break;
                }
                else if (labirint[i + 1, j] == 0 && !graph.Get().Contains(new Verterx(i + 1, j)))
                {
                    graph.Get().Add(new Verterx(i + 1, j));
                    i++;
                    Console.Write("[" + i + ", " + j + "]" );
                    continue;
                }
                else if (labirint[i, j - 1] == 0 && !graph.Get().Contains(new Verterx(i, j - 1)))
                {
                    graph.Get().Add(new Verterx(i, j - 1));
                    j--;
                    Console.Write("[" + i + ", " + j + "]");
                    continue;
                }
                else if (labirint[i, j + 1] == 0 && !graph.Get().Contains(new Verterx(i, j + 1)))
                {
                    graph.Get().Add(new Verterx(i, j + 1));
                    j++;
                    Console.Write("[" + i + ", " + j + "]");
                    continue;
                }
                else if (labirint[i - 1, j] == 0 && !graph.Get().Contains(new Verterx(i - 1, j)))
                {
                    graph.Get().Add(new Verterx(i - 1, j));
                    i--;
                    Console.Write("[" + i + ", " + j + "]");
                    continue;
                 }
            }
            return graph;
        }

        static void PrintLabirint(int[,] labirint)
        {
            for (int i = 0; i <= labirint.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= labirint.GetUpperBound(1); j++)
                {
                    if (labirint[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(labirint[i, j] + " ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else Console.Write(labirint[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Verterx
    {
        public Verterx(int i, int j)
        {
            X = j;
            Y = i;
        }

        public int X { get;}
        public int Y { get; }
    }

    public class Graph
    {
        public Graph()
        {
            setVertex = new HashSet<Verterx>();
        }

        private HashSet<Verterx> setVertex;

        public HashSet<Verterx> Get()
        {
            return setVertex;
        }
    }
}
