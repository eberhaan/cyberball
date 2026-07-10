using System;
using UnityEngine;
using System.IO;
using Cyberball.Common;


public class ReadConfig : MonoBehaviour {

	public DialogBox Dialog;
	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		var err = Game.FileToPrefsXML ();
		
		if (!string.IsNullOrEmpty (err)) {
			Dialog.gameObject.SetActive(true);
			Dialog.SendMessage("ShowWithCallback",this.gameObject);
			Dialog.SendMessage("SetMessage",err);
			return;
		}
		Debug.Log(Game.currConf.RunMode);
		if (Game.currConf.RunMode == CBRunMode.Medialab) { // Medialab flag
			var mediaLabInfo = File.ReadAllLines (Game.MEDIALAB_SUBJECT_INFO_FILE);
			
			Game.ParticipantID = mediaLabInfo [0].Substring (mediaLabInfo [0].IndexOf (' ') + 1).Trim ();
			Game.currConf.CurrentConditionName = "Condition " + mediaLabInfo [1].Substring (mediaLabInfo [1].IndexOf (' ') + 1).Trim ();
			Application.LoadLevel("Welcome Screen");
		} 
        else if (Game.currConf.RunMode == CBRunMode.Qualtrics)
        {
            var cmdArgs = System.Environment.CommandLine;
            if (string.IsNullOrEmpty(cmdArgs))
            {
                throw new Exception("No command line found");
                return;
            }

            var cmdLineStr = cmdArgs.Replace("cyberball:", string.Empty).Replace("/",string.Empty);
            
            var cmdVars = cmdLineStr.Split('&');
            var pid =cmdVars[0].Substring(cmdVars[0].IndexOf("ResponseID=")).Replace("ResponseID=", string.Empty).Trim();
            var condition = cmdVars[1].Replace("Condition=", string.Empty).Trim();
            Game.ParticipantID = pid;
            Game.currConf.CurrentConditionName = "Condition " + condition;
            Application.LoadLevel("Welcome Screen");
        }
        else {
			Application.LoadLevel("Participant Id");
		}
	}
	
	// Update is called once per frame
	void OnDialogOK() {
        Application.Quit();
	}
}
