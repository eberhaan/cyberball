using MonoCyberballTest;
using System;
using System.IO;
using System.Windows.Forms;

namespace MonoCyberball
{
    public partial class FormGetCBEID : Form
    {
        public Guid inputValue;

        public FormGetCBEID()
        {
            InitializeComponent();
        }

        public FormGetCBEID(Guid cbeID)
        {
            InitializeComponent();
            var mycbesfile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + Form1.CBFILES_FOLDER_NAME + @"/mycbes.csv";
            if(File.Exists(mycbesfile))
            {
                foreach (var cb in File.ReadAllLines(mycbesfile))
                {
                    ddlCBEs.Items.Add(cb.Split(',')[0]);
                }
            }
        }

        private void FormGetCBEID_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int cbeId;
            Guid parsedGUID;
            bool isValidGUID = Guid.TryParse(ddlCBEs.Text, out parsedGUID);
            if (string.IsNullOrEmpty(ddlCBEs.Text) || !isValidGUID)
            {
                MessageBox.Show("Please select / enter a valid cbe-id");
                return;
            }
            DialogResult = DialogResult.OK;
            inputValue = parsedGUID;
            Close();
        }
    }
}