using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	string[] cmdArgs = {"","","","","","","",""};
	private string id;
	void Start () {
		cmdArgs = System.Environment.GetCommandLineArgs ();
		id = System.Environment.CommandLine.Substring (System.Environment.CommandLine.IndexOf("ResponseID=") ).Trim().Replace("ResponseID=",string.Empty);
	}
	
	void Update () {

	}
	
	void OnGUI()
	{
		//foreach (var arg in cmdArgs) {
			GUILayout.Label(" -" + id + "- ");		
		//}
	}

}
