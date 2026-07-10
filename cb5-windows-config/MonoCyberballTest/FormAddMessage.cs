using System;
using System.Linq;
using System.Windows.Forms;
using Cyberball.Common;

namespace MonoCyberball
{
    public partial class FormAddMessage : Form
    {
        private CBMessage msg;
        private int _numplayers;

        public FormAddMessage(int numPlayers)
        {
            InitializeComponent();
            _numplayers = numPlayers;
            for (int i = 1; i <= _numplayers; i++)
            {
                if (i == 2) continue;
                ddlFrom.Items.Add("Player " + i);
            }
        }

        public FormAddMessage(int numPlayers, CBMessage cbMessage) : this(numPlayers)
        {
            txtMessage.Text = cbMessage.message;

            if (cbMessage.sender != 0)
                ddlFrom.SelectedItem = "Player " + cbMessage.sender;
            else
                ddlFrom.SelectedIndex = 0; // Experimenter

            txtMessageDuration.Value = cbMessage.duration <= 0 ? 1 : cbMessage.duration;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlFrom.SelectedIndex == -1)
            {
                MessageBox.Show("Please assign the message to a player or set it as an Instruction");
                ddlFrom.Focus();
                return;
            }

            var messageSender = 0;// 0 = sent by the experimenter. i.e. this is an instruction
            int.TryParse(ddlFrom.SelectedItem.ToString().Last().ToString(), out messageSender);
           
            msg = new CBMessage
            {
                message = txtMessage.Text,
                sender = messageSender,
                duration = txtMessageDuration.Value
            };
            this.DialogResult = DialogResult.OK;
        }

        public CBMessage GetCreatedMessage()
        {
            return msg;
        }

        private void FormAddMessage_Load(object sender, EventArgs e)
        {
        }
    }
}