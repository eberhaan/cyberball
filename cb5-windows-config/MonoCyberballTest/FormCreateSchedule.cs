using System;
using System.Windows.Forms;
using Cyberball.Common;

namespace MonoCyberball
{
    public partial class FormCreateSchedule : Form
    {
        private string scheduleName;
        private int playerCount;

        public FormCreateSchedule(int gameMode, CBSchedule cbSchedule = null)
        {
            InitializeComponent();
            txtPlayerCount.Value = gameMode;
            txtPlayerCount.Enabled = false;

            if (cbSchedule != null)
            {
                txtScheduleName.Text = cbSchedule.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtScheduleName.Text.Trim()))
            {
                MessageBox.Show("Schedule name is required.");
                txtScheduleName.Focus();
                return;
            }
            scheduleName = txtScheduleName.Text;
            playerCount = (int) (txtPlayerCount.Value);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        public Tuple<string, int> GetSchedCreationData()
        {
            return new Tuple<string, int>(scheduleName, playerCount);
        }
    }
}