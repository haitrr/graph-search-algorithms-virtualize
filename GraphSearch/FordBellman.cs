using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class FordBellman:Class2Algorithm
    {
        int loop1=0;
        int loop2=0;
        public FordBellman(Graph iGraph,Node iStart,Node iGoal):base(iGraph,iStart,iGoal)
        {
        }
        public override void startSearch()
        {
            base.startSearch();
            outputRichTextBox.Text += "Ford-Bellman Algorithm! \nBegin :\n";
            outputRichTextBox.Text += "->Assign cost of all node to infinite.\n";
            foreach(Node node in graph.nodes)
            {
                node.cost = Constants.infinite;
                node.parent = null;
            }
            outputRichTextBox.Text += "->Assign cost of start node "+start.name+" to 0.\n";
            start.cost = 0;
            outputRichTextBox.Text += "->Next steps will perform loops to find lowest cost from start to all other node.\n";
            costMatrix[0, Int32.Parse(start.name)] = 0;
        }
        public override void nextStep()
        {
            if (found || noPath) return;
            base.nextStep();
            if (presentNode != null) presentNode.present = false;
            outputRichTextBox.Text += "->Looping....\n";
            Line line;
            for (; loop1 < graph.nodes.Count; loop1++)
            {
                for (; loop2 < graph.lines.Count; loop2++)
                {
                    line = graph.lines[loop2];
                    if (line.end.cost > (line.begin.cost + line.cost))
                    {
                        line.end.cost = line.begin.cost + line.cost;
                        line.end.parent = line.begin;
                        outputRichTextBox.Text += "->Found better path to node " + line.end.name + ",update cost!\n";
                        costMatrix[loop1,Int32.Parse(line.end.name)] = line.end.cost;
                        presentNode = line.end;
                        presentNode.present = true;
                        return;
                    }
                }
                loop2 = 0;
                //loop1++;
                outputRichTextBox.Text += "->Finished " + loop1 + "st loop!\n";
                //break;
            }
            if(loop1==nodeCount)
            {
                outputRichTextBox.Text += "->Completed all loops,get path from maxtrix.\n";
                if(goal.cost==Constants.infinite)
                {
                    outputRichTextBox.Text += "->There is no part to goal!\n";
                    noPath = true;
                }
                else
                {
                    outputRichTextBox.Text += "->Found lowest cost path!\n";
                    presentNode = goal;
                    presentNode.present = true;
                    found = true;
                }
            }
        }
        public override void updateTextBoxs()
        {
            outputOpenTextBox.Text = "Only for DPS,BFS and Djikstra";
            outputCloseTextBox.Text = "Only for DPS,BFS and Djikstra";
            updatePath();
        }
        public override void drawCostMatrix(System.Drawing.Graphics graphics)
        {
            graphics.Clear(Color.Gray);
            int boxWidth = Constants.costMatrixPanelWidth / (nodeCount + 1);
            int boxHeight = Constants.costMatrixPanelHeight / (nodeCount + 1);
            Font indexFont = new Font("Arial", boxWidth / 3);
            Font valueFont = new Font("Arial", boxWidth / 3);
            for (int i = 0; i <= nodeCount + 1; i++)
            {
                graphics.DrawLine(Constants.costMaxtrixLinePen, i * boxWidth, 0, i * boxWidth, Constants.costMatrixPanelHeight);
                graphics.DrawLine(Constants.costMaxtrixLinePen, 0, i * boxHeight, Constants.costMatrixPanelWidth, i * boxHeight);
            }
            for (int i = 1; i < nodeCount + 1; i++)
            {
                graphics.DrawString((i ).ToString(), indexFont, Constants.lineCostBrush, i * boxWidth + boxWidth/2, boxHeight / 2,Constants.stringAlignCenterFormat);
                graphics.DrawString((i - 1).ToString(), indexFont, Constants.lineCostBrush, boxWidth / 2, i * boxHeight + boxHeight/2,Constants.stringAlignCenterFormat);
            }
            for (int i = 1; i < nodeCount + 1; i++)
            {
                for (int j = 1; j < nodeCount + 1; j++)
                {
                    if (costMatrix[i-1,j-1] == Constants.infinite) graphics.DrawString("∞", valueFont, Constants.linePathCostBrush, i * boxWidth + boxWidth/2, j * boxHeight + boxHeight/2,Constants.stringAlignCenterFormat);
                    else
                        graphics.DrawString(costMatrix[i-1,j-1].ToString(), valueFont, Constants.linePathCostBrush, i * boxWidth +boxWidth/2, j * boxHeight + boxHeight/2,Constants.stringAlignCenterFormat);
                }
            }
        }
    }
}
