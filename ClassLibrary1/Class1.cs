using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * @file ce100-hw5-algo-lib-cs
 *
 * @author Huseyin Yasar
 *
 * @date 27 May 2022
 *
 */

namespace ce100_hw5_algo_lib_cs
{
    public class graphCycleDetection
    {

        private readonly int V;
        private readonly List<List<int>> adj;

        public graphCycleDetection(int V)
        {
            this.V = V;
            adj = new List<List<int>>(V);

            for (int i = 0; i < V; i++)
                adj.Add(new List<int>());
        }

        /** 
        * @name  isCyclicUtil
        * 
        * @brief Function mark the current node as stayed and part of recursion stack
        * 
        * @param [in] fiI [\b int]  function index of in the serie
        * 
        * @param [in] fiVisited [\b int]  stayed node
        * 
        * @param [in] fiRecStack [\b int]  marked node
        * 
        **/

        public bool isCyclicUtil(int i, bool[] stayed,
                                        bool[] stackRecorder)
        {

            // Mark the current node as stayed and
            // part of recursion stack
            if (stackRecorder[i])
                return true;

            if (stayed[i])
                return false;

            stayed[i] = true;

            stackRecorder[i] = true;
            List<int> baby = adj[i];

            foreach (int c in baby)
                if (isCyclicUtil(c, stayed, stackRecorder))
                    return true;

            stackRecorder[i] = false;

            return false;
        }

        /** 
        * @name  addSide
        * 
        * @brief Function to add an side into the graph
        * 
        * @param [in] fiSou [\b int]  function index of  in the serie
        * 
        * @param [in] fiDest [\b int]  function index of  in the serie
        * 
        **/

        public void addSide(int sou, int dest)
        {
            adj[sou].Add(dest);
        }

        /** 
        * @name  isCyclic
        * 
        * @brief Function mark all the vertices as not stayed and not part of recursion stack
        * 
        **/

        public bool isCyclic()
        {

            // Mark all the vertices as not stayed and
            // not part of recursion stack
            bool[] stayed = new bool[V];
            bool[] stackRecorder = new bool[V];


            // Call the recursive helper function to
            // detect cycle in different DFS trees
            for (int i = 0; i < V; i++)
                if (isCyclicUtil(i, stayed, stackRecorder))
                    return true;

            return false;
        }
    }

    public class MinimumSpanningTree
    {

        // A class to represent a graph side
        public class side : IComparable<side>
        {
            public int src, dest, weight;

            // Comparator function used for sorting edges
            // based on their weight
            public int CompareTo(side compareEdge)
            {
                return this.weight
                       - compareEdge.weight;
            }
        }

        // A class to represent
        // a subset for union-find
        public class subset
        {
            public int parent, rank;
        };

        int V, E; // V-> no. of vertices & E->no.of edges
        public side[] Side; // collection of all edges

        /** 
        * @name  MinimumSpanningTree
        * 
        * @brief Function creates a graph with V vertices and E edges
        * 
        * @param [in] fiV [\b int]  vertices
        * 
        * @param [in] fiE [\b int]  edges
        * 
        **/

        // Creates a graph with V vertices and E edges
        public MinimumSpanningTree(int v, int e)
        {
            V = v;
            E = e;
            Side = new side[E];
            for (int i = 0; i < e; ++i)
                Side[i] = new side();
        }

        /** 
        * @name  find
        * 
        * @brief A utility function to find set of an element i 
        * 
        * @param [in] fiSubsets [\b int]  our subsets
        * 
        * @param [in] fiI [\b int]  element i
        * 
        **/

