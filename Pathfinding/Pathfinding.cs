using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    class Pathfinding
    {
        public static List<Vertex<T>> Dijkstra<T>(Graph<T> graph, Vertex<T> start, Vertex<T> end)
        {
            if (!(graph.Contains(start) && graph.Contains(end)))
            {
                return null;
            }
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                graph.Vertices[i].Initialize();
            }


            start.Distance = 0;


            PriorityQueue<Vertex<T>> priorityQueue = new PriorityQueue<Vertex<T>>(new VertexComparer<T>());
            priorityQueue.Enqueue(start);

            while (!priorityQueue.IsEmpty() && !end.Visit)
            {

                Vertex<T> current = priorityQueue.Dequeue();
                current.Visit = true;
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndingPoint;
                    double tentative = edge.Distance + current.Distance;

                    if (tentative < neighbor.Distance)
                    {
                        neighbor.Distance = tentative;
                        neighbor.Founder = current;
                        current.Visit = false;
                    }

                    if (!priorityQueue.Contains(neighbor) && !neighbor.Visit == true)

                    {
                        priorityQueue.Enqueue(neighbor);
                    }
                }
            }
            List<Vertex<T>> list = new List<Vertex<T>>();
            Vertex<T> temp = end;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.Founder;
            }
            list.Reverse();
            return list;

            //// var current = start;
            // current.Distance();
        }


        public static List<Vertex<T>> AStar<T>(Graph<T> graph, Vertex<T> start, Vertex<T> end, Func<Vertex<T>, Vertex<T>, double> heuristic)
        {
            if (!(graph.Contains(start) && graph.Contains(end)))
            {
                return null;
            }
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                graph.Vertices[i].Initialize2();
            }

            start.Distance = 0;


            PriorityQueue<Vertex<T>> priorityQueue = new PriorityQueue<Vertex<T>>(new VertexComparer<T>());
            priorityQueue.Enqueue(start);

            while (!priorityQueue.IsEmpty() && !end.Visit)
            {

                Vertex<T> current = priorityQueue.Dequeue();
                current.Visit = true;
                foreach (var edge in current.Neighbors)
                {
                    var neighbor = edge.EndingPoint;
                    double tentative = edge.Distance + current.Distance;

                    if (tentative < neighbor.Distance)
                    {
                        neighbor.Distance = tentative;
                        neighbor.Founder = current;
                        current.Visit = false;
                    }

                    if (!priorityQueue.Contains(neighbor) && !neighbor.Visit == true)

                    {
                        priorityQueue.Enqueue(neighbor);
                    }
                }
            }
            List<Vertex<T>> list = new List<Vertex<T>>();
            Vertex<T> temp = end;
            while (temp != null)
            {
                list.Add(temp);
                temp = temp.Founder;
            }
            list.Reverse();
            return list;

            //// var current = start;
            // current.Distance();
        }
        private double callMe()
        {
            return double.NaN;
        }

        public void Function<T>(Func<Vertex<T>, Vertex<T>, double> heuristic)
        {
            //double x = callMe();
            //double y = heuristic.Invoke(null, null);
            Func<Vertex<double>, Vertex<int>, double> manhattan = (v1, v2) =>
            {
                return Math.Abs(v1.Value - v2.Value);
            };
            AStar(graph, manhattan, start, end);
            Func<Vertex<int>, Vertex<int>, double> euclidian = (v1, v2) =>
            {
                return Math.Abs(v1.Value - v2.Value) * 2;
            };
            List<int> items = new List<int>();
            var add = items.Select(n => n + 1);
        }

        private class VertexComparer<T> : IComparer<Vertex<T>>
        {
            public int Compare([AllowNull] Vertex<T> x, [AllowNull] Vertex<T> y)
            {
                if (x.Distance < y.Distance)
                {
                    return -1;
                }
                if (x.Distance > y.Distance)
                {
                    return 1;
                }

                return 0;
            }
        }
    }
}
