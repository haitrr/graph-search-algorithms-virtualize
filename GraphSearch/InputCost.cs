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
    public partial class InputCost : Form
    {
        public InputCost()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MaximizeBox = false;
            Random random=new Random();
            costInputTextbox.Text = random.Next(1,50).ToString();
        }
        public void costTextboxKeyPressHandle(object sender,KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                costOkButton.PerformClick();
                e.Handled = true;
            }
            else
            e.Handled = !char.IsDigit(e.KeyChar);
        }
        public void OkButtonClicked(object sender,MouseEventArgs e)
        {
            if (costInputTextbox.Text != "")
            {
                Constants.costInputed = Int32.Parse(costInputTextbox.Text);
                Close();
            }
        }

        private void costOkButtonClicked(object sender, EventArgs e)
        {
            if (costInputTextbox.Text != "")
            {
                Constants.costInputed = Int32.Parse(costInputTextbox.Text);
                Close();
            }
        }
    }
}
