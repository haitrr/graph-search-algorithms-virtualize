using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Class1Algorithm:Algorithm
    {
        protected List<Node> toVisitSet;
        protected List<Node> visitedSet;
        public Class1Algorithm(Graph iGraph,Node iStart,Node iGoal):base(iGraph,iStart,iGoal)
        {
            toVisitSet = new List<Node>();
            visitedSet = new List<Node>();
        }
        public override void updateTextBoxs()
        {
            outputCloseTextBox.Text = "";
            outputOpenTextBox.Text = "";
            foreach (Node node in toVisitSet)
            {
                outputOpenTextBox.Text += node.name + ",";
            }
            foreach (Node node in visitedSet)
            {
                outputCloseTextBox.Text += node.name + ",";
            }
            updatePath();
        }
    }
}
