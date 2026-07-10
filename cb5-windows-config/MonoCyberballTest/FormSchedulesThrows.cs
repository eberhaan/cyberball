using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Cyberball.Common;
using MonoCyberball.Properties;

namespace MonoCyberball
{
    public partial class FormSchedulesThrows : Form
    {
        private int _playerCount;
        private bool _shouldGenerateSched;
        private List<CBSchedule> _schedules;
        private int _maxThrows;

        public FormSchedulesThrows(List<CBSchedule> scheds, int playerCount, int maxThrowsGen)
        {
            InitializeComponent();
            _playerCount = playerCount;
            _schedules = scheds;
            _maxThrows = maxThrowsGen;

            var schedTypes = Enum.GetValues(typeof(ScheduleTypes)).Cast<ScheduleTypes>();
            foreach (ScheduleTypes schedType in schedTypes.OrderBy(st => st.ToString()))
            {
                ddlGenSchedType.Items.Add(schedType.ToString());
            }

            foreach (CBSchedule cbSchedule in _schedules)
            {
                lbSchedules.Items.Add(cbSchedule.Name);
            }

            pbPlayerPositions.Image = (Image)Resources.ResourceManager.GetObject("_" + _playerCount + "pl");
            pbPlayerPositions.Refresh();
        }

        private void ddlGenSchedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var genSchedType =
                (ScheduleTypes)Enum.Parse(typeof(ScheduleTypes), ddlGenSchedType.SelectedItem.ToString());

            ddlVictim.Enabled = lblVictim.Enabled = (
                genSchedType == ScheduleTypes.OstracizeOther0
                ||
                genSchedType == ScheduleTypes.OstracizeOther1
                ||
                genSchedType == ScheduleTypes.OstracizeOther2
                );

            FillVictimsList();
        }

        private void FillVictimsList()
        {
            if (ddlGenSchedType.SelectedIndex == -1) return;

            ddlVictim.Items.Clear();


            switch ((ScheduleTypes)Enum.Parse(typeof(ScheduleTypes), ddlGenSchedType.SelectedItem.ToString()))
            {
                case ScheduleTypes.IncludeAll:
                    ddlVictim.Items.Add("-NA-");
                    ddlVictim.SelectedIndex = 0;
                    break;
                case ScheduleTypes.OstracizeSubject0:
                case ScheduleTypes.OstracizeSubject1:
                case ScheduleTypes.OstracizeSubject2:
                    ddlVictim.Items.Add("Player 2 (Human)");
                    ddlVictim.SelectedIndex = 0;
                    break;
                case ScheduleTypes.OstracizeOther0:
                case ScheduleTypes.OstracizeOther1:
                case ScheduleTypes.OstracizeOther2:
                    for (int i = 1; i <= _playerCount; i++)
                    {
                        if (i == 2) continue;
                        ddlVictim.Items.Add("Player " + i);
                    }
                    break;
            }
        }

        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            if (ddlGenSchedType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select type of schedule to generate");
                ddlGenSchedType.Focus();
                return;
            }
            if (ddlVictim.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the player to Ostracize");
                ddlVictim.Focus();
                return;
            }


