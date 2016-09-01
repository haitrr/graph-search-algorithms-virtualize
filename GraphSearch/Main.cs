using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphSearch
{
    public partial class Main : Form
    {
        Graph graph;
        Graphics graphics;
        Algorithm algorithm;
        OpenFileDialog openFileDiaglog;
        SaveFileDialog saveFileDialog;
        public Main()
        {
            InitializeComponent();
            Constants.init();
            graph = new Graph();
            graphPanel.BackColor = Constants.graphPanelBackGroundColor;
            graphics = graphPanel.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            initAlgorithmComboBox();
            nextStepButton.Enabled = false;
            FormBorderStyle=FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            closeTextBox.ReadOnly = true;
            openTextBox.ReadOnly = true;
            outputRichTextBox.ReadOnly = true;
            DoubleBuffered = true;
            openFileDiaglog = new OpenFileDialog();
            openFileDiaglog.Filter = "Graph|*.graph";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Graph|*.graph";
            saveFileDialog.DefaultExt = ".graph";
            pathTextBox.ReadOnly = true;
            costTextBox.ReadOnly = true;
            totalCostTextBox.ReadOnly = true;
            costMatrixPanel.Invalidate();
        }
        public void graphPanelClicked(Object sender,MouseEventArgs e)
        {
            if(startButton.Text=="Cancel")
            {
                MessageBox.Show("You can edit graph while running algoritm !");
            }
            Point clickPosition=new Point(e.X,e.Y);
            if (graph.selectingNode == null)
            {
                if (graph.addNode(clickPosition))
                {
                    startNodeComboBox.Items.Add((graph.nodes.Count-1).ToString());
                    goalNodeComboBox.Items.Add((graph.nodes.Count-1).ToString());
                    drawPanels();
                }
                else
                {
                    if (graph.selectNode(clickPosition)) drawPanels();
                }
            }
            else
            {
                Line newLine=graph.addLine(clickPosition);
                if(newLine!=null)
                {
                    InputCost inputCostForm = new InputCost();
                    inputCostForm.ShowDialog();
                    newLine.cost = Constants.costInputed;
                }
                drawPanels();
            }
        }
        public void graphPanelPaint(Object sender,PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graph.draw(e.Graphics);
        }

        private void startButtonClicked(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                if (algorithmComboBox.SelectedIndex >= 0 && graph.nodes.Count > 2 && startNodeComboBox.SelectedIndex >= 0 && goalNodeComboBox.SelectedIndex >= 0 && startNodeComboBox.SelectedIndex != goalNodeComboBox.SelectedIndex)
                {

                    switch (algorithmComboBox.SelectedIndex)
                    {
                        case 0: algorithm = new DepthFirstSearch(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]); break;
                        case 1: algorithm = new BreadthFirstSearch(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]); break;
                        case 2: algorithm = new Djikstra(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]); break;
                        case 3: algorithm = new Floyd(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]); break;
                        case 4: algorithm = new FordBellman(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]); break;
                    }
                    assignOutputTextBoxs();
                    algorithm.startSearch();
                    algorithm.updateTextBoxs();
                    nextStepButton.Enabled = true;
                    //startButton.Enabled = false;
                    startButton.Text = "Cancel";
                    drawPanels();

                }
                else
                    MessageBox.Show("Something wrong!");
            }
            else
            {
                algorithm = new Algorithm(graph, graph.nodes[startNodeComboBox.SelectedIndex], graph.nodes[goalNodeComboBox.SelectedIndex]);
                startButton.Text = "Start";
                nextStepButton.Enabled = false;
                drawPanels();
            }
        }
        public void initAlgorithmComboBox()
        {
            algorithmComboBox.Items.Add("DFS");
            algorithmComboBox.Items.Add("BFS");
            algorithmComboBox.Items.Add("Djikstra");
            algorithmComboBox.Items.Add("Floyd");
            algorithmComboBox.Items.Add("Ford-Bellman");
        }
        private void startAndGoalIndexChanged(object sender, EventArgs e)
        {
            costTextBox.Text = "";
            totalCostTextBox.Text = "";
            startButton.Enabled = true;
            nextStepButton.Enabled = false;
            algorithm = new Algorithm(graph, null,null);
            startButton.Text = "Start";
            drawPanels();
        }
        private void algorithmComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            costTextBox.Text = "";
            totalCostTextBox.Text = "";
            startButton.Enabled = true;
            nextStepButton.Enabled = false;
            algorithm = new Algorithm(graph, null, null);
            startButton.Text = "Start";
            drawPanels();
        }
        private void clearGraphButtonClicked(object sender, EventArgs e)
        {
            graph = new Graph();
            startNodeComboBox.Items.Clear();
            goalNodeComboBox.Items.Clear();
            startNodeComboBox.Text = "";
            goalNodeComboBox.Text = "";
            costTextBox.Text = "";
            totalCostTextBox.Text = "";
            startNodeComboBox.SelectedIndex = -1;
            goalNodeComboBox.SelectedIndex = -1;
            drawPanels();
            startButton.Enabled = true;
            nextStepButton.Enabled = false;
        }

        private void nextStepButtonClicked(object sender, EventArgs e)
        {
            algorithm.nextStep();
            algorithm.updateTextBoxs();
            drawPanels();
        }
        public void outputRichTextBoxTextChanged(object sender,EventArgs e)
        {
            outputRichTextBox.SelectionStart = outputRichTextBox.Text.Length;
            outputRichTextBox.ScrollToCaret();
        }
        public void assignOutputTextBoxs()
        {
            algorithm.outputRichTextBox = outputRichTextBox;
            algorithm.outputCloseTextBox = closeTextBox;
            algorithm.outputOpenTextBox = openTextBox;
            algorithm.outputPathTextBox = pathTextBox;
            algorithm.outputCostTextBox = costTextBox;
            algorithm.outputTotalCostTextBox = totalCostTextBox;
        }

        private void openGraphButtonClicked(object sender, EventArgs e)
        {
            if (openFileDiaglog.ShowDialog() == DialogResult.OK)
            {
                clearGraphButton.PerformClick();
                graph.openGraphFromFile(openFileDiaglog.FileName);
                foreach(Node node in graph.nodes)
                {
                    startNodeComboBox.Items.Add(node.name);
                    goalNodeComboBox.Items.Add(node.name);
                }
                drawPanels();
            }
        }

        private void saveGraphButtonClicked(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                graph.saveGraphToFile(saveFileDialog.FileName);
                foreach (Node node in graph.nodes)
                {
                    startNodeComboBox.Items.Add(node.name);
                    goalNodeComboBox.Items.Add(node.name);
                }
                drawPanels();
            }
        }

        private void costMatrixPanelPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (algorithm != null) algorithm.drawCostMatrix(e.Graphics);
            else
            {
                e.Graphics.Clear(Color.DarkGray);
                Font font = new Font("Arial", Constants.costMatrixPanelWidth / 35);
                e.Graphics.DrawString("Only for Djikstra, Floyd and Ford-Bellman algorithm!", font, Constants.nodeNameBrush, Constants.costMatrixPanelWidth / 2, Constants.costMatrixPanelHeight / 2, Constants.stringAlignCenterFormat);
            }
        }
        public void drawPanels()
        {
            costMatrixPanel.Invalidate();
            graphPanel.Invalidate();
        }

        private void aboutButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Graph Search Algorithm Visualization V1.0\nCreator: vroyibg@gmail.com");
        }
    }
}
