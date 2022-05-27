using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ce100_hw5_algo_lib_cs;

namespace ce100_hw5_algo_test_cs
{
    [TestClass]
    public class Graph_Cycle_Detection_Tests
    {
        [TestMethod]
        public void Graph_Cycle_Detection_Test_1()
        {
            graphCycleDetection graph = new graphCycleDetection(9);
            graph.addSide(1, 2);
            graph.addSide(1, 3);
            graph.addSide(1, 4);
            graph.addSide(1, 5);
            graph.addSide(2, 6);
            graph.addSide(2, 7);
            graph.addSide(3, 8);

            bool result = false;
            Assert.AreEqual(result, graph.isCyclic());

        }

        [TestMethod]
        public void graph_Cycle_Detection_Test_2()
        {
            graphCycleDetection graph = new graphCycleDetection(6);
            graph.addSide(0, 1);
            graph.addSide(1, 2);
            graph.addSide(2, 0);
            graph.addSide(3, 4);
            graph.addSide(4, 5);

            bool result = true;
            Assert.AreEqual(result, graph.isCyclic());

        }

        [TestMethod]
        public void graph_Cycle_Detection_Test_3()
        {
            graphCycleDetection graph = new graphCycleDetection(4);
            graph.addSide(0, 1);
            graph.addSide(0, 2);
            graph.addSide(1, 2);
            graph.addSide(2, 0);
            graph.addSide(2, 3);

            bool result = true;
            Assert.AreEqual(result, graph.isCyclic());

        }
    }

