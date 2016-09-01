namespace GraphSearch
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.clearGraphButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.startNodeComboBox = new System.Windows.Forms.ComboBox();
            this.goalNodeComboBox = new System.Windows.Forms.ComboBox();
            this.startNodeLable = new System.Windows.Forms.Label();
            this.goalNodeLable = new System.Windows.Forms.Label();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.openLable = new System.Windows.Forms.Label();
            this.openTextBox = new System.Windows.Forms.TextBox();
            this.closeTextBox = new System.Windows.Forms.TextBox();
            this.closeLable = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.path = new System.Windows.Forms.Label();
            this.costLable = new System.Windows.Forms.Label();
            this.costTextBox = new System.Windows.Forms.TextBox();
            this.totalCostTextBox = new System.Windows.Forms.TextBox();
            this.totalCostLable = new System.Windows.Forms.Label();
            this.openGraphButton = new System.Windows.Forms.Button();
            this.saveGraphButton = new System.Windows.Forms.Button();
            this.costMatrixPanel = new GraphSearch.DoubleBufferedPanel();
            this.graphPanel = new GraphSearch.DoubleBufferedPanel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(24, 52);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(121, 21);
            this.algorithmComboBox.TabIndex = 1;
            this.algorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.algorithmComboBoxSelectedIndexChanged);
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Location = new System.Drawing.Point(56, 36);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(50, 13);
            this.algorithmLabel.TabIndex = 2;
            this.algorithmLabel.Text = "Algorithm";
            // 
            // clearGraphButton
            // 
            this.clearGraphButton.Location = new System.Drawing.Point(44, 336);
            this.clearGraphButton.Name = "clearGraphButton";
            this.clearGraphButton.Size = new System.Drawing.Size(75, 23);
            this.clearGraphButton.TabIndex = 3;
            this.clearGraphButton.Text = "Clear Graph";
            this.clearGraphButton.UseVisualStyleBackColor = true;
            this.clearGraphButton.Click += new System.EventHandler(this.clearGraphButtonClicked);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 140);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButtonClicked);
            // 
            // nextStepButton
            // 
            this.nextStepButton.Location = new System.Drawing.Point(93, 140);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(75, 23);
            this.nextStepButton.TabIndex = 5;
            this.nextStepButton.Text = "Next Step";
            this.nextStepButton.UseVisualStyleBackColor = true;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButtonClicked);
            // 
            // startNodeComboBox
            // 
            this.startNodeComboBox.FormattingEnabled = true;
            this.startNodeComboBox.Location = new System.Drawing.Point(12, 104);
            this.startNodeComboBox.Name = "startNodeComboBox";
            this.startNodeComboBox.Size = new System.Drawing.Size(75, 21);
            this.startNodeComboBox.TabIndex = 6;
            this.startNodeComboBox.SelectedIndexChanged += new System.EventHandler(this.startAndGoalIndexChanged);
            // 
            // goalNodeComboBox
            // 
            this.goalNodeComboBox.FormattingEnabled = true;
            this.goalNodeComboBox.Location = new System.Drawing.Point(93, 104);
            this.goalNodeComboBox.Name = "goalNodeComboBox";
            this.goalNodeComboBox.Size = new System.Drawing.Size(75, 21);
            this.goalNodeComboBox.TabIndex = 7;
            this.goalNodeComboBox.SelectedIndexChanged += new System.EventHandler(this.startAndGoalIndexChanged);
            // 
            // startNodeLable
            // 
            this.startNodeLable.AutoSize = true;
            this.startNodeLable.Location = new System.Drawing.Point(41, 88);
            this.startNodeLable.Name = "startNodeLable";
            this.startNodeLable.Size = new System.Drawing.Size(29, 13);
            this.startNodeLable.TabIndex = 8;
            this.startNodeLable.Text = "Start";
            // 
            // goalNodeLable
            // 
            this.goalNodeLable.AutoSize = true;
            this.goalNodeLable.Location = new System.Drawing.Point(110, 88);
            this.goalNodeLable.Name = "goalNodeLable";
            this.goalNodeLable.Size = new System.Drawing.Size(29, 13);
            this.goalNodeLable.TabIndex = 9;
            this.goalNodeLable.Text = "Goal";
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Location = new System.Drawing.Point(697, 88);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(199, 280);
            this.outputRichTextBox.TabIndex = 10;
            this.outputRichTextBox.Text = "";
            this.outputRichTextBox.TextChanged += new System.EventHandler(this.outputRichTextBoxTextChanged);
            // 
            // openLable
            // 
            this.openLable.AutoSize = true;
            this.openLable.Location = new System.Drawing.Point(771, 12);
            this.openLable.Name = "openLable";
            this.openLable.Size = new System.Drawing.Size(56, 13);
            this.openLable.TabIndex = 11;
            this.openLable.Text = "ToVisit set";
            // 
            // openTextBox
            // 
            this.openTextBox.Location = new System.Drawing.Point(697, 28);
            this.openTextBox.Name = "openTextBox";
            this.openTextBox.Size = new System.Drawing.Size(199, 20);
            this.openTextBox.TabIndex = 12;
            this.openTextBox.Text = "Only for DPS,BFS and Djikstra";
            // 
            // closeTextBox
            // 
            this.closeTextBox.Location = new System.Drawing.Point(697, 67);
            this.closeTextBox.Name = "closeTextBox";
            this.closeTextBox.Size = new System.Drawing.Size(199, 20);
            this.closeTextBox.TabIndex = 13;
            this.closeTextBox.Text = "Only for DPS,BFS and Djikstra";
            // 
            // closeLable
            // 
            this.closeLable.AutoSize = true;
            this.closeLable.Location = new System.Drawing.Point(771, 51);
            this.closeLable.Name = "closeLable";
            this.closeLable.Size = new System.Drawing.Size(55, 13);
            this.closeLable.TabIndex = 14;
            this.closeLable.Text = "Visited set";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(12, 194);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(156, 20);
            this.pathTextBox.TabIndex = 15;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(71, 178);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(29, 13);
            this.path.TabIndex = 17;
            this.path.Text = "Path";
            // 
            // costLable
            // 
            this.costLable.AutoSize = true;
            this.costLable.Location = new System.Drawing.Point(65, 217);
            this.costLable.Name = "costLable";
            this.costLable.Size = new System.Drawing.Size(28, 13);
            this.costLable.TabIndex = 18;
            this.costLable.Text = "Cost";
            // 
            // costTextBox
            // 
            this.costTextBox.Location = new System.Drawing.Point(12, 233);
            this.costTextBox.Name = "costTextBox";
            this.costTextBox.Size = new System.Drawing.Size(156, 20);
            this.costTextBox.TabIndex = 19;
            // 
            // totalCostTextBox
            // 
            this.totalCostTextBox.Location = new System.Drawing.Point(44, 281);
            this.totalCostTextBox.Name = "totalCostTextBox";
            this.totalCostTextBox.Size = new System.Drawing.Size(75, 20);
            this.totalCostTextBox.TabIndex = 20;
            // 
            // totalCostLable
            // 
            this.totalCostLable.AutoSize = true;
            this.totalCostLable.Location = new System.Drawing.Point(56, 265);
            this.totalCostLable.Name = "totalCostLable";
            this.totalCostLable.Size = new System.Drawing.Size(55, 13);
            this.totalCostLable.TabIndex = 21;
            this.totalCostLable.Text = "Total Cost";
            // 
            // openGraphButton
            // 
            this.openGraphButton.Location = new System.Drawing.Point(12, 307);
            this.openGraphButton.Name = "openGraphButton";
            this.openGraphButton.Size = new System.Drawing.Size(75, 23);
            this.openGraphButton.TabIndex = 22;
            this.openGraphButton.Text = "Open Graph";
            this.openGraphButton.UseVisualStyleBackColor = true;
            this.openGraphButton.Click += new System.EventHandler(this.openGraphButtonClicked);
            // 
            // saveGraphButton
            // 
            this.saveGraphButton.Location = new System.Drawing.Point(93, 307);
            this.saveGraphButton.Name = "saveGraphButton";
            this.saveGraphButton.Size = new System.Drawing.Size(75, 23);
            this.saveGraphButton.TabIndex = 23;
            this.saveGraphButton.Text = "Save Graph";
            this.saveGraphButton.UseVisualStyleBackColor = true;
            this.saveGraphButton.Click += new System.EventHandler(this.saveGraphButtonClicked);
            // 
            // costMatrixPanel
            // 
            this.costMatrixPanel.Location = new System.Drawing.Point(902, 12);
            this.costMatrixPanel.Name = "costMatrixPanel";
            this.costMatrixPanel.Size = new System.Drawing.Size(415, 356);
            this.costMatrixPanel.TabIndex = 24;
            this.costMatrixPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.costMatrixPanelPaint);
            // 
            // graphPanel
            // 
            this.graphPanel.ForeColor = System.Drawing.Color.Gray;
            this.graphPanel.Location = new System.Drawing.Point(170, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(521, 356);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graphPanelPaint);
            this.graphPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphPanelClicked);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(44, 10);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 25;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButtonClicked);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 377);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.costMatrixPanel);
            this.Controls.Add(this.saveGraphButton);
            this.Controls.Add(this.openGraphButton);
            this.Controls.Add(this.totalCostLable);
            this.Controls.Add(this.totalCostTextBox);
            this.Controls.Add(this.costTextBox);
            this.Controls.Add(this.costLable);
            this.Controls.Add(this.path);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.closeLable);
            this.Controls.Add(this.closeTextBox);
            this.Controls.Add(this.openTextBox);
            this.Controls.Add(this.openLable);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.goalNodeLable);
            this.Controls.Add(this.startNodeLable);
            this.Controls.Add(this.goalNodeComboBox);
            this.Controls.Add(this.startNodeComboBox);
            this.Controls.Add(this.nextStepButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.clearGraphButton);
            this.Controls.Add(this.algorithmLabel);
            this.Controls.Add(this.algorithmComboBox);
            this.Controls.Add(this.graphPanel);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Searchs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.Button clearGraphButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button nextStepButton;
        private System.Windows.Forms.ComboBox startNodeComboBox;
        private System.Windows.Forms.ComboBox goalNodeComboBox;
        private System.Windows.Forms.Label startNodeLable;
        private System.Windows.Forms.Label goalNodeLable;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.Label openLable;
        private System.Windows.Forms.TextBox openTextBox;
        private System.Windows.Forms.TextBox closeTextBox;
        private System.Windows.Forms.Label closeLable;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label costLable;
        private System.Windows.Forms.TextBox costTextBox;
        private System.Windows.Forms.TextBox totalCostTextBox;
        private System.Windows.Forms.Label totalCostLable;
        private DoubleBufferedPanel graphPanel;
        private System.Windows.Forms.Button openGraphButton;
        private System.Windows.Forms.Button saveGraphButton;
        private DoubleBufferedPanel costMatrixPanel;
        private System.Windows.Forms.Button aboutButton;
    }
}

