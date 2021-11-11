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

            start.Distance = double.PositiveInfinity;

            
        }
    }
}
