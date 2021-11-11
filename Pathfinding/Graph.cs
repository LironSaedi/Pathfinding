using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding
{
    class Graph<T>
    {
        private List<Vertex<T>> vertices;

        public IReadOnlyList<Vertex<T>> Vertices => vertices;
        public IReadOnlyList<Edge<T>> Edges;

        public int VertexCount => vertices.Count;

        public Graph() 
        {
        
        }

        public bool Contains(Vertex<T> v)
        {
            return vertices.Contains(v);
        }
    }
}
