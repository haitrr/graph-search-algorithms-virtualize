using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Djikstra:Class1Algorithm
    {
        public  Djikstra(Graph iGraph,Node iStart,Node iGoal):base(iGraph,iStart,iGoal)
        {

        }
        public override void startSearch()
        {
            base.startSearch();
            outputRichTextBox.Text += "Djikstra's Algorithm! \nBegin :\n";
            start.cost = 0;
            toVisitSet.Add(start);
            start.parent = null;
            outputRichTextBox.Text += "Add start(" + start.name + ") to ToVisit set.\n";
        }
        public override void nextStep()
        {
            if (found || noPath) return;
            base.nextStep();
            if (toVisitSet.Count != 0)
            {
                if (presentNode != null) presentNode.present = false;
                presentNode = getLowestCostNode();
                presentNode.present = true;
                outputRichTextBox.Text += "->Take the lowest cost node(" + presentNode.name + ") from ToVisit set.\n";
                toVisitSet.Remove(presentNode);
                if (presentNode == goal)
                {
                    outputRichTextBox.Text += "Found goal!\n";
                    found = true;
                    return;
                }
                outputRichTextBox.Text += "->This node is not goal,add it to Visited set.\n";
                visitedSet.Add(presentNode);
                presentNode.visited = true;
                foreach (Node node in presentNode.childs)
                {
                    if (!visitedSet.Contains(node))
                    {
                        if (!toVisitSet.Contains(node))
                        {
                            outputRichTextBox.Text += "->Node " + node.name + " is a child of present node an not visited,add it to ToVisit set.\n";
                            node.parent = presentNode;
                            node.cost = presentNode.cost + getCost(presentNode, node);
                            toVisitSet.Insert(0, node);
                        }
                        else
                        {
                            if (node != start && node.cost > (presentNode.cost + getCost(presentNode, node)))
                            {
                                node.cost = presentNode.cost + getCost(presentNode, node);
                                node.parent = presentNode;
                                outputRichTextBox.Text += "->Found better path to node " + node.name + ",update it's cost!\n";
                            }
                        }
                    }
                    else
                    {
                        if (node != start && node.cost > (presentNode.cost + getCost(presentNode, node)))
                        {
                            node.cost = presentNode.cost + getCost(presentNode, node);
                            visitedSet.Remove(node);
                            toVisitSet.Add(node);
                            node.visited = false;
                            node.parent = presentNode;
                            outputRichTextBox.Text += "->Found better path to node " + node.name + ",update it's cost,remove it from Visited set,add it back to ToVisit set";
                        }

                    }

                }
            }
            else
            {
                outputRichTextBox.Text += "No node available to visit => there is no part to goal!\n";
                noPath = true;
            }
        }
        public override void drawCostMatrix(System.Drawing.Graphics graphics)
        {
            graphics.Clear(Color.Gray);
            int boxWidth = Constants.costMatrixPanelWidth / 2;
            int boxHeight = Constants.costMatrixPanelHeight / (toVisitSet.Count + 1);
            Font indexFont = new Font("Arial", boxWidth / 5);
            Font valueFont = new Font("Arial", boxWidth / 5);
            for (int i = 0; i <= toVisitSet.Count + 1; i++)
            {
                graphics.DrawLine(Constants.costMaxtrixLinePen, 0, i * boxHeight, Constants.costMatrixPanelWidth, i * boxHeight);
            }
            for (int i = 0; i <= 2; i++)
            {
                graphics.DrawLine(Constants.costMaxtrixLinePen, i * boxWidth, 0, i * boxWidth, Constants.costMatrixPanelHeight);
            }
            for (int i = 1; i < toVisitSet.Count + 1; i++)
            {
                graphics.DrawString(toVisitSet[i-1].name.ToString(), indexFont, Constants.lineCostBrush, boxWidth/2, i*boxHeight+boxHeight/2,Constants.stringAlignCenterFormat);
            }
            graphics.DrawString("Node", indexFont, Constants.lineCostBrush, boxWidth / 2, boxHeight/2,Constants.stringAlignCenterFormat);
            graphics.DrawString("Cost", indexFont, Constants.lineCostBrush, boxWidth+boxWidth / 2, boxHeight/2,Constants.stringAlignCenterFormat);
            for (int i = 1; i < toVisitSet.Count + 1; i++)
            {
                    if (toVisitSet[i-1].cost == Constants.infinite) graphics.DrawString("∞", valueFont, Constants.linePathCostBrush, boxWidth +boxWidth/2, i*boxHeight + boxHeight/2,Constants.stringAlignCenterFormat);
                    else
                        graphics.DrawString(toVisitSet[i-1].cost.ToString(), valueFont, Constants.linePathCostBrush, boxWidth + boxWidth/2, i*boxHeight+boxHeight/2,Constants.stringAlignCenterFormat);
            }
        }
        public Node getLowestCostNode()
        {
            int minCost = Constants.infinite;
            Node chose = null;
            foreach (Node node in toVisitSet)
            {
                if (node.cost < minCost)
                {
                    minCost = node.cost;
                    chose = node;
                }
            }
            return chose;
        }
    }
}
