namespace GraphSearch
{
    partial class InputCost
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
            this.costInputTextbox = new System.Windows.Forms.TextBox();
            this.costLable = new System.Windows.Forms.Label();
            this.costOkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // costInputTextbox
            // 
            this.costInputTextbox.Location = new System.Drawing.Point(86, 30);
            this.costInputTextbox.Name = "costInputTextbox";
            this.costInputTextbox.Size = new System.Drawing.Size(100, 20);
            this.costInputTextbox.TabIndex = 0;
            this.costInputTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.costTextboxKeyPressHandle);
            // 
            // costLable
            // 
            this.costLable.AutoSize = true;
            this.costLable.Location = new System.Drawing.Point(116, 9);
            this.costLable.Name = "costLable";
            this.costLable.Size = new System.Drawing.Size(28, 13);
            this.costLable.TabIndex = 1;
            this.costLable.Text = "Cost";
            // 
            // costOkButton
            // 
            this.costOkButton.Location = new System.Drawing.Point(97, 56);
            this.costOkButton.Name = "costOkButton";
            this.costOkButton.Size = new System.Drawing.Size(75, 23);
            this.costOkButton.TabIndex = 2;
            this.costOkButton.Text = "OK";
            this.costOkButton.UseVisualStyleBackColor = true;
            this.costOkButton.Click += new System.EventHandler(this.costOkButtonClicked);
            this.costOkButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OkButtonClicked);
            // 
            // InputCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 88);
            this.Controls.Add(this.costOkButton);
            this.Controls.Add(this.costLable);
            this.Controls.Add(this.costInputTextbox);
            this.Name = "InputCost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Cost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox costInputTextbox;
        private System.Windows.Forms.Label costLable;
        private System.Windows.Forms.Button costOkButton;
    }
}