using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;
        public double Distance { get; set; }

        public bool Visit;

        public Vertex<T> Founder { get; set; }
        public Vertex(T value) 
        {
        }

        public void Initialize()
        {
            Distance = double.PositiveInfinity;
            Visit = false;
            Founder = null;
        }
    }
}
