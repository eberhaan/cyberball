using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class IntroScreen : MonoBehaviour {
	/*
	public Transform colorPicker;

	private string logString="";

	public tk2dUIDropDownMenu ddlMode;
	public tk2dUITextInput txtMaxThrows;
	public tk2dUIToggleButton chkChatEnabled;
	public tk2dUITextInput txtWelcomeMessage;
	public tk2dUIToggleButton chkStatsEnabled;
	public tk2dUITextInput txtPlayerName;
	public tk2dUIToggleButton chkIdEnabled;
	public tk2dUIToggleButton chkSpectator;

	public tk2dSprite cyberBoyColor;
	private int currentBoy = 1;
	public tk2dTextMesh lblCurrentBoy;
	private string[] tempColors = {"","","","","","","","",""}; 
	private const float ONE_UPON_255 = 0.00392156862f;

	private string[] tempNames =  {"","","","","","","","",""}; 

	public Transform btnBack;

	public tk2dUITextInput txtBGFilePath;
	public tk2dUITextInput txtWelcomeFilePath;
	public tk2dUITextInput txtLogFilePath;
	public Transform fileFading;

	// Use this for initialization
	void Start () {
		fileDialog = GameObject.FindObjectOfType<FileBrowser> ();

		fileFading = GameObject.Find ("FileBrowser").transform.Find("fileFading");
		if (string.IsNullOrEmpty (Game.LogFilePath)) {
			Game.LogFilePath =  Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  + "/log.csv";		
		}
		Debug.Log ("Intro Loaded" + Color.white.r);
		//logString = Application.dataPath;


		if (!string.IsNullOrEmpty (Game.Mode)) {
						ddlMode.Index = ddlMode.ItemList.IndexOf (Game.Mode);
						ddlMode.SetSelectedItem ();
				}
			txtMaxThrows.Text = Game.MaxThrows.ToString();

			chkChatEnabled.IsOn = Game.ChatEnabled;
			chkIdEnabled.IsOn = Game.AskForId;
			//txtWelcomeMessage.Text=Game.WelcomeMessage;
			tempColors = Game.GetPlayerColors();
			chkStatsEnabled.IsOn = Game.StatsEnabled;
			chkSpectator.IsOn = Game.IsSpectator;
			tempNames = Game.GetNames();
			UpdateCurrentColor();
			UpdateCurrentName();
			txtLogFilePath.Text = Game.LogFilePath;
			txtBGFilePath.Text = Game.BGFilePath;
			txtWelcomeFilePath.Text = Game.WelcomeTextFilePath;
	}

	void OnBackClicked () {
		btnBack.gameObject.SetActive (false);
		transform.positionTo (0.5f, new Vector3 (0, 0, -10)).easeType = GoEaseType.CircOut;
	}

	void OnPlayClicked()
	{
		Debug.Log ("Play has been clicked");
		Debug.Log (ddlMode.SelectedItem);
		Game.Mode = ddlMode.SelectedItem;
		Game.MaxThrows = int.Parse(txtMaxThrows.Text);
		Game.ChatEnabled = chkChatEnabled.IsOn;
		//Game.WelcomeMessage = txtWelcomeMessage.Text;
		Game.SetPlayerColors (tempColors);
		Game.StatsEnabled = chkStatsEnabled.IsOn;
		tempNames [currentBoy - 1] = txtPlayerName.Text;
		Game.SetPlayerNames (tempNames);
		Game.AskForId = chkIdEnabled.IsOn;
		Game.LogFilePath = txtLogFilePath.Text;
		Game.IsSpectator = chkSpectator.IsOn;
		Game.BGFilePath = (txtBGFilePath.Text + "").Trim();
		Game.WelcomeTextFilePath = (txtWelcomeFilePath.Text + "").Trim();
		Application.LoadLevel ("RandomConditions");
	}

	void OnNextClicked()
	{
		btnBack.gameObject.SetActive (true);
		transform.positionTo (0.5f, new Vector3 (4, 0, -10)).easeType = GoEaseType.CircOut;
	}

	void OnCheckboxToggle(tk2dUIToggleButton cb)
	{
		Debug.Log (cb.IsOn);
	}

	void OnClearClicked()
	{
		txtWelcomeMessage.Text = string.Empty;
	}


	void OnNextPlayerClicked()
	{
		tempNames [currentBoy - 1] = txtPlayerName.Text;
		currentBoy = Mathf.Clamp (currentBoy + 1, 1, 9);
		lblCurrentBoy.text = currentBoy.ToString ();
		lblCurrentBoy.Commit ();

		UpdateCurrentColor ();
		UpdateCurrentName ();
	}

	void OnPrevPlayerClicked()
	{
		tempNames [currentBoy - 1] = txtPlayerName.Text;
		currentBoy = Mathf.Clamp (currentBoy - 1, 1, 9);
		lblCurrentBoy.text = currentBoy.ToString ();
		lblCurrentBoy.Commit ();
		UpdateCurrentColor ();
		UpdateCurrentName ();
	}

	void UpdateCurrentColor()
	{
		if (!string.IsNullOrEmpty (tempColors [currentBoy - 1])) {
			var rgbs = tempColors [currentBoy - 1].Split('#');
			cyberBoyColor.color = new Color(float.Parse(rgbs[0]),float.Parse(rgbs[1]),float.Parse(rgbs[2]));
				} else {
			cyberBoyColor.color = Color.white;		
		}
	}

	void UpdateCurrentName()
	{
		txtPlayerName.Text = tempNames [currentBoy - 1];
	}

	void OnCurrentPlayerClicked()
	{
		colorPicker.gameObject.SetActive (true);
		colorPicker.gameObject.SendMessage ("SetMessage","PICK A COLOR FOR PLAYER " + currentBoy);
		/*
		colorcounter = (colorcounter + 1) % colorOptions.Length;
		cyberBoyColor.color = colorOptions [colorcounter];
		tempColors [currentBoy - 1] = cyberBoyColor.color.r + "#" + cyberBoyColor.color.g + "#" + cyberBoyColor.color.b;
		*/
	/*	}

	void OnGUI()
	{
		GUILayout.Label (logString);
	}

	void CurrentBoyColor(Color col)
	{
		cyberBoyColor.color = col;
		tempColors [currentBoy - 1] = cyberBoyColor.color.r + "#" + cyberBoyColor.color.g + "#" + cyberBoyColor.color.b;
	}
	FileBrowser fileDialog;
	void OnLogFileElipsisClicked()
	{
		fileFading.gameObject.SetActive (true);
		fileDialog.inputMustExist = false;
		fileDialog.fileMasks =  "*.csv";
		fileDialog.startingFileName = "cyberball log.csv";
		fileDialog.ShowBrowser ("Select Log File", OnLogFileSelected);//, Environment.GetFolderPath(Environment.SpecialFolder.Personal),new Rect(32,32,Screen.width-32,Screen.height-32),"OK");
	}

	void OnLogFileSelected (string path)
	{
		fileFading.gameObject.SetActive (!true);
        if (path == null) {
			return;	
		}
		txtLogFilePath.Text = path;
	}

	void OnBGImageClicked()
	{
		fileFading.gameObject.SetActive (true);
		fileDialog.inputMustExist = !false;
		fileDialog.fileMasks =  "*.png;*.jpg;*.jpeg";
		fileDialog.startingFileName = "";
		fileDialog.ShowBrowser ("Select Background Image", OnBGFileSelected);//, Environment.GetFolderPath(Environment.SpecialFolder.Personal),new Rect(32,32,Screen.width-32,Screen.height-32),"OK");
    }
	void OnBGFileSelected (string path)
	{
		fileFading.gameObject.SetActive (!true);
		if (path == null) {
			return;	
		}
		txtBGFilePath.Text = path;
    }
    
    void OnBGClearClicked()
	{
		txtBGFilePath.Text = string.Empty;
	}

	void OnWelcomeMessageClicked()
	{
		fileFading.gameObject.SetActive (true);
		fileDialog.inputMustExist = !false;
		fileDialog.fileMasks =  "*.txt";
		fileDialog.startingFileName = "";
		fileDialog.ShowBrowser ("Select Welcome Text file", OnWelcomeFileSelected);//, Environment.GetFolderPath(Environment.SpecialFolder.Personal),new Rect(32,32,Screen.width-32,Screen.height-32),"OK");
        
	}

	void OnWelcomeFileSelected (string path)
	{
		fileFading.gameObject.SetActive (!true);
		if (path == null) {
			return;	
		}
		txtWelcomeFilePath.Text = path;
    }
	*/
}
