using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class Node
    {
        public string name { get; private set; }
        public Point position { get; set; }
        public List<Node> childs { get; private set; }
        public Node parent {get;set;}
        public int cost { get; set; }
        public bool selecting;
        public bool present;
        public bool visited;
        public void draw(Graphics graphics)
        {
            if (selecting) graphics.FillEllipse(Constants.selectingNodeCircleBrush, position.X - Constants.nodeRadius, position.Y - Constants.nodeRadius, Constants.nodeRadius*2, Constants.nodeRadius*2);
            else
                if (present) graphics.FillEllipse(Constants.presentNodeBrush, position.X - Constants.nodeRadius, position.Y - Constants.nodeRadius, Constants.nodeRadius*2, Constants.nodeRadius*2);
                else
                    if (visited) graphics.FillEllipse(Constants.visitedNodeBrush, position.X - Constants.nodeRadius, position.Y - Constants.nodeRadius, Constants.nodeRadius*2, Constants.nodeRadius*2);
                    else
                        graphics.FillEllipse(Constants.nodeCircleBrush, position.X - Constants.nodeRadius, position.Y - Constants.nodeRadius, Constants.nodeRadius*2, Constants.nodeRadius*2);
            graphics.DrawEllipse(Constants.nodePen, position.X - Constants.nodeRadius, position.Y - Constants.nodeRadius, Constants.nodeRadius*2, Constants.nodeRadius*2);
            graphics.DrawString(name, Constants.nodeNameFont, Constants.nodeNameBrush,position.X,position.Y,Constants.stringAlignCenterFormat);
        }
        public Node(Point newNodePosition,string newNodeName)
        {
            position = newNodePosition;
            name = newNodeName;
            childs = new List<Node>();
            selecting = false;
            parent = null;
            visited = false;
            cost = 999999;
        }
        public void addChild(Node node)
        {
            childs.Insert(0, node);
        }
    }
}
