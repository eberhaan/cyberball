using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cyberball.Common;
using MonoCyberball.Properties;
using System.IO;

namespace MonoCyberball
{
    public partial class FormNamesColors : Form
    {
        private readonly List<PlayerNamesColors> _playerNamesColors;
        private int _playerCount;

        public FormNamesColors(List<PlayerNamesColors> playerNamesColors, int playerCount)
        {
            _playerNamesColors = playerNamesColors;
            _playerCount = playerCount;
            InitializeComponent();

            for (int i = 1; i <= playerCount; i++)
            {
                var txtName = (TextBox) this.Controls.Find("textbox" + i, true)[0];
                txtName.Enabled = true;
                txtName.Text = _playerNamesColors[i - 1].PlayerName;

                var colorBtn = (Button) this.Controls.Find("button" + i, true)[0];
                colorBtn.Enabled = true;
                colorBtn.BackColor = ColorTranslator.FromHtml(_playerNamesColors[i - 1].PlayerColor);

                var pb = (PictureBox) this.Controls.Find("pictureBox" + i, true)[0];
                pb.Enabled = true;
                if (string.IsNullOrEmpty(playerNamesColors[i - 1].PlayerPic) ||
                    !File.Exists(playerNamesColors[i - 1].PlayerPic))
                    pb.Image = (Image) Resources.ResourceManager.GetObject("profile pic 128");
                else
                    pb.Image = Image.FromFile(playerNamesColors[i - 1].PlayerPic);
                pb.Refresh();
            }
        }

        public List<PlayerNamesColors> GetPlayersDetails()
        {
            return _playerNamesColors;
        }

        private string OpenPicture(PictureBox picBox, string playerPic)
        {
            if (dialogOpenPicture.ShowDialog() == DialogResult.OK)
            {
                picBox.Image = Image.FromFile(dialogOpenPicture.FileName);
                picBox.Refresh();
                return dialogOpenPicture.FileName;
            }
            else
                return playerPic;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _playerNamesColors[0].PlayerPic = OpenPicture(pictureBox1, _playerNamesColors[0].PlayerPic);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _playerNamesColors[1].PlayerPic = OpenPicture(pictureBox2, _playerNamesColors[1].PlayerPic);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _playerNamesColors[2].PlayerPic = OpenPicture(pictureBox3, _playerNamesColors[2].PlayerPic);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            _playerNamesColors[3].PlayerPic = OpenPicture(pictureBox4, _playerNamesColors[3].PlayerPic);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _playerNamesColors[4].PlayerPic = OpenPicture(pictureBox5, _playerNamesColors[4].PlayerPic);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            _playerNamesColors[5].PlayerPic = OpenPicture(pictureBox6, _playerNamesColors[5].PlayerPic);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            _playerNamesColors[6].PlayerPic = OpenPicture(pictureBox7, _playerNamesColors[6].PlayerPic);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            _playerNamesColors[7].PlayerPic = OpenPicture(pictureBox8, _playerNamesColors[7].PlayerPic);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            _playerNamesColors[8].PlayerPic = OpenPicture(pictureBox9, _playerNamesColors[8].PlayerPic);
        }

        private string ChangeColor(Button btn, string playerColor)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = colorDialog.Color;
                return ColorTranslator.ToHtml(Color.FromArgb(255, colorDialog.Color));
            }
            else
            {
                return playerColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _playerNamesColors[0].PlayerColor = ChangeColor(button1, _playerNamesColors[0].PlayerColor);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _playerNamesColors[1].PlayerColor = ChangeColor(button2, _playerNamesColors[1].PlayerColor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _playerNamesColors[2].PlayerColor = ChangeColor(button3, _playerNamesColors[2].PlayerColor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _playerNamesColors[3].PlayerColor = ChangeColor(button4, _playerNamesColors[3].PlayerColor);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _playerNamesColors[4].PlayerColor = ChangeColor(button5, _playerNamesColors[4].PlayerColor);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _playerNamesColors[5].PlayerColor = ChangeColor(button6, _playerNamesColors[5].PlayerColor);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _playerNamesColors[6].PlayerColor = ChangeColor(button7, _playerNamesColors[6].PlayerColor);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _playerNamesColors[7].PlayerColor = ChangeColor(button8, _playerNamesColors[7].PlayerColor);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _playerNamesColors[8].PlayerColor = ChangeColor(button9, _playerNamesColors[8].PlayerColor);
        }

        private void FormNamesColors_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 1; i <= _playerCount; i++)
            {
                var txtName = (TextBox) this.Controls.Find("textbox" + i, true)[0];
                _playerNamesColors[i - 1].PlayerName = txtName.Text;
            }
        }

        private void FormNamesColors_Load(object sender, EventArgs e)
        {
        }
    }
}