            _shouldGenerateSched = true;
            CreateNewSchedule();
        }

        private void CreateNewSchedule()
        {
            var frmCreateSched = new FormCreateSchedule(_playerCount);
            if (frmCreateSched.ShowDialog() == DialogResult.OK)
            {
                var schedNameCount = frmCreateSched.GetSchedCreationData();
                _schedules.Add(new CBSchedule { Name = schedNameCount.Item1, PlayerCount = schedNameCount.Item2 });
                lbSchedules.Items.Add(schedNameCount.Item1);


                lbSchedules.SelectedIndex = lbSchedules.Items.Count - 1;

                if (_shouldGenerateSched)
                {
                    PopulateSchedule();
                }
            }
            else
            {
                _shouldGenerateSched = false;
            }
        }

        private void PopulateSchedule()
        {
            switch ((ScheduleTypes)Enum.Parse(typeof(ScheduleTypes), ddlGenSchedType.SelectedItem.ToString()))
            {
                case ScheduleTypes.IncludeAll:
                    GenerateInclusionThrows();
                    break;
                case ScheduleTypes.OstracizeSubject0:
                    GenerateOstracismtThrows(2, 0);
                    break;
                case ScheduleTypes.OstracizeSubject1:
                    GenerateOstracismtThrows(2, 1);
                    break;
                case ScheduleTypes.OstracizeSubject2:
                    GenerateOstracismtThrows(2, 2);
                    break;
                case ScheduleTypes.OstracizeOther1:
                    GenerateOstracismtThrows(int.Parse(ddlVictim.SelectedItem.ToString().Trim().Last().ToString()), 1);
                    break;
                case ScheduleTypes.OstracizeOther0:
                    GenerateOstracismtThrows(int.Parse(ddlVictim.SelectedItem.ToString().Trim().Last().ToString()), 0);
                    break;
                case ScheduleTypes.OstracizeOther2:
                    GenerateOstracismtThrows(int.Parse(ddlVictim.SelectedItem.ToString().Trim().Last().ToString()), 2);
                    break;
            }
            ShowThrowsForSelectedSchedule();
            _shouldGenerateSched = false;
        }

        private void GenerateOstracismtThrows(int target, int throwsNeeded)
        {
            OstracizeScheduleGen gen = new OstracizeScheduleGen(target, throwsNeeded, (int)txtGenSchedThrowCount.Value,
                _playerCount);
            var genThrows = gen.Generate();
            var throwCounter = 0;
            foreach (int @throw in genThrows)
            {
                ++throwCounter;
                if (@throw == 0)
                {
                    _schedules[lbSchedules.SelectedIndex].AddThrow(
                        new CBThrow
                        {
                            Delay = defaultDelay.Next(2, 6),
                            ThrowName = "Throw " + throwCounter,
                            ThrowTo = "Any"
                        }
                        );
                }
                else
                {
                    _schedules[lbSchedules.SelectedIndex].AddThrow(
                        new CBThrow
                        {
                            Delay = defaultDelay.Next(2, 6),
                            ThrowName = "Throw " + throwCounter,
                            ThrowTo = "Player " + @throw + (@throw == 2 ? " (Human)" : string.Empty)
                        }
                        );
                }
            }
        }

        private void ShowThrowsForSelectedSchedule()
        {
            lbThrows.ClearSelected();
            lbThrows.Items.Clear();
            
            if (lbSchedules.SelectedIndex != -1)
            {
                ShowCurrSchedInfo();
                for (var i = 0; i < _schedules[lbSchedules.SelectedIndex].GetThrowCount(); i++)
                {
                    var thro = _schedules[lbSchedules.SelectedIndex].GetThrowAt(i);
                    if (!thro.isChatMessage)
                        lbThrows.Items.Add(_schedules[lbSchedules.SelectedIndex].GetPrevPlayerName(i) + " - " +
                                           thro.ThrowTo);
                    else
                    {
                        lbThrows.Items.Add(thro.ThrowName);
                    }
                }
            }
            else
            {
                lblSchedThrows.Text = "0";
            }
        }

        private void ShowCurrSchedInfo()
        {
            lblSchedThrows.Text = _schedules[lbSchedules.SelectedIndex].GetThrowCount().ToString();
            lblDeprecatedThrows.Text = _schedules[lbSchedules.SelectedIndex].GetDeprecatedThrowCount().ToString();
            lblIdealThrowCount.Text = (_maxThrows + _schedules[lbSchedules.SelectedIndex].GetDeprecatedThrowCount()).ToString();
        }

        Random defaultDelay = new Random(DateTime.Now.Millisecond);
        private void GenerateInclusionThrows()
        {
            var previousPlayer = 1;
            var throwNum = 1;
            while (_schedules[lbSchedules.SelectedIndex].GetThrowCount() < txtGenSchedThrowCount.Value)
            {
                var throwTo = GetNextThrowInclusion(previousPlayer, _playerCount);
                if (throwTo == 2)
                {
                    _schedules[lbSchedules.SelectedIndex].AddThrow(new CBThrow
                    {
                        Delay = defaultDelay.Next(2, 6),
                        ThrowName = "Throw " + (throwNum),
                        ThrowTo = "Player " + throwTo + " (Human)"
                    });
                    ++throwNum;
                    _schedules[lbSchedules.SelectedIndex].AddThrow(new CBThrow
                    {
                        Delay = defaultDelay.Next(2, 6),
                        ThrowName = "Throw " + (throwNum),
                        ThrowTo = "Any"
                    });
                }
                else
                    _schedules[lbSchedules.SelectedIndex].AddThrow(new CBThrow
                    {
                        Delay = defaultDelay.Next(2, 6),
                        ThrowName = "Throw " + (throwNum),
                        ThrowTo = "Player " + throwTo
                    });

                previousPlayer = throwTo;
                ++throwNum;
            }
        }

        private readonly Random rnd = new Random((int)DateTime.Now.Ticks);
        private readonly List<string> thrownTos = new List<string>();

        private int GetNextThrowInclusion(int ballHolder, int noOfPlayers)
        {
            var throwTo = rnd.Next(1, noOfPlayers + 1);
            while (throwTo == ballHolder || thrownTos.Contains(ballHolder + "-" + throwTo))
            {
                throwTo = rnd.Next(1, noOfPlayers + 1);
            }
            thrownTos.Add(ballHolder + "-" + throwTo);
            if (thrownTos.Count(t => t.StartsWith(ballHolder + "-")) == (noOfPlayers - 1))
            {
                thrownTos.RemoveAll(t => t.StartsWith(ballHolder + "-"));
            }
            return throwTo;
        }

        private void lbSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowThrowsForSelectedSchedule();
        }

        private void btnNewSchedule_Click(object sender, EventArgs e)
        {
            CreateNewSchedule();
        }

        private void btnMoveThrowUp_Click(object sender, EventArgs e)
        {
            MoveThrowUp();
        }

        private void btnMoveThrowDown_Click(object sender, EventArgs e)
        {
            MoveThrowDown();
        }

        private void MoveThrowUp()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("Select a Throw to Move.");
                return;
            }
            var si = lbThrows.SelectedIndex;
            if (_schedules[lbSchedules.SelectedIndex].MoveThrowUpAt(lbThrows.SelectedIndex))
            {
                RefreshThrows();
                lbThrows.SelectedIndex = si - 1;
            }
        }

        private void MoveThrowDown()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("Select a Throw to Move.");
                return;
            }
            var si = lbThrows.SelectedIndex;
            if (_schedules[lbSchedules.SelectedIndex].MoveThrowDownAt(lbThrows.SelectedIndex))
            {
                RefreshThrows();
                lbThrows.SelectedIndex = si + 1;
            }
        }

        private void RefreshThrows()
        {
            lbThrows.Items.Clear();
            for (var i = 0; i < _schedules[lbSchedules.SelectedIndex].GetThrowCount(); i++)
            {
                var thro = _schedules[lbSchedules.SelectedIndex].GetThrowAt(i);
                if (!thro.isChatMessage)
                    lbThrows.Items.Add(_schedules[lbSchedules.SelectedIndex].GetPrevPlayerName(i) + " - " + thro.ThrowTo);
                else
                {
                    lbThrows.Items.Add(thro.ThrowName);
                }
            }
            ShowCurrSchedInfo();
        }

        private void btnThrow_Click(object sender, EventArgs e)
        {
            EditThrowOrMessage();
        }

        private void EditThrowOrMessage()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("You must select something to edit.");
                return;
            }
            if (!_schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex).isChatMessage)
                EditSelectedThrow();
            else
                EditSelectedMessage();
        }

        private void EditSelectedThrow()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("You must select a Throw to edit.");
                return;
            }
            var throwFrom = "Player 1";
            if (_schedules[lbSchedules.SelectedIndex].GetThrowCount() > 1 && lbThrows.SelectedIndex > 0)
                //throwFrom = _schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex - 1).ThrowTo;
                throwFrom = _schedules[lbSchedules.SelectedIndex].GetPrevPlayerName(lbThrows.SelectedIndex);
            var frmThrowDetails =
                new FormThrowDetails(_schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex),
                    _playerCount + " Player", throwFrom);
            if (frmThrowDetails.ShowDialog() == DialogResult.OK)
            {
                var editedthrow = frmThrowDetails.GetThrowDetails();
                _schedules[lbSchedules.SelectedIndex].UpdateThrow(lbThrows.SelectedIndex, editedthrow);
                lbThrows.Items[lbThrows.SelectedIndex] =
                    _schedules[lbSchedules.SelectedIndex].GetPrevPlayerName(lbThrows.SelectedIndex) + " - " +
                    editedthrow.ThrowTo;
            }
        }

        private void EditSelectedMessage()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("You must select a Message to edit.");
                return;
            }

            using (var formEditMessage = new FormAddMessage(_playerCount,
                _schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex).msg))
            {
                if (formEditMessage.ShowDialog() == DialogResult.OK)
                {
                    var editedMsg = formEditMessage.GetCreatedMessage();
                    _schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex).msg = editedMsg;

                    if (editedMsg.sender != 0)
                    {
                        _schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex).ThrowName = "Chat - " + "P" +
                                                                                                             editedMsg
                                                                                                                 .sender +
                                                                                                             " - " +
                                                                                                             editedMsg
                                                                                                                 .message;
                    }
                    else
                    {
                        _schedules[lbSchedules.SelectedIndex].GetThrowAt(lbThrows.SelectedIndex).ThrowName = "Instr. - " + editedMsg.message;
                    }
                    RefreshThrows();
                }
            }
        }

        private void btnNewThrow_Click(object sender, EventArgs e)
        {
            CreateNewThrow();
        }

        private void CreateNewThrow()
        {
            if (lbSchedules.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a Schedule before adding a Throw", "Select a Schedule");
                return;
            }

            var frmThrowDetails =
                new FormThrowDetails(new CBThrow(),
                    _playerCount + " Player", _schedules[lbSchedules.SelectedIndex].GetBallHolderName());
            if (frmThrowDetails.ShowDialog() == DialogResult.OK)
            {
                var newThrow = frmThrowDetails.GetThrowDetails();
                var ballHolder = _schedules[lbSchedules.SelectedIndex].GetBallHolderName();
                _schedules[lbSchedules.SelectedIndex].AddThrow(newThrow);
                lbThrows.Items.Add(ballHolder + " - " + newThrow.ThrowTo);
                lbThrows.SelectedIndex = lbThrows.Items.Count - 1;
            }
            ShowCurrSchedInfo();
        }

        private void btnNewMessage_Click(object sender, EventArgs e)
        {
            CreateNewMessage();
        }

        private void CreateNewMessage()
        {
            if (lbSchedules.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a schedule to add a message to.");
                lbSchedules.Focus();
                return;
            }

            using (var frmCreateMsg = new FormAddMessage(_playerCount))
            {
                if (frmCreateMsg.ShowDialog() == DialogResult.OK)
                {
                    var newMsg = frmCreateMsg.GetCreatedMessage();
                    _schedules[lbSchedules.SelectedIndex].AddMessage(newMsg);
                    lbThrows.Items.Add(newMsg.GetParentThrow().ThrowName);
                    lbThrows.SelectedIndex = lbThrows.Items.Count - 1;
                }
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            DeleteSelectedSchedule();
        }

        private void DeleteSelectedSchedule()
        {
            if (lbSchedules.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a 'Schedule' to delete.");
                return;
            }
            _schedules.RemoveAt(lbSchedules.SelectedIndex);
            lbSchedules.Items.RemoveAt(lbSchedules.SelectedIndex);
        }

        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            EditSelectedSchedule();
        }

        private void EditSelectedSchedule()
        {
            if (lbSchedules.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a Schedule to edit");
                return;
            }
            using (var frmEditSchedule = new FormCreateSchedule(_playerCount, _schedules[lbSchedules.SelectedIndex]))
            {
                if (frmEditSchedule.ShowDialog() == DialogResult.OK)
                {
                    _schedules[lbSchedules.SelectedIndex].Name = frmEditSchedule.GetSchedCreationData().Item1;
                    var selectedSched = lbSchedules.SelectedIndex;
                    lbSchedules.Items.Clear();
                    foreach (CBSchedule cbSchedule in _schedules)
                    {
                        lbSchedules.Items.Add(cbSchedule.Name);
                    }
                    lbSchedules.SelectedIndex = selectedSched;
                }
            }
        }

        private void DeleteSelectedThrowOrMessage()
        {
            if (NoThrowIsSelected())
            {
                MessageBox.Show("Please select a throw or message to delete");
                return;
            }

            _schedules[lbSchedules.SelectedIndex].DeleteThrowAt(lbThrows.SelectedIndex);
            RefreshThrows();
        }

        private bool NoThrowIsSelected()
        {
            return lbThrows.SelectedIndex == -1;
        }

        private void mnuNewSchedule_Click(object sender, EventArgs e)
        {
            CreateNewSchedule();
        }

        private void cmNewSchedule_Click(object sender, EventArgs e)
        {
            CreateNewSchedule();
        }

        private void mnuEditSchedule_Click(object sender, EventArgs e)
        {
            EditSelectedSchedule();
        }

        private void cmEditSchedule_Click(object sender, EventArgs e)
        {
            EditSelectedSchedule();
        }

        private void mnuDeleteSchedule_Click(object sender, EventArgs e)
        {
            DeleteSelectedSchedule();
        }

        private void cmDeleteSchedule_Click(object sender, EventArgs e)
        {
            DeleteSelectedSchedule();
        }

        private void throwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewThrow();
        }

        private void mnuNewThrow_Click_1(object sender, EventArgs e)
        {
            CreateNewThrow();
        }

        private void mnuEditThrowMessage_Click(object sender, EventArgs e)
        {
            EditThrowOrMessage();
        }

        private void cmEditThrowMessage_Click(object sender, EventArgs e)
        {
            EditThrowOrMessage();
        }

        private void mnuDeleteThrowMessage_Click(object sender, EventArgs e)
        {
            DeleteSelectedThrowOrMessage();
        }

        private void cmDeleteThrowMessage_Click(object sender, EventArgs e)
        {
            DeleteSelectedThrowOrMessage();
        }

        private void mnuMoveUp_Click(object sender, EventArgs e)
        {
            MoveThrowUp();
        }

        private void cmMoveUp_Click(object sender, EventArgs e)
        {
            MoveThrowUp();
        }

        private void mnuMoveDown_Click(object sender, EventArgs e)
        {
            MoveThrowDown();
        }

        private void cmMoveDown_Click(object sender, EventArgs e)
        {
            MoveThrowDown();
        }

        private void mnuNewMessage_Click(object sender, EventArgs e)
        {
            CreateNewMessage();
        }

        private void cmNewMessage_Click(object sender, EventArgs e)
        {
            CreateNewMessage();
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            SaveSelectedSchedule();
        }

        private void SaveSelectedSchedule()
        {
            if (lbSchedules.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a schedule to save");
                return;
            }
            var schedToSave = _schedules[lbSchedules.SelectedIndex];
            dialogSaveSched.FileName = schedToSave.Name;
            if (dialogSaveSched.ShowDialog() == DialogResult.OK)
            {
                ConfigIO.SaveSchedule(schedToSave, dialogSaveSched.FileName);
                MessageBox.Show(string.Format("Schedule {0} was saved Successfully!", schedToSave.Name));
            }
        }

        private void btnDeleteThrowMessage_Click(object sender, EventArgs e)
        {
            DeleteSelectedThrowOrMessage();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveSelectedSchedule();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSelectedSchedule();
        }

        private void btnOpenSchedule_Click(object sender, EventArgs e)
        {
            OpenASchedule();
        }

        private void OpenASchedule()
        {
            if (dialogOpenSched.ShowDialog() == DialogResult.OK)
            {
                var openedSchedule = ConfigIO.ReadSchedule(dialogOpenSched.FileName);
                if (_schedules.Contains(openedSchedule))
                {
                    MessageBox.Show("The opened schedule is already loaded.");
                    return;
                }
                else
                {
                    _schedules.Add(openedSchedule);
                    lbSchedules.Items.Add(openedSchedule.Name);
                    lbSchedules.SelectedIndex = lbSchedules.Items.Count - 1;
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenASchedule();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenASchedule();
        }

        private void lbThrows_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lbThrows.IndexFromPoint(e.Location);
            if (index >= 0)
            {
                lbThrows.SelectedIndex = index;
                EditThrowOrMessage();
            }
        }

        private void lbThrows_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void FormSchedulesThrows_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var sched in _schedules)
            {
                var throwCount = sched.GetThrowCount();
                var deprecatedThrows = sched.GetDeprecatedThrowCount();
                var idealThrowCount = _maxThrows + deprecatedThrows;

                if (throwCount < idealThrowCount)
                {
                    if (MessageBox.Show("Custom schedule throw count is less than overall game throw count.\nThis will lead to Cyberball generating random throws (e.g., random delays, random targets) to make up the difference.\nAdd more custom throws to schedule to prevent this scenario?", 
                        "More throws are needed!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void FormSchedulesThrows_Load(object sender, EventArgs e)
        {
            lblMaxThrows.Text = _maxThrows.ToString();
        }
    }
}