    [TestClass]
    public class Minimum_Spanning_Tree_Tests
    {
        [TestMethod]
        public void Minimum_Spanning_Tree_Test_1()
        {
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            MinimumSpanningTree graph = new MinimumSpanningTree(V, E);

            // add side 0-1
            graph.Side[0].src = 0;
            graph.Side[0].dest = 1;
            graph.Side[0].weight = 10;

            // add side 0-2
            graph.Side[1].src = 0;
            graph.Side[1].dest = 2;
            graph.Side[1].weight = 6;

            // add side 0-3
            graph.Side[2].src = 0;
            graph.Side[2].dest = 3;
            graph.Side[2].weight = 5;

            // add side 1-3
            graph.Side[3].src = 1;
            graph.Side[3].dest = 3;
            graph.Side[3].weight = 15;

            // add side 2-3
            graph.Side[4].src = 2;
            graph.Side[4].dest = 3;
            graph.Side[4].weight = 4;

            string result = graph.KruskalMST();
            string expected = "(2(source)--> 3(destination) == 4(weight))(0(source)--> 3(destination) == 5(weight))(0(source)--> 1(destination) == 10(weight))";
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void Minimum_Spanning_Tree_Test_2()
        {
            int V = 5; // Number of vertices in graph
            int E = 7; // Number of edges in graph
            MinimumSpanningTree graph = new MinimumSpanningTree(V, E);

            // add side 0-1
            graph.Side[0].src = 0;
            graph.Side[0].dest = 1;
            graph.Side[0].weight = 1;

            // add side 0-2
            graph.Side[1].src = 0;
            graph.Side[1].dest = 2;
            graph.Side[1].weight = 3;

            // add side 1-3
            graph.Side[2].src = 1;
            graph.Side[2].dest = 3;
            graph.Side[2].weight = 5;

            // add side 1-4
            graph.Side[3].src = 1;
            graph.Side[3].dest = 4;
            graph.Side[3].weight = 10;

            // add side 1-2
            graph.Side[4].src = 1;
            graph.Side[4].dest = 2;
            graph.Side[4].weight = 7;

            // add side 2-4
            graph.Side[5].src = 2;
            graph.Side[5].dest = 4;
            graph.Side[5].weight = 4;

            // add side 3-4
            graph.Side[6].src = 3;
            graph.Side[6].dest = 4;
            graph.Side[6].weight = 2;

            string result = graph.KruskalMST();
            string expected = "(0(source)--> 1(destination) == 1(weight))(3(source)--> 4(destination) == 2(weight))(0(source)--> 2(destination) == 3(weight))(2(source)--> 4(destination) == 4(weight))";
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Minimum_Spanning_Tree_Test_3()
        {
            int V = 9; // Number of vertices in graph
            int E = 14; // Number of edges in graph
            MinimumSpanningTree graph = new MinimumSpanningTree(V, E);

            // add side 0-1
            graph.Side[0].src = 0;
            graph.Side[0].dest = 1;
            graph.Side[0].weight = 4;

            // add side 0-7
            graph.Side[1].src = 0;
            graph.Side[1].dest = 7;
            graph.Side[1].weight = 8;

            // add side 1-2
            graph.Side[2].src = 1;
            graph.Side[2].dest = 2;
            graph.Side[2].weight = 8;

            // add side 1-7
            graph.Side[3].src = 1;
            graph.Side[3].dest = 7;
            graph.Side[3].weight = 11;

            // add side 7-8
            graph.Side[4].src = 7;
            graph.Side[4].dest = 8;
            graph.Side[4].weight = 7;

            // add side 2-8
            graph.Side[5].src = 2;
            graph.Side[5].dest = 8;
            graph.Side[5].weight = 2;

            // add side 8-6
            graph.Side[6].src = 8;
            graph.Side[6].dest = 6;
            graph.Side[6].weight = 6;

            // add side 2-3
            graph.Side[7].src = 2;
            graph.Side[7].dest = 3;
            graph.Side[7].weight = 7;

            // add side 2-5
            graph.Side[8].src = 2;
            graph.Side[8].dest = 5;
            graph.Side[8].weight = 4;

            // add side 6-5
            graph.Side[9].src = 6;
            graph.Side[9].dest = 5;
            graph.Side[9].weight = 2;

            // add side 3-5
            graph.Side[10].src = 3;
            graph.Side[10].dest = 5;
            graph.Side[10].weight = 14;

            // add side 3-4
            graph.Side[11].src = 3;
            graph.Side[11].dest = 4;
            graph.Side[11].weight = 9;

            // add side 5-4
            graph.Side[12].src = 5;
            graph.Side[12].dest = 4;
            graph.Side[12].weight = 10;

            // add side 7-6
            graph.Side[13].src = 7;
            graph.Side[13].dest = 6;
            graph.Side[13].weight = 1;


            string result = graph.KruskalMST();
            string expected = "(7(source)--> 6(destination) == 1(weight))(2(source)--> 8(destination) == 2(weight))(6(source)--> 5(destination) == 2(weight))(0(source)--> 1(destination) == 4(weight))(2(source)--> 5(destination) == 4(weight))(2(source)--> 3(destination) == 7(weight))(0(source)--> 7(destination) == 8(weight))(3(source)--> 4(destination) == 9(weight))";
            Assert.AreEqual(result, expected);
        }
    }

    [TestClass]
    public class Single_Source_Shortest_Path_Tests
    {
        [TestMethod]
        public void single_Source_Shortest_Path_Test_1()
        {
            int A = 5;
            int B = 6;

            singleSourceShortestPath graph = new singleSourceShortestPath(A, B);

            // add side 0-1
            graph.side[0].src = 0;
            graph.side[0].dest = 1;
            graph.side[0].weight = 2;

            // add side 0-2
            graph.side[1].src = 0;
            graph.side[1].dest = 2;
            graph.side[1].weight = 2;

            // add side 1-3
            graph.side[2].src = 1;
            graph.side[2].dest = 3;
            graph.side[2].weight = 3;

            // add side 2-3
            graph.side[3].src = 2;
            graph.side[3].dest = 3;
            graph.side[3].weight = 6;

            // add side 2-4
            graph.side[4].src = 2;
            graph.side[4].dest = 4;
            graph.side[4].weight = 4;

            // add side 3-4
            graph.side[5].src = 3;
            graph.side[5].dest = 4;
            graph.side[5].weight = -5;


            string result = "(Vertex = Distance from Source)\r\n" +
                "(0 = 0)\r\n" +
                "(1 = 2)\r\n" +
                "(2 = 2)\r\n" +
                "(3 = 5)\r\n" +
                "(4 = 0)\r\n";

            Assert.AreEqual(singleSourceShortestPath.BellmanFord(graph, 0), result);
        }

        [TestMethod]
        public void single_Source_Shortest_Path_Test_2()
        {
            int V = 5;
            int E = 8;

            singleSourceShortestPath graph = new singleSourceShortestPath(V, E);

            // add side 0-1
            graph.side[0].src = 0;
            graph.side[0].dest = 1;
            graph.side[0].weight = -1;

            // add side 0-2 
            graph.side[1].src = 0;
            graph.side[1].dest = 2;
            graph.side[1].weight = 4;

            // add side 1-2 
            graph.side[2].src = 1;
            graph.side[2].dest = 2;
            graph.side[2].weight = 3;

            // add side 1-3 
            graph.side[3].src = 1;
            graph.side[3].dest = 3;
            graph.side[3].weight = 2;

            // add side 1-4 
            graph.side[4].src = 1;
            graph.side[4].dest = 4;
            graph.side[4].weight = 2;

            // add side 3-2 
            graph.side[5].src = 3;
            graph.side[5].dest = 2;
            graph.side[5].weight = 5;

            // add side 3-1 
            graph.side[6].src = 3;
            graph.side[6].dest = 1;
            graph.side[6].weight = 1;

            // add side 4-3 
            graph.side[7].src = 4;
            graph.side[7].dest = 3;
            graph.side[7].weight = -3;


            string result = "(Vertex = Distance from Source)\r\n" +
                "(0 = 0)\r\n" +
                "(1 = -1)\r\n" +
                "(2 = 2)\r\n" +
                "(3 = -2)\r\n" +
                "(4 = 1)\r\n";

            Assert.AreEqual(singleSourceShortestPath.BellmanFord(graph, 0), result);

        }

        [TestMethod]
        public void Single_Source_Shortest_Path_Test_3()
        {
            int V = 4; // Number of vertices in graph
            int E = 5; // Number of edges in graph
            singleSourceShortestPath graph = new singleSourceShortestPath(V, E);

            // add side 0-1
            graph.side[0].src = 0;
            graph.side[0].dest = 1;
            graph.side[0].weight = 10;

            // add side 0-2
            graph.side[1].src = 0;
            graph.side[1].dest = 2;
            graph.side[1].weight = 6;

            // add side 0-3
            graph.side[2].src = 0;
            graph.side[2].dest = 3;
            graph.side[2].weight = 5;

            // add side 1-3
            graph.side[3].src = 1;
            graph.side[3].dest = 3;
            graph.side[3].weight = 15;

            // add side 2-3
            graph.side[4].src = 2;
            graph.side[4].dest = 3;
            graph.side[4].weight = 4;

            string result = "(Vertex = Distance from Source)\r\n" +
                "(0 = 0)\r\n" +
                "(1 = 10)\r\n" +
                "(2 = 6)\r\n" +
                "(3 = 5)\r\n";

            Assert.AreEqual(singleSourceShortestPath.BellmanFord(graph, 0), result);
        }
    }

    [TestClass]
    public class Max_Flow_Tests
    {
        [TestMethod]
        public void Max_Flow_Test_1()
        {
            int[,] graph = new int[,] {
            { 0, 16, 13, 0, 0, 0 }, { 0, 0, 10, 12, 0, 0 },
            { 0, 4, 0, 0, 14, 0 },  { 0, 0, 9, 0, 0, 20 },
            { 0, 0, 0, 7, 0, 4 },   { 0, 0, 0, 0, 0, 0 }
        };

            MaxFlow m = new MaxFlow();

            int result = 23;
            Assert.AreEqual(m.fordFulkerson(graph, 0, 5), result);
        }

        [TestMethod]
        public void Max_Flow_Test_2()
        {
            int[,] graph = new int[,] {
            { 0, 10, 10, 0, 0, 0 }, { 0, 0, 2, 4, 8, 0 },
            { 0, 0, 0, 0, 9, 0 },  { 0, 0, 0, 0, 0, 10 },
            { 0, 0, 0, 6, 0, 10 },   { 0, 0, 0, 0, 0, 0 }
        };
            MaxFlow m = new MaxFlow();
            int result = 19;
            Assert.AreEqual(m.fordFulkerson(graph, 0, 5), result);
        }

        [TestMethod]
        public void Max_Flow_Test_3()
        {
            int[,] graph = new int[,] {
            { 0, 7, 5, 0, 0, 0 }, { 0, 0, 5, 4, 0, 0 },
            { 0, 0, 0, 6, 4, 0 },  { 0, 0, 0, 0, 2, 5 },
            { 0, 0, 0, 0, 0, 6 },   { 0, 0, 0, 0, 0, 0 }
        };
            MaxFlow m = new MaxFlow();
            int result = 11;
            Assert.AreEqual(m.fordFulkerson(graph, 0, 5), result);

        }
    }
}
