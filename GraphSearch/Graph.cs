using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
namespace GraphSearch
{
    class Graph
    {
        public List<Node> nodes { get; private set; }
        public List<Line> lines { get; set; }
        public Node selectingNode { get; private set; }
        public Graph()
        {
            nodes = new List<Node>();
            lines = new List<Line>();
        }
        public void draw(Graphics graphics)
        {
            graphics.Clear(Constants.graphPanelBackGroundColor);
            foreach (Line line in lines) if (!line.path) line.draw(graphics);
            foreach (Line line in lines) if (line.path) line.draw(graphics);
            foreach (Line line in lines) line.drawCost(graphics);
            foreach (Node node in nodes) node.draw(graphics);
        }
        public bool addNode(Point newNodePosition)
        {
            if (nodes.Count == Constants.maxNode) return false;
            foreach(Node node in nodes)
            {
                if (Math.Abs(node.position.X - newNodePosition.X) < Constants.minimumDistance && Math.Abs(node.position.Y - newNodePosition.Y) < Constants.minimumDistance) return false;
            }
            Node newNode = new Node(newNodePosition, (nodes.Count).ToString());
            nodes.Add(newNode);
            return true;
        }
        public bool selectNode(Point nodePosition)
        {
            foreach(Node node in nodes)
            {
                if (Math.Abs(node.position.X - nodePosition.X) < Constants.nodeRadius && Math.Abs(node.position.Y - nodePosition.Y) < Constants.nodeRadius)
                {
                    selectingNode = node;
                    node.selecting = true;
                    return true;
                }
            }
            return false;
        }
        public Line addLine(Point nodePosition)
        {

            foreach (Node node in nodes)
            {
                if (Math.Abs(node.position.X - nodePosition.X) < Constants.nodeRadius && Math.Abs(node.position.Y - nodePosition.Y) < Constants.nodeRadius)
                {
                    if(node!=selectingNode)
                    {
                        Line newLine = new Line(selectingNode, node);
                        foreach(Line line in lines)
                        {
                            if(line.isEqual(newLine)) 
                            {
                                unselectNode();
                                return null;
                            }
                        }
                        selectingNode.addChild(node);
                        //node.addChild(selectingNode);
                        lines.Add(newLine);
                        unselectNode();
                        return newLine;
                    }
                }
            }
            unselectNode();
            return null;
        }
        public void unselectNode()
        {
            selectingNode.selecting = false;
            selectingNode = null;
        }
        public void drawPath(Graphics g)
        {

        }
        public void openGraphFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string temp;
            while(!reader.EndOfStream)
            {
                temp=reader.ReadLine();
                if (temp == "<Node>")
                {
                    temp = reader.ReadLine();
                    while (temp != "<Node>")
                    {
                        string[] tempArray = temp.Split(' ');
                        nodes.Add(new Node(new Point(Int32.Parse(tempArray[0]), Int32.Parse(tempArray[1])), (nodes.Count).ToString()));
                        temp = reader.ReadLine();
                    }
                }
                if(temp=="<Line>")
                {
                    temp = reader.ReadLine();
                    while (temp != "<Line>")
                    {
                        string[] tempArray = temp.Split(' ');
                        int begin, end, cost;
                        begin = Int32.Parse(tempArray[0]);
                        end = Int32.Parse(tempArray[1]);
                        cost = Int32.Parse(tempArray[2]);
                        nodes[begin].childs.Add(nodes[end]);
                        //nodes[end - 1].childs.Add(nodes[begin - 1]);
                        lines.Add(new Line(nodes[begin], nodes[end], cost));
                        temp = reader.ReadLine();
                    }
                }
            }
            reader.Close();
        }

        public void saveGraphToFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            string temp;
            writer.WriteLine("<Node>");
            foreach(Node node in nodes)
            {
                temp=node.position.X.ToString()+" "+node.position.Y.ToString();
                writer.WriteLine(temp);
            }
            writer.WriteLine("<Node>");
            writer.WriteLine("<Line>");
            foreach(Line line in lines)
            {
                temp = line.begin.name + " " + line.end.name + " " + line.cost.ToString();
                writer.WriteLine(temp);
            }
            writer.WriteLine("<Line>");
            writer.Close();
        }
    }
}