        // A utility function to find set of an element i
        // (uses path compression technique)
        int find(subset[] subsets, int i)
        {
            // find root and make root as
            // parent of i (path compression)
            if (subsets[i].parent != i)
                subsets[i].parent
                    = find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        /** 
        * @name  Union
        * 
        * @brief A function that does union of two sets of x and y
        * 
        * @param [in] fiSubsets [\b int]  our subsets
        * 
        * @param [in] fiX [\b int]  x set
        * 
        * @param [in] fiY [\b int]  y set
        * 
        **/

        // A function that does union of
        // two sets of x and y (uses union by rank)
        void Union(subset[] subsets, int x, int y)
        {
            int xBase = find(subsets, x);
            int yBase = find(subsets, y);

            // Attach smaller rank tree under root of
            // high rank tree (Union by Rank)
            if (subsets[xBase].rank < subsets[yBase].rank)
                subsets[xBase].parent = yBase;
            else if (subsets[xBase].rank > subsets[yBase].rank)
                subsets[yBase].parent = xBase;

            // If ranks are same, then make one as root
            // and increment its rank by one
            else
            {
                subsets[yBase].parent = xBase;
                subsets[xBase].rank++;
            }
        }

        /** 
        * @name  KruskalMST
        * 
        * @brief Function calculates the kruskal algorithm
        * 
        **/

        // The main function to construct MST
        // using Kruskal's algorithm
        public string KruskalMST()
        {
            // This will store the
            // resultant MST
            side[] result = new side[V];
            String mst = "";
            int e = 0; // An index variable, used for result[]
            int i
                = 0; // An index variable, used for sorted edges
            for (i = 0; i < V; ++i)
                result[i] = new side();

            // Step 1: Sort all the edges in non-decreasing
            // order of their weight. If we are not allowed
            // to change the given graph, we can create
            // a copy of array of edges
            Array.Sort(Side);

            // Allocate memory for creating V subsets
            subset[] subsets = new subset[V];
            for (i = 0; i < V; ++i)
                subsets[i] = new subset();

            // Create V subsets with single elements
            for (int v = 0; v < V; ++v)
            {
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            i = 0; // Index used to pick next side

            // Number of edges to be taken is equal to V-1
            while (e < V - 1)
            {
                // Step 2: Pick the smallest side. And increment
                // the index for next iteration
                side next_edge = new side();
                next_edge = Side[i++];

                int x = find(subsets, next_edge.src);
                int y = find(subsets, next_edge.dest);

                // If including this side doesn't cause cycle,
                // include it in result and increment the index
                // of result for next side
                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
                // Else discard the next_edge
            }

            int minimumCost = 0;
            for (i = 0; i < e; ++i)
            {
                mst += "(" + result[i].src + "(source)" + "--> " + result[i].dest + "(destination)" + " == " + result[i].weight + "(weight)" + ")";
                minimumCost += result[i].weight;
            }

            return mst;
        }
    }

    public class singleSourceShortestPath
    {
        public class Side
        {
            public int src, dest, weight;
            public Side()
            {
                src = dest = weight = 0;
            }
        };

        public int V, E;
        public Side[] side;

        /** 
        * @name  singleSourceShortestPath
        * 
        * @brief Function calculates the Single Source Shortest Path
        * 
        * @param [in] fiV [\b int]  vertices
        * 
        * @param [in] fiE [\b int]  edges
        * 
        **/

        public singleSourceShortestPath(int v, int e)
        {
            V = v;
            E = e;
            side = new Side[e];
            for (int i = 0; i < e; ++i)
                side[i] = new Side();
        }

        /** 
        * @name  BellmanFord
        * 
        * @brief Function calculates the Bellman Ford algorithm
        * 
        * @param [in] fiGraph [\b int]  our graph
        * 
        * @param [in] fiS[\b int]  source name
        * 
        **/

        public static string BellmanFord(singleSourceShortestPath graph, int s)
        {
            string result = "";
            int V = graph.V, E = graph.E;
            int[] dist = new int[V];


            for (int i = 0; i < V; ++i)
                dist[i] = int.MaxValue;
            dist[s] = 0;

            for (int i = 1; i < V; ++i)
            {
                for (int j = 0; j < E; ++j)
                {
                    int u = graph.side[j].src;
                    int v = graph.side[j].dest;
                    int weight = graph.side[j].weight;
                    if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                        dist[v] = dist[u] + weight;
                }
            }

            for (int j = 0; j < E; ++j)
            {
                int u = graph.side[j].src;
                int v = graph.side[j].dest;
                int weight = graph.side[j].weight;
                if (dist[u] != int.MaxValue && dist[u] + weight < dist[v])
                {
                    result = "Graph contains negative weight cycle";
                    return result;
                }
            }
            result = "(Vertex = Distance from Source)\r\n";
            for (int i = 0; i < V; ++i)
                result += "(" + i + " = " + dist[i] + ")\r\n";
            return result;
        }
    }

    public class MaxFlow
    {
        static readonly int V = 6; // Number of vertices in
                                   // graph

        /** 
        * @name  bfs
        * 
        * @brief Returns true if there is a path from source 's' to sink 't' in residual graph. Also fills parent[] to store the path
        * 
        * @param [in] fiRGraph [\b int] our graph
        * 
        * @param [in] fiS [\b int]  source name
        * 
        * @param [in] fiT [\b int]  sink name
        * 
        * @param [in] fiParent [\b int]  the value we store the path
        * 
        **/

        /* Returns true if there is a path
        from source 's' to sink 't' in residual
        graph. Also fills parent[] to store the
        path */

        bool bfs(int[,] rGraph, int s, int t, int[] parent)
        {
            // Create a stayed array and mark
            // all vertices as not stayed
            bool[] visited = new bool[V];
            for (int i = 0; i < V; ++i)
                visited[i] = false;

            // Create a queue, enqueue source vertex and mark
            // source vertex as stayed
            List<int> queue = new List<int>();
            queue.Add(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (queue.Count != 0)
            {
                int u = queue[0];
                queue.RemoveAt(0);

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false
                        && rGraph[u, v] > 0)
                    {
                        // If we find a connection to the sink
                        // node, then there is no point in BFS
                        // anymore We just have to set its parent
                        // and can return true
                        if (v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Add(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            // We didn't reach sink in BFS starting from source,
            // so return false
            return false;
        }

        /** 
        * @name  fordFulkerson
        * 
        * @brief Returns the maximum flow from s to t in the given graph
        * 
        * @param [in] fiGraph [\b int]  our graph
        * 
        * @param [in] fiS [\b int]  source name
        * 
        * @param [in] fiT [\b int]  sink name
        * 
        **/


        // Returns the maximum flow
        // from s to t in the given graph
        public int fordFulkerson(int[,] graph, int s, int t)
        {
            int u, v;

            // Create a residual graph and fill
            // the residual graph with given
            // capacities in the original graph as
            // residual capacities in residual graph

            // Residual graph where rGraph[i,j]
            // indicates residual capacity of
            // side from i to j (if there is an
            // side. If rGraph[i,j] is 0, then
            // there is not)
            int[,] rGraph = new int[V, V];

            for (u = 0; u < V; u++)
                for (v = 0; v < V; v++)
                    rGraph[u, v] = graph[u, v];

            // This array is filled by BFS and to store path
            int[] parent = new int[V];

            int max_flow = 0; // There is no flow initially

            // Augment the flow while there is path from source
            // to sink
            while (bfs(rGraph, s, t, parent))
            {
                // Find minimum residual capacity of the edhes
                // along the path filled by BFS. Or we can say
                // find the maximum flow through the path found.
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow
                        = Math.Min(path_flow, rGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= path_flow;
                    rGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;
            }

            // Return the overall flow
            return max_flow;
        }
    }
}
