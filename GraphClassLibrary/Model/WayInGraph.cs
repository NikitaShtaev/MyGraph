﻿
using System;
using System.Collections.Generic;

namespace GraphClassLibrary.Model
{
    public class WayInGraph
    {
        /// <summary>
        /// Previous vertexes for MinWayWeights for creation shortest way as List.
        /// </summary>
        public Vertex [] PreviousVertexes { get; set; }
        /// <summary>
        /// Algoritm of Deikstra array of MinWayWeights.
        /// </summary>
        public decimal [] MinWayWeights { get; set; }
        /// <summary>
        /// Maximum length for compare weights of graph. As sum of all existing weights.
        /// </summary>
        public decimal MaxWayLength { get; set; }
        /// <summary>
        /// Vertex where way started from.
        /// </summary>
        public Vertex Start { get; set; }
        /// <summary>
        /// Vertex where way finishes.
        /// </summary>
        public Vertex Finish { get; set; }
        /// <summary>
        /// Separately WAY class for user.
        /// </summary>
        private Way ShortestWay { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="maxWayLength"></param>
        public WayInGraph(int size, decimal maxWayLength, Vertex start, Vertex finish)
        {
            //TODO: check coming data to class WAYINGRAPH.
            MaxWayLength = maxWayLength;
            Start = start;
            Finish = finish;
            MinWayWeights = new decimal[size];
            PreviousVertexes = new Vertex[size];
            ShortestWay = new Way();
            var v1 = new Vertex(0);
            PreviousVertexes[0] = v1;
            MinWayWeights[0] = 0;
            for (int i = 1; i < size; i++)
            {
                MinWayWeights[i] = maxWayLength;
                PreviousVertexes[i] = v1;
            }
        }
        /// <summary>
        /// Returns shortest way for user.
        /// </summary>
        /// <returns></returns>
        public Way GetWayForUser()
        {
            if (MinWayWeights[Finish.Number] == MaxWayLength)
            {
                ShortestWay.IsWay = false;
                ShortestWay.Vertexes = new List<Vertex>();
                ShortestWay.Length = MaxWayLength;
            }
            else
            {
                ShortestWay.IsWay = true;
                var currentVertex = Finish;
                while (currentVertex != Start)
                {
                    ShortestWay.Vertexes.Add(currentVertex);
                    currentVertex = PreviousVertexes[currentVertex.Number];
                }
                ShortestWay.Vertexes.Add(Start);
                ShortestWay.Vertexes.Reverse();
                ShortestWay.Length = MinWayWeights[Finish.Number];
            }
            return ShortestWay;
        }
    }
}
