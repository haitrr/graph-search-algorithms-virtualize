using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    public static class Constants
    {
        public static int maxNode=15;
        public static int nodeRadius = 15;
        public static int lineRadius = 0;
        public static Pen nodePen = new Pen(Color.Green);
        public static Pen linePen = new Pen(Color.Yellow,2);
        public static Font nodeNameFont = new Font("Arial", 10);
        public static SolidBrush nodeNameBrush = new SolidBrush(Color.Black);
        public static int minimumDistance = 80;
        public static Color graphPanelBackGroundColor = Color.Gray;
        public static SolidBrush nodeCircleBrush = new SolidBrush(Color.White);
        public static SolidBrush selectingNodeCircleBrush = new SolidBrush(Color.Yellow);
        public static int costInputed;
        public static Font lineCostFont = new Font("Arial",10);
        public static SolidBrush lineCostBrush = new SolidBrush(Color.Blue);
        public static SolidBrush presentNodeBrush = new SolidBrush(Color.Green);
        public static SolidBrush linePathCostBrush = new SolidBrush(Color.Violet);
        public static Pen linePathPen = new Pen(Color.Red, 2);
        public static SolidBrush visitedNodeBrush = new SolidBrush(Color.Brown);
        public static string endLineOutputRichTextBox = "----------------------------------------------------------";
        public static int costMatrixPanelWidth=415;
        public static int costMatrixPanelHeight=355;
        public static Pen costMaxtrixLinePen = new Pen(Color.Black, 1);
        public static int infinite = 999999;
        public static StringFormat stringAlignCenterFormat = new StringFormat();
        public static int costTextPlaceSize;
        public static SolidBrush graphPanelBackBrush = new SolidBrush(graphPanelBackGroundColor);
        public static void init()
        {
            stringAlignCenterFormat.LineAlignment = StringAlignment.Center;
            stringAlignCenterFormat.Alignment = StringAlignment.Center;
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(4, 4);
            linePen.CustomEndCap = bigArrow;
            linePathPen.CustomEndCap = bigArrow;
            costTextPlaceSize = (int)lineCostFont.Size+5;
        }
    }
}
