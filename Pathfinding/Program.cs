using System;
using System.Collections.Generic;

namespace Pathfinding
{
    class Program
    {
        struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        static void Main(string[] args)
        {
            Vertex<Point> a = new Vertex<Point>(new Point(0, 0));
            Vertex<Point> b = new Vertex<Point>(new Point(1, 0));
            Vertex<Point> c = new Vertex<Point>(new Point(2, 0));
            Vertex<Point> d = new Vertex<Point>(new Point(0, 1));
            Vertex<Point> e = new Vertex<Point>(new Point(1, 1));
            Vertex<Point> f = new Vertex<Point>(new Point(2, 1));
            Vertex<Point> g = new Vertex<Point>(new Point(0, 2));
            Vertex<Point> h = new Vertex<Point>(new Point(1, 2));
            Vertex<Point> i = new Vertex<Point>(new Point(2, 2));
       
            Graph<Point> graph = new Graph<Point>();

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);
            graph.AddVertex(h);
            graph.AddVertex(i);

            double var = Math.Sqrt(2.0);
      /*      graph.AddEdge(a, b, 1);
            graph.AddEdge(a, d, 1);
            graph.AddEdge(a, e, var);
            graph.AddEdge(d, g, 1);
            graph.AddEdge(d, e, 1);
            graph.AddEdge(d, h, var);
            graph.AddEdge(i, h, 1);
            graph.AddEdge(i, f, 1);
            graph.AddEdge(i, e, var);
      */
            graph.AddEdge(a, e, var);
            graph.AddEdge(e, i, var);
            graph.AddEdge(a, d, 1);
            graph.AddEdge(d, g, 1);
            graph.AddEdge(g, h, 1);
            graph.AddEdge(h, i, 1);

            List<Vertex<Point>> list = new List<Vertex<Point>>();
            list = Pathfinding.Dijkstra(graph, a, i);

            for (int k = 0; k < list.Count; k++)
            {
                int x = list[k].Value.X;
                int y = list[k].Value.Y;

                Console.WriteLine($"X:{x}, Y:{y}");
            }


        
        }
    }
}
