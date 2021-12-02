using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Pathfinding
{
    class Pathfinding
    {
        public static IEnumerable<Vertex<T>> Dijkstra<T>(Graph<T> graph, Vertex<T> start, Vertex<T> end)
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

            while(!priorityQueue.IsEmpty())
            {

                Vertex<T> current = priorityQueue.Dequeue();
                foreach(var v in current.Neighbors)
                {
                    v.Distance = ...
                }
            }

            var current = start;
            current.Distance()
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
