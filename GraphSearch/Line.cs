using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphSearch
{
    class Line
    {
        public Node begin { get; set; }
        public Node end { get; set; }
        public bool path { get; set; }
        public int cost { get; set; }
        public void draw(Graphics graphics)
        {
            Point start = begin.position, finish = end.position;
            Point mid = new Point((start.X + finish.X) / 2, (start.Y + finish.Y) / 2);
            Point costText = new Point(3*start.X/4 + finish.X/4, 3*start.Y/4 + finish.Y/4);
            if (path)
            {
                graphics.DrawLine(Constants.linePathPen, start, finish);
                graphics.DrawLine(Constants.linePathPen, start, mid);
                //graphics.FillRectangle(Constants.graphPanelBackBrush, costText.X - Constants.costTextPlaceSize / 2, costText.Y - Constants.costTextPlaceSize / 2, Constants.costTextPlaceSize, Constants.costTextPlaceSize);
                //graphics.DrawString(cost.ToString(), Constants.lineCostFont, Constants.linePathCostBrush, costText, Constants.costStringFormat);
            }
            else
            {
                graphics.DrawLine(Constants.linePen, start, finish);
                graphics.DrawLine(Constants.linePen, start, mid);
                //graphics.FillRectangle(Constants.graphPanelBackBrush, costText.X - Constants.costTextPlaceSize / 2, costText.Y - Constants.costTextPlaceSize / 2, Constants.costTextPlaceSize, Constants.costTextPlaceSize);
                //graphics.DrawString(cost.ToString(), Constants.lineCostFont, Constants.lineCostBrush, costText, Constants.costStringFormat);
            }
        }
        public void drawCost(Graphics graphics)
        {
            Point start = begin.position, finish = end.position;
            Point mid = new Point((start.X + finish.X) / 2, (start.Y + finish.Y) / 2);
            Point costText = new Point(3 * start.X / 4 + finish.X / 4, 3 * start.Y / 4 + finish.Y / 4);
            if (path)
            {
                graphics.FillRectangle(Constants.graphPanelBackBrush, costText.X - Constants.costTextPlaceSize / 2, costText.Y - Constants.costTextPlaceSize / 2, Constants.costTextPlaceSize, Constants.costTextPlaceSize);
                graphics.DrawString(cost.ToString(), Constants.lineCostFont, Constants.linePathCostBrush, costText, Constants.stringAlignCenterFormat);
            }
            else
            {
                graphics.FillRectangle(Constants.graphPanelBackBrush, costText.X - Constants.costTextPlaceSize / 2, costText.Y - Constants.costTextPlaceSize / 2, Constants.costTextPlaceSize, Constants.costTextPlaceSize);
                graphics.DrawString(cost.ToString(), Constants.lineCostFont, Constants.lineCostBrush, costText, Constants.stringAlignCenterFormat);
            }
        }
        public Line(Node beginNode,Node endNode)
        {
            begin = beginNode;
            end = endNode;
            cost = 0;
            path = false;
        }
        public Line(Node beginNode, Node endNode,int Cost)
        {
            begin = beginNode;
            end = endNode;
            cost = Cost;
            path = false;
        }
        public bool isEqual(Line line)
        {
            if ((begin == line.begin && end == line.end)) return true;
            return false;
        }
    }
}
