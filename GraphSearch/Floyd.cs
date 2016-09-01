using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Floyd:Class2Algorithm
    {

        private Node[,] next;
        int loop1=0, loop2=0,loop3=0;
        private Node presentNode2;
        private Node presentNode3;  
        public Floyd(Graph iGraph,Node iStart,Node iGoal):base(iGraph,iStart,iGoal)
        {
            next = new Node[graph.nodes.Count, graph.nodes.Count];
        }
        public override void startSearch()
        {
            base.startSearch();
            outputRichTextBox.Text += "Floyd-Warshall Algorithm! \nBegin :\n";
            int begin, end;
            foreach (Line line in graph.lines)
            {
                begin = Int32.Parse(line.begin.name);
                end = Int32.Parse(line.end.name);
                costMatrix[begin, end] = line.cost;
                next[begin, end] = line.end;
                //dist[end, begin] = line.cost;
                //next[end, begin] = line.begin;
            }
            outputRichTextBox.Text += "->Initialize cost matrix base on graph!\n";
            outputRichTextBox.Text += "->If two node have no direct edge between set cost to infinite!\n";
            outputRichTextBox.Text += "->Next steps will perform loops to find lowest cost path to every pair node!\n";
        }
        public override void nextStep()
        {
            if (found || noPath) return;
            base.nextStep();
            if (presentNode != null) presentNode.present = false;
            if (presentNode2 != null) presentNode2.present = false;
            if (presentNode3 != null) presentNode3.present = false;
            outputRichTextBox.Text += "->Looping...\n";
            for (; loop1 < nodeCount; loop1++)
            {
                for (; loop2 < nodeCount; loop2++)
                {
                    for (; loop3 < nodeCount; loop3++)
                    {
                        if (loop1 == loop2 || loop2 == loop3 || loop3 == loop1) continue;
                        if ((costMatrix[loop2, loop1] + costMatrix[loop1, loop3]) < costMatrix[loop2, loop3])
                        {
                            costMatrix[loop2, loop3] = costMatrix[loop2, loop1] + costMatrix[loop1, loop3];
                            outputRichTextBox.Text += "->Found better path between node " + (loop2) + " and " + (loop3) + " through node " + (loop1) + ", update cost maxtrix!\n";
                            next[loop2, loop3] = next[loop2, loop1];
                            updatePath(graph.nodes[loop1],graph.nodes[loop2], graph.nodes[loop3]);
                            presentNode = graph.nodes[loop2];
                            presentNode2 = graph.nodes[loop3];
                            presentNode3 = graph.nodes[loop1];
                            presentNode.present = true;
                            presentNode2.present = true;
                            presentNode3.present = true;
                            return;
                        }
                    }
                    loop3 = 0;
                }
                loop2 = 0;
            }
            int s = Int32.Parse(start.name);
            int g = Int32.Parse(goal.name);
            outputRichTextBox.Text += "->Completed all loops,get best path from matrix!\n";
            if(next[s,g]==null)
            {
                outputRichTextBox.Text += "->There is no part to goal!\n";
                noPath = true;
            }
            else
            {
                outputRichTextBox.Text += "->Found best path!\n";
                found = true;
                presentNode = start;
                presentNode2 = goal;
                start.present = true;
                goal.present = true;
                updatePath(null,start, goal);
            }
        }
        public override void updatePath(Node between,Node begin, Node end)
        {
            string path = "";
            string cost = "";
            foreach (Line line in graph.lines)
            {
                line.path = false;
            }
            int b = Int32.Parse(begin.name);
            int e = Int32.Parse(end.name);
            outputTotalCostTextBox.Text = costMatrix[b, e].ToString();
            if (between == null)
            {
                while (begin != end)
                {
                    foreach (Line line in graph.lines)
                    {
                        if ((line.begin == begin && line.end == next[b, e]) )//|| (line.begin == next[b, e] && line.end == begin))
                        {
                            line.path = true;
                        }
                    }
                    int nextNode = Int32.Parse(next[b, e].name);
                    path += begin.name + ">";
                    cost += costMatrix[b, nextNode] + "+";
                    begin = next[b, e];
                    b = Int32.Parse(begin.name);
                }
            }
            else
            {
                e = Int32.Parse(between.name);
                while (begin != between)
                {
                    foreach (Line line in graph.lines)
                    {
                        if ((line.begin == begin && line.end == next[b, e]))// || (line.begin == next[b, e] && line.end == begin))
                        {
                            line.path = true;
                        }
                    }
                    int nextNode = Int32.Parse(next[b, e].name);
                    path += begin.name + ">";
                    cost += costMatrix[b, nextNode] + "+";
                    begin = next[b, e];
                    b = Int32.Parse(begin.name);
                }
                e = Int32.Parse(end.name);
                while (begin != end)
                {
                    foreach (Line line in graph.lines)
                    {
                        if ((line.begin == begin && line.end == next[b, e]))// || (line.begin == next[b, e] && line.end == begin))
                        {
                            line.path = true;
                        }
                    }
                    int nextNode = Int32.Parse(next[b, e].name);
                    path += begin.name + ">";
                    cost += costMatrix[b, nextNode] + "+";
                    begin = next[b, e];
                    b = Int32.Parse(begin.name);
                }
            }
            path += begin.name + ">";
            if (path.Length > 0) path=path.Remove(path.Length-1);
            if (cost.Length > 0) cost=cost.Remove(cost.Length - 1);
            outputPathTextBox.Text = path;
            outputCostTextBox.Text = cost;
        }
        public override void updatePath()
        {
            
        }
        public override void updateTextBoxs()
        {
            outputOpenTextBox.Text = "Only for DPS,BFS and Djikstra";
            outputCloseTextBox.Text = "Only for DPS,BFS and Djikstra";
        }
        public override void drawCostMatrix(Graphics graphics)
        {
            graphics.Clear(Color.Gray);
            int boxWidth = Constants.costMatrixPanelWidth / (nodeCount+1);
            int boxHeight = Constants.costMatrixPanelHeight / (nodeCount+1);
            Font indexFont = new Font("Arial", boxWidth/3);
            Font valueFont = new Font("Arial", boxWidth /3);
            for(int i=0;i<=nodeCount+1;i++)
            {
                graphics.DrawLine(Constants.costMaxtrixLinePen, i * boxWidth, 0, i*boxWidth, Constants.costMatrixPanelHeight);
                graphics.DrawLine(Constants.costMaxtrixLinePen, 0, i*boxHeight,Constants.costMatrixPanelWidth, i*boxHeight);
            }
            for(int i=1;i<nodeCount+1;i++)
            {
                graphics.DrawString((i - 1).ToString(), indexFont, Constants.lineCostBrush, i * boxWidth+boxWidth/2, boxHeight/2,Constants.stringAlignCenterFormat);
                graphics.DrawString((i - 1).ToString(), indexFont, Constants.lineCostBrush, boxWidth/2, i * boxHeight+boxHeight/2,Constants.stringAlignCenterFormat);
            }
            for (int i = 1; i < nodeCount + 1; i++)
            {
                for (int j = 1; j < nodeCount + 1; j++)
                {
                    if (costMatrix[i-1, j-1] == Constants.infinite) graphics.DrawString("∞", valueFont, Constants.linePathCostBrush, i * boxWidth + boxWidth/2, j*boxHeight+boxHeight/2,Constants.stringAlignCenterFormat);
                    else
                        graphics.DrawString(costMatrix[i-1, j-1].ToString(), valueFont, Constants.linePathCostBrush, i * boxWidth + boxWidth/2, j*boxHeight+boxHeight/2,Constants.stringAlignCenterFormat);
                }
            }
        }
    }
}
