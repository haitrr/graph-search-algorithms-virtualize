using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Class2Algorithm:Algorithm
    {
        public int[,] costMatrix { get; private set; }
        protected int nodeCount;
        public Class2Algorithm(Graph iGraph, Node iStart, Node iGoal)
            : base(iGraph, iStart, iGoal)
        {
            nodeCount = graph.nodes.Count;
            costMatrix = new int[graph.nodes.Count, graph.nodes.Count];
            for (int i = 0; i < nodeCount; i++)
                for (int j = 0; j < nodeCount; j++)
                {
                    costMatrix[i, j] = Constants.infinite;
                }
        }
    }
}
