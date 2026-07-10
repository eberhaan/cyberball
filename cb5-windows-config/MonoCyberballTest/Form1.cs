using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Cyberball.Common;
using MonoCyberball;
using MonoCyberball.Properties;

namespace MonoCyberballTest
{
    public partial class Form1 : Form
    {
        public const string CBFILES_FOLDER_NAME = @"\cb-files";
      // private const string SERVICE_BASE_URL = "http://localhost:50350/";
        //private const string SERVICE_BASE_URL = "https://cb5service.azurewebsites.net/";

        //LIVE URL
        private const string SERVICE_BASE_URL = "https://cyberballserver.azurewebsites.net/";

        //Omkars Azure space for testing
        //private const string SERVICE_BASE_URL = "https://cb5jd.azurewebsites.net/";

        private List<CBSchedule> schedules;
        private CBConfig configToSave;
        private bool shouldGenerateSched;

        public Form1()
        {
            //dgNamesColors.DataSource = playerNamesColors;

            InitializeComponent();

        }

        private CBConfig currentConfig;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(mycbesfile))
                {
                    File.ReadAllText(mycbesfile);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("To run Cyberball or publish “.cbe” files to the server, the \"mycbes.csv\" file must be closed. Please close the \"mycbes.csv\" and restart the application.", "Cyberball 5 - Error reading \"mycbes.csv\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            Text = "Untitled - Cyberball Configuration";
            schedules = new List<CBSchedule>();
            var configFolder = string.Empty;
            currentConfig = new CBConfig();
            //Initialize defaults
            lbConditions.SelectedIndex = 0;

            var emptyPlayerNamesColors = new List<PlayerNamesColors>();
            for (var i = 1; i <= 9; i++)
                emptyPlayerNamesColors.Add(new PlayerNamesColors
                {
                    PlayerNum = ("Player " + i),
                    PlayerName = ("Player " + i),
                    PlayerColor = "#ffffff"
                });
            playerNamesColors = emptyPlayerNamesColors;

            var schedTypes = Enum.GetValues(typeof(ScheduleTypes)).Cast<ScheduleTypes>();
            foreach (ScheduleTypes schedType in schedTypes.OrderBy(st => st.ToString()))
            {
                ddlSchedules.Items.Add(schedType.ToString());
            }
            ddlSchedules.SelectedIndex = 0;
            ddlGameMode.SelectedIndex = 0;
            conditions.Add(new CBCondition("Condition 1"));


            //ReadConfigFile();


            btnBack.Enabled = false;
            cmAboutDetail.Text = Application.ProductVersion;
            cmAboutDetail.Enabled = false;
            cmServerURLToolStripMenuItem.Text = SERVICE_BASE_URL;
            cmServerURLToolStripMenuItem.Enabled = false;

            configFolder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + CBFILES_FOLDER_NAME;
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }
            else
            {
                // Load .cbe file in the cb-files directory if present
                var cbeFiles = Directory.EnumerateFiles(configFolder, "*.cbe", SearchOption.TopDirectoryOnly).ToList();
                if (cbeFiles.Count() == 1)
                {
                    currentFileName = cbeFiles[0];
                    LoadCBEData(cbeFiles[0]);
                }
            }
            ((Control)tabControl1.TabPages[3]).Enabled = false;
        }


