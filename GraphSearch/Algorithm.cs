using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Algorithm
    {
        public System.Windows.Forms.RichTextBox outputRichTextBox { get; set; }
        public System.Windows.Forms.TextBox outputOpenTextBox { get; set; }
        public System.Windows.Forms.TextBox outputCloseTextBox { get; set; }
        public System.Windows.Forms.TextBox outputPathTextBox { get; set; }
        public System.Windows.Forms.TextBox outputCostTextBox { get; set; }
        public System.Windows.Forms.TextBox outputTotalCostTextBox { get; set; }
        protected Graph graph;
        protected Node start;
        protected Node goal;
        protected int step;
        public Node presentNode { get; set; }
        protected bool found;
        protected bool noPath;
        public Algorithm(Graph iGraph, Node iStart, Node iGoal)
        {
            graph = iGraph;
            start = iStart;
            goal = iGoal;
            found = false;
            noPath = false;
            step = 1;
            foreach (Node node in iGraph.nodes)
            {
                node.visited = false;
                node.cost = Constants.infinite;
                node.present = false;
                node.selecting = false;
            }
            foreach (Line line in iGraph.lines)
            {
                line.path = false;
            }
        }
        public virtual void startSearch()
        {
            if (found || noPath) return;
            outputRichTextBox.Text += Constants.endLineOutputRichTextBox;
        }
        public virtual void nextStep()
        {
            outputRichTextBox.Text +=Constants.endLineOutputRichTextBox+ "Step " + step.ToString()+" :\n";
            step++;
        }
        public virtual void updateTextBoxs()
        {
            
        }
        public virtual void updatePath()
        {
            if (presentNode == null) return;
            List<string> path = new List<string>();
            List<int> cost = new List<int>();
            int totalCost = 0;
            path.Add(presentNode.name);
            Node copyOfPresent = presentNode;
            foreach (Line line in graph.lines)
            {
                line.path = false;
            }
            while (presentNode.parent != null)
            {
                foreach (Line line in graph.lines)
                {
                    if ((line.begin == presentNode.parent && line.end == presentNode))
                    {
                        cost.Add(line.cost);
                        totalCost += line.cost;
                        line.path = true;
                    }
                }
                path.Add(presentNode.parent.name);
                presentNode = presentNode.parent;
            }
            presentNode = copyOfPresent;
            path.Reverse();
            string pathString = "";
            foreach (string s in path)
            {
                pathString += s + ">";
            }
            pathString = pathString.Remove(pathString.Length - 1);
            outputPathTextBox.Text = pathString;
            cost.Reverse();
            string costString = "";
            foreach (int s in cost)
            {
                costString += s.ToString() + "+";
            }
            if (costString.Length > 0) costString = costString.Remove(costString.Length - 1);
            outputCostTextBox.Text = costString;
            outputTotalCostTextBox.Text = totalCost.ToString();
        }
        public int getCost(Node x, Node y)
        {
            foreach (Line line in graph.lines)
            {
                if (line.begin == x && line.end == y)
                {
                    return line.cost;
                }
            }
            return -Constants.infinite;
        }
        public virtual void updatePath(Node between,Node begin, Node end)
        {
            outputOpenTextBox.Text = "Only for DPS,BFS and Djikstra";
            outputCloseTextBox.Text = "Only for DPS,BFS and Djikstra";
        }
        public virtual void drawCostMatrix(Graphics graphics)
        {
            graphics.Clear(Color.DarkGray);
            Font font = new Font("Arial", Constants.costMatrixPanelWidth / 35);
            graphics.DrawString("Only for Djikstra, Floyd and Ford-Bellman algorithm!", font, Constants.nodeNameBrush, Constants.costMatrixPanelWidth / 2, Constants.costMatrixPanelHeight / 2, Constants.stringAlignCenterFormat);
        }
    }
}
