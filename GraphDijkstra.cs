using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using DataStuctureLab.Extensions;

namespace DataStuctureLab
{
    class GraphDijkstra
    {
        private double[] shortestDistance;
        private double[] previousVertices;
        private List<int> unvisitedVertices;

        public GraphDijkstra(double[,] adjacencyMatrix, int totalVertices)
        {
            this.previousVertices = new double[totalVertices];
            this.shortestDistance = new double[totalVertices];
            this.unvisitedVertices = new List<int>();
            for (int i = 0; i < totalVertices; i++)
            {
                //Console.WriteLine(i);
                this.unvisitedVertices.Add(i);
                this.shortestDistance[i] = double.PositiveInfinity;
            }

            this.shortestDistance[0] = 0;

            //generate information about shortest distance and paths
            while (this.unvisitedVertices.Count > 0)
            {
                var currentVertex = GetNextVertex();
                //scan the matrix
                for (int i = 0; i < totalVertices; i++)
                {
                    //if there is an edge with another
                    if (adjacencyMatrix[currentVertex, i] > 0)
                    {
                        //if the shortest known distance to this neighboring vertex is bigger than what we calculate
                        if (this.shortestDistance[i] > (this.shortestDistance[currentVertex] + adjacencyMatrix[currentVertex, i]))
                        {
                            //update shortest distance
                            this.shortestDistance[i] = this.shortestDistance[currentVertex] + adjacencyMatrix[currentVertex, i];
                            //and the vertex we arrived at the neighbour via
                            this.previousVertices[i] = currentVertex;
                        }
                    }
                }
            }
        }

        public double[] ShortestDistance
        {
            get
            {
                return this.shortestDistance;
            }
        }

        public double[] Paths
        {
            get
            {
                return this.previousVertices;
            }
        }

        public void ShortestPath()
        {
            var distance = this.ShortestDistance;
            var path = this.Paths;

            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine("Vertex " + i + "   Distance " + distance[i] + "   Via Vertex " + path[i]);
            }
        }

        public int GetNextVertex()
        {
            //returns unvisited vertex with the smallest known distance from start

            var smallestKnowDistance = Double.PositiveInfinity;
            int vertex = -1;

            foreach (var value in this.unvisitedVertices)
            {
                if (this.shortestDistance[value] <= smallestKnowDistance)
                {
                    smallestKnowDistance = this.shortestDistance[value];
                    vertex = value;
                }
            }

            this.unvisitedVertices.Remove(vertex);
            return vertex;
        }

        public static void Run()
        {
            var graph = new Graph(5);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge(0, 1, 6);
            graph.AddEdge(0, 3, 1);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(2, 1, 5);
            graph.AddEdge(2, 4, 5);
            graph.AddEdge(3, 0, 1);
            graph.AddEdge(3, 1, 2);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(4, 1, 4);
            graph.AddEdge(4, 2, 5);
            graph.AddEdge(4, 3, 1);

            graph.GetAdjMatrix().Dump();

            var dijkstra = new GraphDijkstra(graph.GetAdjMatrix(), 5);
            dijkstra.ShortestPath();
        }
    }

    public class Vertex
    {
        public string Value;
        public bool IsVisited;

        public Vertex(string value)
        {
            this.Value = value;
        }
    }

    public class Graph
    {
        readonly int TOTAL_VERTICES;
        private Vertex[] vertices;
        private double[,] adjacencyMatrix;
        private int numberOfVertices;

        public Graph(int vertices)
        {
            this.TOTAL_VERTICES = vertices;
            this.vertices = new Vertex[vertices];
            this.adjacencyMatrix = new double[vertices, vertices];

            int x, y;
            for (x = 0; x < vertices; x++)
            {
                for (y = 0; y < vertices; y++)
                {
                    this.adjacencyMatrix[x, y] = 0;
                }
            }

            this.numberOfVertices = 0;
        }

        public static void Run()
        {
            var graph = new Graph(5);
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddEdge(0, 1, 6);
            graph.AddEdge(0, 3, 1);
            graph.AddEdge(1, 2, 5);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(2, 1, 5);
            graph.AddEdge(2, 4, 5);
            graph.AddEdge(3, 0, 1);
            graph.AddEdge(3, 1, 2);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(4, 1, 4);
            graph.AddEdge(4, 2, 5);
            graph.AddEdge(4, 3, 1);

            graph.GetAdjMatrix().Dump();
        }

        public void AddVertex(string val)
        {
            this.vertices[this.numberOfVertices++] = new Vertex(val);
        }

        public void AddEdge(int startVertex, int endVertex, double weight)
        {
            this.adjacencyMatrix[startVertex, endVertex] = weight;
            this.adjacencyMatrix[endVertex, startVertex] = weight; //undirected graph - symmetric
        }

        public void ShowVertex(int v)
        {
            if (v < TOTAL_VERTICES)
                Console.WriteLine((this.vertices[v]).Value);
        }

        public double[,] GetAdjMatrix()
        {
            return this.adjacencyMatrix;
        }

    }
}