        List<PlayerNamesColors> playerNamesColors;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            mnuConditions.Enabled = false;
            if (e.TabPageIndex == 1)
            {
                mnuConditions.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogFilePath.Text))
            {
                dialogLogFile.InitialDirectory = Path.GetDirectoryName(txtLogFilePath.Text);
                dialogLogFile.FileName = Path.GetFileName(txtLogFilePath.Text);
            }
            if (dialogLogFile.ShowDialog() == DialogResult.OK)
            {
                txtLogFilePath.Text = dialogLogFile.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //SaveAndExit();
            SaveCBConfig(currentFileName, true);
        }

        private bool IsInputValid()
        {
            //Throw Count
            if (ddlNoOfThrows.Value <= 0) return false;

            //Log file
            if (!IsLogPathValid()) return false;

            //Config file
            if (!IsConfigPathValid()) return false;


            return true;
        }


        private bool IsConfigPathValid()
        {
            //if (string.IsNullOrEmpty(txtConfigFilePath.Text) || !Directory.Exists(txtConfigFilePath.Text))
            //{
            //    tabControl1.SelectedIndex = 0;
            //    MessageBox.Show("Please select a valid Config File path.");
            //    errorProvider1.SetError(btnConfigFilePath, "Config File path is invalid.");
            //    txtConfigFilePath.Focus();
            //    txtConfigFilePath.SelectAll();
            //    return false;
            //}
            //errorProvider1.Clear();
            return true;
        }

        private bool IsLogPathValid()
        {
            if (string.IsNullOrEmpty(txtLogFilePath.Text.Trim()))
            {
                tabControl1.SelectedIndex = 0;
                MessageBox.Show("Please select the Log file path.");
                errorProvider1.SetError(btnLogPath, "Log File path is invalid.");
                txtLogFilePath.Focus();
                txtLogFilePath.SelectAll();
                return false;
            }
            errorProvider1.Clear();
            return true;
        }

        private void chkRandomAssignment_CheckedChanged(object sender, EventArgs e)
        {
            //if(chkRandomAssignment.Checked)
            //{
            //    btnNext.Enabled = false;
            //    ((Control)tabControl1.TabPages[3]).Visible = false;
            //}
            //else
            //{
            //    btnNext.Enabled = true;
            //    ((Control)tabControl1.TabPages[3]).Visible = true;
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex--;
            btnNext.Enabled = true;
            if (tabControl1.SelectedIndex == 0)
            {
                btnBack.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            btnBack.Enabled = true;
            if (tabControl1.SelectedIndex == (tabControl1.TabCount - 1))
            {
                btnNext.Enabled = false;
            }
        }

        private void ddlSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (conditions.Count == 0) return;
            var isCustomSchedule = false;
            if (ddlSchedules.SelectedItem != null)
                isCustomSchedule = !Enum.IsDefined(typeof(ScheduleTypes), ddlSchedules.SelectedItem.ToString());
            if (!isCustomSchedule)
            {
                conditions[lbConditions.SelectedIndex].ScheduleType =
                    (ScheduleTypes)Enum.Parse(typeof(ScheduleTypes), ddlSchedules.SelectedItem.ToString());
                conditions[lbConditions.SelectedIndex].CustomSchedule = null;
            }
            else
            {
                conditions[lbConditions.SelectedIndex].CustomSchedule =
                    schedules.SingleOrDefault(sch => sch.Name == ddlSchedules.SelectedItem.ToString());
                conditions[lbConditions.SelectedIndex].ScheduleType = null;
            }
            conditions[lbConditions.SelectedIndex].ScheduleName = ddlSchedules.SelectedItem.ToString();
        }


        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveAndExit();
            if (SaveCBConfig(currentFileName))
                Application.Exit();
        }


        private void txtLogFilePath_TextChanged(object sender, EventArgs e)
        {
            // errorProvider1.
        }

        private void ddlGameMode_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private List<CBCondition> conditions = new List<CBCondition>();

        private void btnNewCondition_Click(object sender, EventArgs e)
        {
            CreateNewCondition();
        }

        private void lbConditions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbConditions.SelectedIndex == -1 || ddlSchedules.Items.Count == 0)
                return;

            var cbCondition = conditions[lbConditions.SelectedIndex];

            if (cbCondition.ScheduleType != null)
                ddlSchedules.SelectedItem = cbCondition.ScheduleType.ToString();
            else
            {
                ddlSchedules.SelectedItem = cbCondition.ScheduleName;
            }
            gbConditions.Text = "Details for " + cbCondition.Name;
            txtWelcomeFilePath.Text = cbCondition.WelcomeFilePath;
            txtBGImagePath.Text = cbCondition.BgImagePath;
            txtPEURL.Text = cbCondition.PostExptURL;
            chkSpectate.Checked = cbCondition.ShouldSpectate;
            txtThankyouMsgPath.Text = cbCondition.ThankYouFilePath;
            txtConnectingMessage.Text = cbCondition.CustomConnectingMessage;
        }

        private void txtWelcomeFilePath_TextChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].WelcomeFilePath = txtWelcomeFilePath.Text;
        }

        private void txtBGImagePath_TextChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].BgImagePath = txtBGImagePath.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWelcomeFilePath.Text))
            {
                dialogWelcomeFile.InitialDirectory = Path.GetDirectoryName(txtWelcomeFilePath.Text);
                dialogWelcomeFile.FileName = Path.GetFileName(txtWelcomeFilePath.Text);
            }
            if (dialogWelcomeFile.ShowDialog() == DialogResult.OK)
            {
                txtWelcomeFilePath.Text = dialogWelcomeFile.FileName;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBGImagePath.Text))
            {
                dialogBGImage.InitialDirectory = Path.GetDirectoryName(txtBGImagePath.Text);
                dialogBGImage.FileName = Path.GetFileName(txtBGImagePath.Text);
            }
            if (dialogBGImage.ShowDialog() == DialogResult.OK)
            {
                txtBGImagePath.Text = dialogBGImage.FileName;
            }
        }

        private void mnuConditions_Click(object sender, EventArgs e)
        {
            mnudeleteConditions.Enabled = (lbConditions.SelectedIndex != -1);
        }

        private void mnuCreateConditions_Click(object sender, EventArgs e)
        {
            CreateNewCondition();
        }

        private void mnudeleteConditions_Click(object sender, EventArgs e)
        {
            DeleteSelectedCondition();
        }

        private void RefreshConditions()
        {
            lbConditions.Items.Clear();

            for (var i = 0; i < conditions.Count; i++)
            {
                lbConditions.Items.Add("Condition " + (i + 1));
                conditions[i].Name = "Condition " + (i + 1);
            }
            lbConditions.SelectedIndex = 0;
        }

        private void cmConditions_Opening(object sender, CancelEventArgs e)
        {
            cmConditions.Items.Clear();

            if (lbConditions.SelectedIndex == -1)
            {
                cmConditions.Items.Add("New");
            }
            else
            {
                cmConditions.Items.Add("New");
                cmConditions.Items.Add("Delete");
            }
        }

        private void cmConditions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "New")
                CreateNewCondition();
            else if (e.ClickedItem.Text == "Delete")
            {
                DeleteSelectedCondition();
            }
        }

        private void CreateNewCondition()
        {
            lbConditions.Items.Add("Condition " + (lbConditions.Items.Count + 1));
            conditions.Add(new CBCondition(lbConditions.Items[lbConditions.Items.Count - 1].ToString()));
            RefreshConditions();
            lbConditions.SelectedIndex = lbConditions.Items.Count - 1;
        }

        private void DeleteSelectedCondition()
        {
            if (lbConditions.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a 'Condition' to delete.");
                return;
            }
            if (lbConditions.Items.Count == 1)
            {
                MessageBox.Show("At least one condition is required");
                return;
            }
            conditions.RemoveAt(lbConditions.SelectedIndex);
            lbConditions.Items.RemoveAt(lbConditions.SelectedIndex);
            RefreshConditions();
        }

        private void lbConditions_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //select the item under the mouse pointer
                lbConditions.SelectedIndex = lbConditions.IndexFromPoint(e.Location);

                cmConditions.Show();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCBConfig();
        }

        private string currentFileName;

        private bool OpenCBConfig()
        {
            if (dialogOpenCBE.ShowDialog() == DialogResult.OK)
            {
                currentFileName = dialogOpenCBE.FileName;

                LoadCBEData(currentFileName);
                return true;
            }
            return false;
        }

        private void LoadCBEData(string fileName)
        {
            Text = Path.GetFileName(currentFileName + string.Empty) + " - Cyberball Configuration";
            lbConditions.Items.Clear();

            ddlSchedules.Items.Clear();
            var schedTypes = Enum.GetValues(typeof(ScheduleTypes)).Cast<ScheduleTypes>();
            foreach (ScheduleTypes schedType in schedTypes.OrderBy(st => st.ToString()))
            {
                ddlSchedules.Items.Add(schedType.ToString());
            }
            conditions = new List<CBCondition>();
            conditions.Add(new CBCondition("Condition 1"));
            conditions[0].ScheduleType = ScheduleTypes.IncludeAll;
            conditions[0].ScheduleName = ScheduleTypes.IncludeAll.ToString();

            if (!File.Exists(fileName))
                return;

            //Fix for files which have a saved integer cbeID
            FixIfIntegerCBEID(fileName);


            currentConfig = ConfigIO.ReadConfig(fileName);
            cbeID = currentConfig.ID;
            if (currentConfig != null)
            {
                chkAskID.Checked = currentConfig.AskIDOnGameEnd;
                conditions = currentConfig.Conditions;
                //txtConfigFilePath.Text = currentConfig.configFolderPath;
                ddlGameMode.SelectedItem = currentConfig.GameMode;
                chkChat.Checked = currentConfig.IsChatEnabled;
                txtLogFilePath.Text = currentConfig.LogFilePath;
                playerNamesColors = currentConfig.PlayerDetails;
                chkShowPictures.Checked = currentConfig.ShouldShowPictures;
                chkRandomAssignment.Checked = currentConfig.ShouldHandleRandomAssignment;
                chkStats.Checked = currentConfig.ShouldShowStats;
                ddlNoOfThrows.Value = currentConfig.ThrowCount;
                txtExperimenterEmail.Text = currentConfig.Email;
                switch (currentConfig.RunMode)
                {
                    case CBRunMode.Standalone:
                        rbStandalone.Checked = true;
                        break;
                    case CBRunMode.Medialab:
                        rbMedialab.Checked = true;
                        break;
                    case CBRunMode.Qualtrics:
                        rbQualtrics.Checked = true;
                        break;
                    default:
                        rbStandalone.Checked = true;
                        break;
                }


                conditions = new List<CBCondition>();
                schedules = new List<CBSchedule>();
                foreach (var condition in currentConfig.Conditions)
                {
                    conditions.Add(condition);
                    if (condition.CustomSchedule != null)
                    {
                        if (schedules.Count(s => s.Name == condition.CustomSchedule.Name) == 0)
                        {
                            schedules.Add(condition.CustomSchedule);
                            ddlSchedules.Items.Add(condition.CustomSchedule.Name);
                        }
                    }
                }


                lbConditions.Items.Clear();
                conditions = conditions.OrderBy(st => int.Parse(st.Name.Substring(st.Name.IndexOf(' ') + 1))).ToList();
                foreach (CBCondition cbCondition in conditions)
                {
                    lbConditions.Items.Add(cbCondition.Name);
                }
                if (lbConditions.Items.Count > 0)
                    lbConditions.SelectedIndex = 0;

                if (lbConditions.Items.Count == 1 && string.IsNullOrEmpty(conditions[0].ScheduleName))
                {
                    conditions[0].ScheduleType = ScheduleTypes.IncludeAll;
                    conditions[0].ScheduleName = ScheduleTypes.IncludeAll.ToString();
                }
            }
        }

        private void FixIfIntegerCBEID(string fileName)
        {
            XmlDocument x = new XmlDocument();
            x.Load(fileName);
            XmlNode idNode = x.SelectSingleNode("//CBConfig/ID");
            if (idNode != null) //The ID node is present
            {
                var val = idNode.InnerText + string.Empty;
                Guid cbeIDGuid;
                if (!Guid.TryParse(val.Trim(), out cbeIDGuid)) // Does not already have a GUID
                {
                    idNode.InnerText = Guid.NewGuid().ToString();
                    x.Save(fileName);
                }
            }
        }

        private bool SaveCBConfig(string fileName = "", bool showMessage = false)
        {
            if (!IsInputValid()) return false;
            var playerNos = Convert.ToInt32(ddlGameMode.SelectedItem.ToString().First().ToString());
            if (!IsGameModeValid(playerNos))
            {
                MessageBox.Show("You have a " + playerNos +
                                " player game, but you’ve chosen a schedule of throws for more players. This will not work.");
                return false;
            }

            configToSave = new CBConfig
            {
                AskIDOnGameEnd = chkAskID.Checked,
                GameMode = ddlGameMode.SelectedItem.ToString(),
                IsChatEnabled = chkChat.Checked,
                LogFilePath = txtLogFilePath.Text,
                PlayerDetails = playerNamesColors,
                ShouldShowPictures = chkShowPictures.Checked,
                ShouldHandleRandomAssignment = chkRandomAssignment.Checked,
                ShouldShowStats = chkStats.Checked,
                ThrowCount = (int)ddlNoOfThrows.Value,
                Conditions = conditions,
                RunMode = GetRunMode(),
                ID = cbeID,
                Email = txtExperimenterEmail.Text
            };



            if (string.IsNullOrEmpty(fileName))
            {
                if (dialogSaveCBE.ShowDialog() == DialogResult.OK)
                {
                    ConfigIO.SaveConfig(configToSave, dialogSaveCBE.FileName);
                    currentFileName = dialogSaveCBE.FileName;
                    Text = Path.GetFileName(currentFileName) + " - Cyberball Configuration";
                    if (showMessage)
                        MessageBox.Show("Config " + Path.GetFileName(dialogSaveCBE.FileName) +
                                        " was saved successfully!");
                }
            }
            else
            {
                ConfigIO.SaveConfig(configToSave, fileName);
                if (showMessage)
                    MessageBox.Show("Config " + Path.GetFileName(fileName) + " was saved successfully!");
            }
            return true;
        }

        private void SavePlayerPics(CBConfig configToSave)
        {
            foreach (var player in configToSave.PlayerDetails)
            {
                var requestContent = new MultipartFormDataContent();
                //    here you can specify boundary if you need---^
                Image i;
                var ext = "";
                if (!string.IsNullOrEmpty(player.PlayerPic) && File.Exists(player.PlayerPic))
                    i = Image.FromFile(player.PlayerPic);
                else
                    i = (Image)Resources.ResourceManager.GetObject("profile pic 128");

                i = new Bitmap(i, 128, 128);
                MemoryStream ms = new MemoryStream();
                i.Save(ms, ImageFormat.Jpeg);
                var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                imageContent.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("image/jpeg");

                requestContent.Add(imageContent, "image", "pp-" + player.PlayerNum.Last() + ".jpg");

                //client.PostAsync(url, requestContent);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(SERVICE_BASE_URL);


                HttpResponseMessage response = client.PostAsync("api/images", requestContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    var t = response.Content.ReadAsStringAsync().Result;
                    //MessageBox.Show("Successfully saved.");
                }
                else
                {
                    MessageBox.Show("Error saving on Server" +
                                    response.StatusCode + " : Message - " + response.ReasonPhrase);
                }
            }
        }

        private static void SaveConditionBGs(CBConfig configToSave)
        {
            foreach (var condition in configToSave.Conditions)
            {
                if (!string.IsNullOrEmpty(condition.BgImagePath) && File.Exists(condition.BgImagePath))
                {
                    var requestContent = new MultipartFormDataContent();
                    //    here you can specify boundary if you need---^
                    Image i = Image.FromFile(condition.BgImagePath);
                    MemoryStream ms = new MemoryStream();
                    i.Save(ms, ImageFormat.Jpeg);
                    var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                    imageContent.Headers.ContentType =
                        MediaTypeHeaderValue.Parse("image/jpeg");

                    requestContent.Add(imageContent, "image", condition.BGImageName);

                    //client.PostAsync(url, requestContent);
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(SERVICE_BASE_URL);


                    HttpResponseMessage response = client.PostAsync("api/images", requestContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var t = response.Content.ReadAsStringAsync().Result;
                        //MessageBox.Show("Successfully saved.");
                    }
                    else
                    {
                        MessageBox.Show("Error saving on Server" +
                                        response.StatusCode + " : Message - " + response.ReasonPhrase);
                    }
                }
            }
        }

        public static byte[] ImageToByteArray(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        private void SaveToWeb(CBConfig c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(SERVICE_BASE_URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/cbe", c).Result;

            if (response.IsSuccessStatusCode)
            {
                var t = response.Content.ReadAsStringAsync().Result;
                //MessageBox.Show("Successfully saved.");
            }
            else
            {
                MessageBox.Show("Error saving on Server" +
                                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private CBRunMode GetRunMode()
        {
            if (rbQualtrics.Checked)
                return CBRunMode.Qualtrics;
            if (rbMedialab.Checked)
                return CBRunMode.Medialab;
            return CBRunMode.Standalone;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCBConfig(currentFileName);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCBConfig("", true);
        }

        private void btnCustomizeNamesColors_Click(object sender, EventArgs e)
        {
            using (
                var frmNamesColors = new FormNamesColors(playerNamesColors,
                    int.Parse(ddlGameMode.SelectedItem.ToString()[0].ToString())))
            {
                var frmResult = frmNamesColors.ShowDialog();
            }
        }

        private void btnCustomizeSchedsThrows_Click(object sender, EventArgs e)
        {
            
            using (
                var frmSchedulesThrows = new FormSchedulesThrows(schedules,
                    int.Parse(ddlGameMode.SelectedItem.ToString()[0].ToString()),(int) ddlNoOfThrows.Value))
            {
                var frmResult = frmSchedulesThrows.ShowDialog();
                ddlSchedules.Items.Clear();
                var schedTypes = Enum.GetValues(typeof(ScheduleTypes)).Cast<ScheduleTypes>();
                foreach (ScheduleTypes schedType in schedTypes.OrderBy(st => st.ToString()))
                {
                    ddlSchedules.Items.Add(schedType.ToString());
                }
                foreach (CBSchedule cbSchedule in schedules)
                {
                    ddlSchedules.Items.Add(cbSchedule.Name);
                }
                lbConditions.SelectedIndex = 0;
            }
        }

        private void btnClearConditions_Click(object sender, EventArgs e)
        {
            conditions.Clear();
            lbConditions.Items.Clear();
            conditions.Add(new CBCondition("Condition 1"));
            lbConditions.Items.Add("Condition 1");
            lbConditions.SelectedIndex = 0;
        }

        private void chkSpectate_CheckedChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].ShouldSpectate = chkSpectate.Checked;
        }

        Guid cbeID;

        private async Task SaveOnlineMode()
        {
            var onlineOpsCount = 9; //9 Profile pics for players

            onlineOpsCount += configToSave.Conditions.Count(c => !string.IsNullOrEmpty(c.BgImagePath)); //Condition BGs
            onlineOpsCount += 1; //Main .cbe file


            progressBar1.Minimum = 0;
            progressBar1.Maximum = onlineOpsCount;
            progressBar1.Value = 0;

            //Save the Main CBE
            lblOnlineOpStatus.Text = "Saving .cbe";

            cbeID = Guid.Empty;
            using (var cbeOnlineSaver = new HttpClient())
            {
                //This is only needed for online mode.
                foreach (var item in configToSave.Conditions)
                {
                    if (!string.IsNullOrEmpty(item.ThankYouFilePath) && File.Exists(item.ThankYouFilePath))
                    {
                        item.ThankYouText = File.ReadAllText(item.ThankYouFilePath);
                    }
                    if (!string.IsNullOrEmpty(item.WelcomeFilePath) && File.Exists(item.WelcomeFilePath))
                    {
                        item.WelcomeText = File.ReadAllText(item.WelcomeFilePath);
                    }
                }
                cbeOnlineSaver.BaseAddress = new Uri(SERVICE_BASE_URL);
                cbeOnlineSaver.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await cbeOnlineSaver.PostAsJsonAsync("api/cbe", configToSave);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Could not save .cbe to server\nError Code: " + response.StatusCode);
                    return;
                }
                cbeID = response.Content.ReadAsAsync<Guid>().Result;
                progressBar1.Increment(1);
                lblOnlineOpStatus.Text = "Success saving .cbe!";
            }

            using (var profilePicOnlineSaver = new HttpClient())
            {
                profilePicOnlineSaver.BaseAddress = new Uri(SERVICE_BASE_URL);
                foreach (var player in configToSave.PlayerDetails)
                {
                    var requestContent = new MultipartFormDataContent();
                    Image playerImage;

                    if (!string.IsNullOrEmpty(player.PlayerPic) && File.Exists(player.PlayerPic))
                        playerImage = Image.FromFile(player.PlayerPic);
                    else
                        playerImage = (Image)Resources.ResourceManager.GetObject("profile pic 128");

                    playerImage = new Bitmap(playerImage, 128, 128);
                    MemoryStream ms = new MemoryStream();
                    playerImage.Save(ms, ImageFormat.Jpeg);

                    var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                    imageContent.Headers.ContentType =
                        MediaTypeHeaderValue.Parse("image/jpeg");

                    requestContent.Add(imageContent, "image", "pp-" + player.PlayerNum.Last() + ".jpg");

                    HttpResponseMessage response =
                        await profilePicOnlineSaver.PostAsync("api/images/" + cbeID, requestContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Unable to save " + "pp-" + player.PlayerNum.Last() + ".jpg\nError Code: " +
                                        response.StatusCode);
                    }
                    else
                    {
                        progressBar1.Increment(1);
                        lblOnlineOpStatus.Text = "Success saving " + "pp-" + player.PlayerNum.Last() + ".jpg";
                    }
                }
            }

            using (var bgOnlineSaver = new HttpClient())
            {
                bgOnlineSaver.BaseAddress = new Uri(SERVICE_BASE_URL);
                foreach (var condition in configToSave.Conditions)
                {
                    if (!string.IsNullOrEmpty(condition.BgImagePath) && File.Exists(condition.BgImagePath))
                    {
                        progressBar1.Maximum = ++onlineOpsCount;
                        var requestContent = new MultipartFormDataContent();
                        Image bgImage = Image.FromFile(condition.BgImagePath);
                        bgImage = new Bitmap(bgImage, 1280, 720);
                        MemoryStream ms = new MemoryStream();
                        bgImage.Save(ms, ImageFormat.Jpeg);
                        var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

                        requestContent.Add(imageContent, "image", condition.BGImageName);

                        HttpResponseMessage response =
                            await bgOnlineSaver.PostAsync("api/images/" + cbeID, requestContent);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Unable to save " + condition.BGImageName + "\nError Code: " +
                                            response.StatusCode);
                        }
                        else
                        {
                            progressBar1.Increment(1);
                            lblOnlineOpStatus.Text = "Success saving " + condition.BGImageName;
                        }
                    }
                }
            }

            using (var customBallOnlineSaver = new HttpClient())
            {
                customBallOnlineSaver.BaseAddress = new Uri(SERVICE_BASE_URL);
                foreach (var condition in configToSave.Conditions)
                {
                    if (!string.IsNullOrEmpty(condition.CustomBallImage) && File.Exists(condition.CustomBallImage))
                    {
                        progressBar1.Maximum = ++onlineOpsCount;
                        var requestContent = new MultipartFormDataContent();
                        Image customBallImage = Image.FromFile(condition.CustomBallImage);
                        customBallImage = new Bitmap(customBallImage, 78, 78);
                        MemoryStream ms = new MemoryStream();
                        customBallImage.Save(ms, ImageFormat.Png);
                        var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

                        requestContent.Add(imageContent, "image", condition.Name + "_" + "custom-ball.png");

                        HttpResponseMessage response =
                            await customBallOnlineSaver.PostAsync("api/images/" + cbeID, requestContent);

                        if (!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Unable to save custom-ball.png\nError Code: " +
                                            response.StatusCode);
                        }
                        else
                        {
                            progressBar1.Increment(1);
                            lblOnlineOpStatus.Text = "Success saving custom-ball.png";
                        }
                    }
                }
            }


            //Saving custom cyberguy images

            using (var customCyberguySaver = new HttpClient())
            {
                customCyberguySaver.BaseAddress = new Uri(SERVICE_BASE_URL);
                foreach (var condition in configToSave.Conditions)
                {
                    if (!string.IsNullOrEmpty(condition.CustomBoyImagesFolder) && Directory.Exists(condition.CustomBoyImagesFolder))
                    {
                        onlineOpsCount += 6;
                        progressBar1.Maximum = onlineOpsCount;
                        var fileName = string.Empty;

                        for (int i = 1; i <= 6; i++)
                        {
                            switch (i)
                            {
                                case 1:
                                    fileName = "idle.png";
                                    break;
                                case 2:
                                    fileName = "catch.png";
                                    break;
                                case 3:
                                    fileName = "throw-1.png";
                                    break;
                                case 4:
                                    fileName = "throw-2.png";
                                    break;
                                case 5:
                                    fileName = "throw-3.png";
                                    break;
                                case 6:
                                    fileName = "throw-4.png";
                                    break;
                            }

                            var requestContent = new MultipartFormDataContent();
                            Image customBoyFrame = Image.FromFile(Path.Combine(condition.CustomBoyImagesFolder, fileName));
                            customBoyFrame = new Bitmap(customBoyFrame, 262, 250);
                            MemoryStream ms = new MemoryStream();
                            customBoyFrame.Save(ms, ImageFormat.Png);
                            var imageContent = new ByteArrayContent(ImageToByteArray(Image.FromStream(ms)));
                            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/png");

                            requestContent.Add(imageContent, "image", condition.Name + "_" + fileName);

                            HttpResponseMessage response =
                                await customCyberguySaver.PostAsync("api/images/" + cbeID, requestContent);

                            if (!response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Unable to save " + fileName + "\nError Code: " +
                                                response.StatusCode);
                            }
                            else
                            {
                                progressBar1.Increment(1);
                                lblOnlineOpStatus.Text = "Success saving " + fileName;
                            }
                        }


                    }
                }


            }
            SaveCBConfig(currentFileName);
            MessageBox.Show("Saving online complete");
            progressBar1.Value = 0;
            //WriteTextProgressBar(string.Empty);
            lblOnlineOpStatus.Text = "Successfully saved online";
            UpdateMyCBEs();
        }
        string mycbesfile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + CBFILES_FOLDER_NAME + @"/mycbes.csv";

        private void UpdateMyCBEs()
        {
            string textToWrite = string.Empty;

            if (File.Exists(mycbesfile))
            {
                textToWrite = File.ReadAllText(mycbesfile);
            }

            if (!textToWrite.Contains(cbeID.ToString()))
            {
                textToWrite +=
                    cbeID + "," +
                    configToSave.Conditions.Count + "," +
                    currentFileName + "," +
                    DateTime.Now
                    + "\r\n";
            }

            File.WriteAllText(mycbesfile, textToWrite);
        }

        private void chkRunOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRunOnline.Checked)
            {
                ((Control)tabControl1.TabPages[3]).Enabled = true;
            }
            else
            {
                ((Control)tabControl1.TabPages[3]).Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
            SaveOnlineMode();
        }

        private void WriteTextProgressBar(string message)
        {
            int percent =
                (int)
                    (((progressBar1.Value - progressBar1.Minimum) /
                      (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            progressBar1.Refresh();

            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(message + percent + "%", SystemFonts.DefaultFont, Brushes.Black,
                    new PointF(
                        progressBar1.Width / 2 -
                        (gr.MeasureString(percent + "%", SystemFonts.DefaultFont).Width / 2.0F),
                        progressBar1.Height / 2 -
                        (gr.MeasureString(message + percent + "%", SystemFonts.DefaultFont).Height / 2.0F)),
                    new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OpenCBConfig())
            {
                if (!SaveCBConfig(currentFileName, false)) return;
                //Online conditions must have custom schedules only
                foreach (var c in configToSave.Conditions)
                {
                    if (c.CustomSchedule == null)
                    {
                        MessageBox.Show("Running Cyberball 5 online requires custom schedules for each condition. The .cbe file you tried to publish does not have the required custom schedules.", "Custom Schedule required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                progressBar1.Style = ProgressBarStyle.Blocks;
                SaveOnlineMode();
            }
        }

        private bool IsGameModeValid(int playerNos)
        {
            foreach (var cond in conditions)
            {
                if (cond.CustomSchedule == null || cond.CustomSchedule.throws == null) continue;
                if (
                    cond.CustomSchedule.throws.Where(t => !t.isChatMessage && t.ThrowTo.StartsWith("Player "))
                        .Count(
                            t2 =>
                                Convert.ToInt32(
                                    t2.ThrowTo.ToString().Replace(" (Human)", string.Empty).Last().ToString()) >
                                playerNos) > 0)
                    return false;
            }
            return true;
        }

        private void btnGetLog_Click(object sender, EventArgs e)
        {
            using (var frmLogCBE = new FormGetCBEID(cbeID))
            {
                if (frmLogCBE.ShowDialog() == DialogResult.OK)
                {
                    cbeID = (frmLogCBE.inputValue);
                }
                else
                {
                    return;
                }
            }

            //1.Call api/log/{cbe-id} to get the log file content as string. If no log is present, server will return 404 else 200
            //2. Write it to a file on the desktop. Refer other code to see how to access desktop special folder.
            //3. Show message box stating the file (full path) was retrieved
            GetLogThread();
        }

        private async Task GetLogThread()
        {
            lblOnlineOpStatus.Text = "Fetching log file.";
            btnPublishConfig.Enabled = false;
            btnGetLog.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(SERVICE_BASE_URL);

                HttpResponseMessage response = await client.GetAsync("api/log/" + cbeID);

                string filePath = null;
                if (response.IsSuccessStatusCode)
                {
                    var t = await response.Content.ReadAsStringAsync();

                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\log-cbe-" +
                               cbeID + ".csv";
                    File.WriteAllText(filePath, t);
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    lblOnlineOpStatus.Text = "Log file saved at: " + filePath;
                    var dialogResult =
                        MessageBox.Show("Log file retrieved at: " + filePath + "\nDo you want to open it now?",
                            "Open Log file?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                        Process.Start(filePath);
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Blocks;
                    lblOnlineOpStatus.Text = "Error getting log file";
                    MessageBox.Show("Error getting log file from Server\nError Code: " + response.StatusCode);
                }
                btnPublishConfig.Enabled = !false;
                btnGetLog.Enabled = !false;
            }
        }

        string urlFormat = SERVICE_BASE_URL + "web?cbe={0}&condition={1}&pid={2}";
        private Dictionary<string, int> conditionCountForCBE = new Dictionary<string, int>();

        private void btnGetURL_Click(object sender, EventArgs e)
        {

            conditionCountForCBE = new Dictionary<string, int>();

            var mycbesfile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + CBFILES_FOLDER_NAME + @"/mycbes.csv";


            if (File.Exists(mycbesfile))
            {
                var cbeconditions = File.ReadAllLines(mycbesfile);

                foreach (string s in cbeconditions)
                {
                    var cbe = s.Split(Convert.ToChar(","))[0];
                    var condCount = s.Split(Convert.ToChar(","))[1];
                    conditionCountForCBE.Add(cbe, Convert.ToInt32(condCount));
                }

                gbURLGeneration.Enabled = true;

                ddlCBEs.Items.Clear();
                foreach (string key in conditionCountForCBE.Keys)
                {
                    ddlCBEs.Items.Add(key);
                }
                ddlURLCondition.Items.Clear();
                foreach (var condition in lbConditions.Items)
                {
                    ddlURLCondition.Items.Add(condition);
                }
                ddlCBEs.SelectedIndex = 0;
                ddlURLCondition.SelectedIndex = 0;

                //Select the latest CBE in the dropdown
                if (ddlCBEs.Items.IndexOf(cbeID) >= 0)
                    ddlCBEs.SelectedIndex = ddlCBEs.Items.IndexOf(cbeID);

            }
        }

        private void ddlURLCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateURLText();
        }

        private void UpdateURLText()
        {
            txtURL.Text = string.Format(urlFormat,
                ddlCBEs.Text,
                ddlURLCondition.SelectedItem.ToString()
                    .Substring(ddlURLCondition.SelectedItem.ToString().IndexOf(' ') + 1),
                txtURLParticipantID.Text);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbURLGeneration.Enabled = !true;
        }

        private void txtURLParticipantID_KeyPress(object sender, KeyPressEventArgs e)
        {
            UpdateURLText();
        }

        private void txtURLParticipantID_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateURLText();
        }

        private void txtURL_MouseDown(object sender, MouseEventArgs e)
        {
            txtURL.SelectAll();
        }

        private void btnLaunchURL_Click(object sender, EventArgs e)
        {
            Process.Start(txtURL.Text);
        }

        private void btnCopyURL_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtURL.Text);
        }

        private void ddlCBEs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlURLCondition.Items.Clear();
            for (int i = 1; i <= conditionCountForCBE[ddlCBEs.SelectedItem.ToString()]; i++)
            {
                ddlURLCondition.Items.Add("Condition " + i);
            }
            ddlURLCondition.SelectedIndex = 0;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void btnThankyouMsg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtThankyouMsgPath.Text))
            {
                dialogThankYouFile.InitialDirectory = Path.GetDirectoryName(txtThankyouMsgPath.Text);
                dialogThankYouFile.FileName = Path.GetFileName(txtThankyouMsgPath.Text);
            }
            if (dialogThankYouFile.ShowDialog() == DialogResult.OK)
            {
                txtThankyouMsgPath.Text = dialogThankYouFile.FileName;
            }
        }

        private void txtThankyouMsgPath_TextChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].ThankYouFilePath = txtThankyouMsgPath.Text;
        }

        private void ddlCBEs_TextUpdate(object sender, EventArgs e)
        {
            ddlURLCondition.Items.Clear();

            if (!conditionCountForCBE.ContainsKey(ddlCBEs.Text))
                return;
            for (int i = 1; i <= conditionCountForCBE[ddlCBEs.SelectedItem.ToString()]; i++)
            {
                ddlURLCondition.Items.Add("Condition " + i);
            }
            ddlURLCondition.SelectedIndex = 0;
            UpdateURLText();
        }

        private void newConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to create a new Configuration?", "New Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CreateNewConfig();
            }
        }

        private void CreateNewConfig()
        {
            Text = "Untitled - Cyberball Configuration";
            cbeID = Guid.Empty;
            currentFileName = string.Empty;
            schedules = new List<CBSchedule>();
            conditions = new List<CBCondition>();
            var configFolder = string.Empty;
            currentConfig = new CBConfig();
            //Initialize defaults
            lbConditions.SelectedIndex = 0;


            var emptyPlayerNamesColors = new List<PlayerNamesColors>();
            for (var i = 1; i <= 9; i++)
                emptyPlayerNamesColors.Add(new PlayerNamesColors
                {
                    PlayerNum = ("Player " + i),
                    PlayerName = ("Player " + i),
                    PlayerColor = "#ffffff"
                });
            playerNamesColors = emptyPlayerNamesColors;

            var schedTypes = Enum.GetValues(typeof(ScheduleTypes)).Cast<ScheduleTypes>();
            foreach (ScheduleTypes schedType in schedTypes.OrderBy(st => st.ToString()))
            {
                ddlSchedules.Items.Add(schedType.ToString());
            }
            ddlSchedules.SelectedIndex = 0;
            ddlGameMode.SelectedIndex = 0;
            conditions.Add(new CBCondition("Condition 1"));

            //ReadConfigFile();

            btnBack.Enabled = false;
            cmAboutDetail.Text = Application.ProductVersion;
            cmAboutDetail.Enabled = false;

            ((Control)tabControl1.TabPages[3]).Enabled = false;
        }

        private void txtPEURL_TextChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].PostExptURL = txtPEURL.Text;
        }

        private void btnCustomizeCyberboy_Click(object sender, EventArgs e)
        {
            using (var frmCustomBoy = new FormCustomCyberboy(conditions[lbConditions.SelectedIndex].CustomBallImage, conditions[lbConditions.SelectedIndex].CustomBoyImagesFolder))
            {
                var frmResult = frmCustomBoy.ShowDialog();

                if (frmResult == DialogResult.OK)
                {
                    // Here we get the image file path to use as the custom ball image
                    conditions[lbConditions.SelectedIndex].CustomBallImage = frmCustomBoy.ballImagePath;
                    conditions[lbConditions.SelectedIndex].CustomBoyImagesFolder = frmCustomBoy.cyberguyImagesFolder;
                }
            }
        }

        private void cmAboutDetail_Click(object sender, EventArgs e)
        {

        }

        private void seToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtConnectingMessage_TextChanged(object sender, EventArgs e)
        {
            conditions[lbConditions.SelectedIndex].CustomConnectingMessage = txtConnectingMessage.Text;
        }
    }
}