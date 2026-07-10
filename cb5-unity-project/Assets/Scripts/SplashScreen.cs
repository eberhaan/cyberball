using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	//public Transform fileBrowser;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.Save ();
		Invoke ("Activate", 0.1f);
		Invoke ("LoadNext", 0.5f);
	}
	
	// Update is called once per frame
	void LoadNext () {
		//Application.LoadLevelAsync ("Intro");
		Application.LoadLevel ("Intro");
	}

	void OnGUI()
	{
		GUILayout.Label (string.Empty);
		//fileBrowser.gameObject.SetActive (true);
	}
}
