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

            this.vertices = new List<Vertex<T>>();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }

            if (vertex.Neighbors.Count != 0)
            {
                throw new Exception("");
            }


            if (Search(vertex.Value) != null)
            {
                throw new Exception("");
            }

            vertices.Add(vertex);
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b , double distance = 0)
        {
            if (!(GetEdge(a, b) == null && vertices.Contains(a) && vertices.Contains(b)))
            {
                return false;
            }

            a.Neighbors.Add(new Edge<T>(a, b, distance));
            return true;
        }
        public Vertex<T> Search(T value)
        {
            foreach (var item in vertices)
            {
                if (item.Value.Equals(value))
                {
                    return item;
                }
            }

            return null;
        }

        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(vertices.Contains(a) && vertices.Contains(b)))
            {
                return null;
            }

            foreach (var item in a.Neighbors)
            {
                if (item.EndingPoint == b)
                {
                    return item;
                }
            }

            return null;
        }
        public bool Contains(Vertex<T> v)
        {
            return vertices.Contains(v);
        }
    }
}
