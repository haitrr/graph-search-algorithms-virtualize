using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSearch
{
    class BreadthFirstSearch:Class1Algorithm
    {
         public BreadthFirstSearch(Graph iGraph,Node iStart,Node iGoal):base(iGraph,iStart,iGoal)
        {

        }
         public override void startSearch()
         {
             base.startSearch();
             outputRichTextBox.Text += "Breadth First Search Algorithm \nBegin :\n";
             toVisitSet.Add(start);
             start.parent = null;
             outputRichTextBox.Text += "->Add start(" + start.name + ") to ToVisit set.\n";
         }
         public override void nextStep()
         {
             if (found || noPath) return;
             base.nextStep();
             if (toVisitSet.Count != 0)
             {
                 if (presentNode != null) presentNode.present = false;
                 presentNode = toVisitSet[0];
                 presentNode.present = true;
                 outputRichTextBox.Text += "->Take the first node(" + presentNode.name + ") from ToVisit set.\n";
                 toVisitSet.RemoveAt(0);
                 if (presentNode == goal)
                 {
                     outputRichTextBox.Text += "Found goal!\n";
                     found = true;
                     return;
                 }
                 else
                 {
                     outputRichTextBox.Text += "->This node is not goal,add it to Visited set.\n";
                     visitedSet.Add(presentNode);
                     presentNode.visited = true;
                     foreach (Node node in presentNode.childs)
                     {
                         if (!visitedSet.Contains(node) && !toVisitSet.Contains(node))
                         {
                             outputRichTextBox.Text += "->Node " + node.name + " is a child of this node an not visited,add it to end of ToVisit set.\n";
                             node.parent = presentNode;
                             toVisitSet.Add(node);
                         }
                     }
                 }
             }
             else
             {
                 outputRichTextBox.Text += "No node available to visit => there is part to goal!\n";
                 noPath = true;
             }
         }
    }
}
