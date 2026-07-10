using UnityEngine;
using System.Collections;
using Cyberball.Common;

public class RandomConditions : MonoBehaviour {
	/*
	public tk2dUIDropDownMenu ddlConditions;
	public tk2dUIDropDownMenu ddlSchedules;
	public tk2dUIToggleButton chkIsRandom;

	private string[] tempSchedules = {"",""};

	public tk2dTextMesh[] lblSchedulesLegend;

	// Use this for initialization
	void Start () {
	
		chkIsRandom.IsOn = Game.IsRandomAssignment;

		ddlSchedules.Index = ddlSchedules.ItemList.IndexOf (Game.GetScheduleForCondition (int.Parse( ddlConditions.SelectedItem.Substring(ddlConditions.SelectedItem.Length- 1))).ToString());
		ddlSchedules.SetSelectedItem ();

		tempSchedules [0] = Game.GetScheduleForCondition (1).ToString();
		tempSchedules [1] = Game.GetScheduleForCondition (2).ToString();

		if(string.IsNullOrEmpty(tempSchedules[0]))
		   {
			tempSchedules[0] = ScheduleTypes.IncludeAll.ToString();
		}
		if(string.IsNullOrEmpty(tempSchedules[1]))
		{
			tempSchedules[1] = ScheduleTypes.IncludeAll.ToString();
        }
        
        lblSchedulesLegend [0].text = tempSchedules [0];
		lblSchedulesLegend[0].Commit ();
		lblSchedulesLegend [1].text = tempSchedules [1];
		lblSchedulesLegend[1].Commit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnConditionChanged(tk2dUIDropDownMenu ddl)
	{
		ddlSchedules.Index = ddlSchedules.ItemList.IndexOf (tempSchedules[ (int.Parse( ddl.SelectedItem.Substring(ddl.SelectedItem.Length- 1)))-1]);
		ddlSchedules.SetSelectedItem ();
		//ddlSchedules.se = Game.GetScheduleForCondition (int.Parse( ddl.SelectedItem.Substring(ddl.SelectedItem.Length- 1)));
	}
	void OnScheduleChanged(tk2dUIDropDownMenu ddl)
	{
		tempSchedules [ddlConditions.Index] = ddl.SelectedItem;
		lblSchedulesLegend [ddlConditions.Index].text = tempSchedules [ddlConditions.Index];
		lblSchedulesLegend[ddlConditions.Index].Commit ();
		Debug.Log (tempSchedules [ddlConditions.Index]);
	}

	void OnSubmitClicked()
	{
		Game.SetScheduleForCondition (1, tempSchedules [0]);
		Game.SetScheduleForCondition (2, tempSchedules [1]);
		Game.IsRandomAssignment = chkIsRandom.IsOn;
		Application.LoadLevel ("Begin Experiment");
	}

	void OnBackClicked()
	{
		Application.LoadLevel ("ControlPanel");
	}
	*/
}
