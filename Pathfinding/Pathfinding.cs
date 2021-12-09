using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            while (temp != start)
            {
                list.Add(temp.Founder);
                temp = temp.Founder;
            }
            return list;

           //// var current = start;
           // current.Distance();
        }

        private class VertexComparer<T> : IComparer<Vertex<T>>
        {
            public int Compare([AllowNull] Vertex<T> x, [AllowNull] Vertex<T> y)
            {
                throw new NotImplementedException();
            }
        }
    }
}
