using System;
using System.Windows.Forms;
using Cyberball.Common;

namespace MonoCyberball
{
    public partial class FormThrowProperties : Form
    {
        public FormThrowProperties(CBThrow cbThrow, string throwFrom)
        {
            InitializeComponent();
            lblThrowFrom.Text = throwFrom;
            lblThrowTo.Text = cbThrow.ThrowTo;
            lblDelay.Text = cbThrow.Delay.ToString();

            this.Text = "Throw Details";
        }

        private void BtnCloseThrowClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}