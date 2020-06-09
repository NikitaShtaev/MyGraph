using GraphClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace GraphClassLibrary.Tests
{
    [TestClass()]
    public class MyGraphClassTests
    {
        [TestMethod()]
        public void GetWayTest()
        {
            //Arrange
            var v0 = new Vertex(0);
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3); ;
            var lst = new List<Edge>();
            AddToEdgeList(lst, v0, v1, 1); //1
            AddToEdgeList(lst, v0, v2, 2); //2
            AddToEdgeList(lst, v1, v3, 1); //3
            AddToEdgeList(lst, v1, v2, 4); //4
            AddToEdgeList(lst, v2, v3, 2); //5
            AddToEdgeList(lst, v3, v2, 2); //6
            var correct = "From[#1:1] - To[#2:2]: Length:3; -#1:1--#3:3--#2:2-";
            //Act
            var graph = new MyGraphClass(lst);
            var result = graph.GetWay(v1, v2).ToString();
            //Asset
            Assert.AreEqual(correct, result);
        }

        [TestMethod()]
        public void GetWayFromToThroughTest()
        {
            //Arrange
            var v0 = new Vertex(0);
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3); ;
            var lst = new List<Edge>();
            AddToEdgeList(lst, v0, v1, 1); //1
            AddToEdgeList(lst, v0, v2, 2); //2
            AddToEdgeList(lst, v1, v3, 1); //3
            AddToEdgeList(lst, v1, v2, 4); //4
            AddToEdgeList(lst, v2, v3, 2); //5
            AddToEdgeList(lst, v3, v2, 2); //6
            var correct = "From[#0:0] - To[#3:3]: Length:4; -#0:0--#2:2--#3:3-";
            //Act
            var graph = new MyGraphClass(lst);
            var result = graph.GetWayFromToThrough(v0, v3, v2).ToString();
            //Asset
            Assert.AreEqual(correct, result);
        }

        [TestMethod()]
        public void ReadGraphTest()
        {
            //arrange
            var v0 = new Vertex(0);
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var lst = new List<Edge>();
            AddToEdgeList(lst, v0, v1, 1); //1
            AddToEdgeList(lst, v0, v2, 2); //2
            AddToEdgeList(lst, v1, v3, 1); //3
            AddToEdgeList(lst, v1, v2, 4); //4
            AddToEdgeList(lst, v2, v3, 2); //5
            AddToEdgeList(lst, v3, v2, 2); //6
            var graph = new MyGraphClass(lst);
            graph.WriteGraph("TestGraph.json");
            var graph2 = new MyGraphClass();
            graph2 = graph2.ReadGraph("TestGraph.json");
            var correct1 = "From[#1:1] - To[#2:2]: Length:3; -#1:1--#3:3--#2:2-";
            var correct2 = "From[#0:0] - To[#3:3]: Length:4; -#0:0--#2:2--#3:3-";
            //act
            var result1 = graph2.GetWay(v1, v2).ToString();
            var result2 = graph2.GetWayFromToThrough(v0, v3, v2).ToString();
            //asset
            Assert.AreEqual(correct1, result1);
            Assert.AreEqual(correct2, result2);
        }
        static void AddToEdgeList(List<Edge> lst, Vertex v1, Vertex v2, int weight)
        {
            lst.Add(new Edge(v1, v2, weight));
        }
    }

}