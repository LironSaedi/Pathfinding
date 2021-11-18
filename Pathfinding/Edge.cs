using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Edge<T>
    {
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndingPoint { get; set; }
        public double Distance { get; set; }

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, double distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;
        }
    }
}
