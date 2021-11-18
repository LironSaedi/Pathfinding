using System;
using System.Collections.Generic;
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

            //initialize everything in graph
            
        }
    }
}
