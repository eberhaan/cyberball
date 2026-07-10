using System;
using System.Windows.Forms;
using Cyberball.Common;

namespace MonoCyberball
{
    public partial class FormMessageProperties : Form
    {
        public FormMessageProperties(CBMessage cbMessage)
        {
            InitializeComponent();
            lblFrom.Text = "Player " + cbMessage.sender;
            txtMessage.Text = cbMessage.message;
            lblDuration.Text = cbMessage.duration.ToString();
        }


        private void FormAddMessage_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}