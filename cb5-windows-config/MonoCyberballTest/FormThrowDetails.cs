using System;
using System.Windows.Forms;
using Cyberball.Common;

namespace MonoCyberball
{
    public partial class FormThrowDetails : Form
    {
        private CBThrow throwDetails = new CBThrow();

        public FormThrowDetails(CBThrow cbThrow, string gameMode, string throwFrom)
        {
            InitializeComponent();
            var numPlayers = int.Parse(gameMode[0].ToString());

            if (throwFrom.Contains("Player 2"))
            {
                ddlThrowTo.Items.Add("Any");
                ddlThrowTo.SelectedIndex = 0;
                ddlThrowTo.Enabled = false;
                txtThrowDelay.Enabled = false;
                txtThrowName.Text = "Human Throw";
                cbThrowDelayed.Enabled = false;
            }
            else
            {
                for (var i = 1; i <= numPlayers; i++)
                {
                    if (throwFrom.Contains(i.ToString()))
                        continue;
                    if (i == 2)
                    {
                        ddlThrowTo.Items.Add("Player " + (i) + " (Human)");
                    }
                    else
                        ddlThrowTo.Items.Add("Player " + (i));
                }
                if (cbThrow.Delay > 0)
                {
                    cbThrowDelayed.Checked = true;
                }
            }
            if (cbThrow.ThrowTo == null)
            {
                btnUpdateThrow.Text = "Create Throw";
            }
            else
            {
                ddlThrowTo.SelectedItem = cbThrow.ThrowTo;
                //ddlThrowTo.Enabled = false;
            }

            lblThrowFrom.Text = throwFrom;
            txtThrowDelay.Value = cbThrow.Delay;
            txtThrowName.Text = cbThrow.ThrowName;
            throwDetails = cbThrow;
        }

        private void btnUpdateThrow_Click(object sender, EventArgs e)
        {
            if (ddlThrowTo.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a 'ThrowTo' to Create Throw.");
                return;
            }
            var targetPlayer = ddlThrowTo.SelectedItem.ToString();

            if (cbThrowDelayed.Checked)
                throwDetails.Delay = (int) txtThrowDelay.Value;
            else
                throwDetails.Delay = 0;

            throwDetails.ThrowTo = targetPlayer;
            throwDetails.ThrowName = txtThrowName.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        public CBThrow GetThrowDetails()
        {
            return throwDetails;
        }

        private void txtThrowDelay_ValueChanged(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void txtThrowName_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lblThrowFrom_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void ddlThrowTo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbThrowDelayed_CheckedChanged(object sender, EventArgs e)
        {
            txtThrowDelay.Enabled = cbThrowDelayed.Checked;
            if (!cbThrowDelayed.Checked)
                txtThrowDelay.Value = 0;
        }

        private void FormThrowDetails_Load(object sender, EventArgs e)
        {
        }
    }
}