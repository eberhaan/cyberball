using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Cyberball.Common;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;

using Application = UnityEngine.Application;

public class Play : MonoBehaviour
{
    public Transform[] playerBalls;
    public Material cyberballMaterial;
    public Transform instructions;
    public tk2dTextMesh lblInstructions;
	public Renderer BGrenderer;
	public CyberBoy[] _3pl_players;
	public CyberBoy[] _4pl_players;
	public CyberBoy[] _5pl_players;
	public CyberBoy[] _6pl_players;
	public CyberBoy[] _7pl_players;
	public CyberBoy[] _8pl_players;
	public CyberBoy[] _9pl_players;
	public tk2dSprite playBall;
	public tk2dTextMesh lblThrowsMade;
	public tk2dTextMesh lblThrowsTaken;
	public tk2dTextMesh lblTotalThrows;
	private int throwsMade;
	private int throwsTaken;
	private CyberBoy ballHolder;
	private int throwCount;
	private bool isThrowing;
	private List<CyberBoy> currentPlayers;
	private Dictionary<int,List<string>> currentPlayerMoves;
	public static StringBuilder log;

	private int currentThrowDelay = 3; //Default value of throw delay. This will only be used for the first throw
	public tk2dTextMesh lblVersionNum;
	// Use this for initialization
	void Start ()
	{
        CustomBall();
	    //CustomGuy();
        //Testing the replacing functions of CB

        string filePath = Path.Combine(Application.streamingAssetsPath, "cb5-atlas.png");
        if (File.Exists(filePath))
        {
            Texture2D t = new Texture2D(1024, 1024, TextureFormat.ARGB32, true);
            t.LoadImage(File.ReadAllBytes(filePath));
            cyberballMaterial.mainTexture = t;
        }
        //End Testing

        lblVersionNum.text = "v" + Game.VERSION;
		lblVersionNum.Commit ();
		log = new StringBuilder (string.Empty);
		lblThrowsMade.gameObject.SetActive (Game.currConf.ShouldShowStats);
		lblThrowsTaken.gameObject.SetActive (Game.currConf.ShouldShowStats);

		currentPlayers = new List<CyberBoy> ();
		currentPlayerMoves = new Dictionary<int, List<string>> ();

		var currentSchedule = ScheduleTypes.IncludeAll;

		if (Game.currConf.ShouldHandleRandomAssignment) 
			Game.currConf.CurrentConditionName = Game.currConf.Conditions [Random.Range (0, Game.currConf.Conditions.Count)].Name;

		currentSchedule = Game.currConf.CurrentCondition.ScheduleType.GetValueOrDefault ();

		LogGameStart ();
		LogQualtricsID ();
		Debug.Log ("Current Schedule:" + currentSchedule);

		switch (Game.currConf.GameMode) {
		
		case "3 Player":
			_3pl_players [0].gameObject.SetActive (true);
			_3pl_players [1].gameObject.SetActive (true);
			_3pl_players [2].gameObject.SetActive (true);
						
			currentPlayers.Add (_3pl_players [0]);
			currentPlayers.Add (_3pl_players [1]);
			currentPlayers.Add (_3pl_players [2]);

            
			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._3plAll [1]);
				currentPlayerMoves.Add (3, Schedules._3plAll [3]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._3plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOsOther0 [3]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._3plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOsOther1 [3]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._3plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOsOther2 [3]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._3plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOs0 [3]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._3plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOs1 [3]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._3plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._3plOs2 [3]);
				break;
			}

			break;

		case "4 Player":
						
			_4pl_players [0].gameObject.SetActive (true);
			_4pl_players [1].gameObject.SetActive (true);
			_4pl_players [2].gameObject.SetActive (true);
			_4pl_players [3].gameObject.SetActive (true);

			currentPlayers.Add (_4pl_players [0]);
			currentPlayers.Add (_4pl_players [1]);
			currentPlayers.Add (_4pl_players [2]);
			currentPlayers.Add (_4pl_players [3]);

			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._4plAll [1]);
				currentPlayerMoves.Add (3, Schedules._4plAll [3]);
				currentPlayerMoves.Add (4, Schedules._4plAll [4]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._4plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOsOther0 [4]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._4plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOsOther1 [4]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._4plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOsOther2 [4]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._4plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOs0 [4]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._4plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOs1 [4]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._4plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._4plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._4plOs2 [4]);
				break;
			}


			break;

		case "5 Player":
			_5pl_players [0].gameObject.SetActive (true);
			_5pl_players [1].gameObject.SetActive (true);
			_5pl_players [2].gameObject.SetActive (true);
			_5pl_players [3].gameObject.SetActive (true);
			_5pl_players [4].gameObject.SetActive (true);

			currentPlayers.Add (_5pl_players [0]);
			currentPlayers.Add (_5pl_players [1]);
			currentPlayers.Add (_5pl_players [2]);
			currentPlayers.Add (_5pl_players [3]);
			currentPlayers.Add (_5pl_players [4]);

			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._5plAll [1]);
				currentPlayerMoves.Add (3, Schedules._5plAll [3]);
				currentPlayerMoves.Add (4, Schedules._5plAll [4]);
				currentPlayerMoves.Add (5, Schedules._5plAll [5]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._5plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOsOther0 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOsOther0 [5]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._5plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOsOther1 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOsOther1 [5]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._5plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOsOther2 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOsOther2 [5]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._5plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOs0 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOs0 [5]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._5plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOs1 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOs1 [5]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._5plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._5plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._5plOs2 [4]);
				currentPlayerMoves.Add (5, Schedules._5plOs2 [5]);
				break;
			}

			break;

		case "6 Player":
			_6pl_players [0].gameObject.SetActive (true);
			_6pl_players [1].gameObject.SetActive (true);
			_6pl_players [2].gameObject.SetActive (true);
			_6pl_players [3].gameObject.SetActive (true);
			_6pl_players [4].gameObject.SetActive (true);
			_6pl_players [5].gameObject.SetActive (true);

			currentPlayers.Add (_6pl_players [0]);
			currentPlayers.Add (_6pl_players [1]);
			currentPlayers.Add (_6pl_players [2]);
			currentPlayers.Add (_6pl_players [3]);
			currentPlayers.Add (_6pl_players [4]);
			currentPlayers.Add (_6pl_players [5]);


			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._6plAll [1]);
				currentPlayerMoves.Add (3, Schedules._6plAll [3]);
				currentPlayerMoves.Add (4, Schedules._6plAll [4]);
				currentPlayerMoves.Add (5, Schedules._6plAll [5]);
				currentPlayerMoves.Add (6, Schedules._6plAll [6]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._6plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOsOther0 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOsOther0 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOsOther0 [6]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._6plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOsOther1 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOsOther1 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOsOther1 [6]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._6plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOsOther2 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOsOther2 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOsOther2 [6]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._6plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOs0 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOs0 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOs0 [6]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._6plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOs1 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOs1 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOs1 [6]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._6plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._6plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._6plOs2 [4]);
				currentPlayerMoves.Add (5, Schedules._6plOs2 [5]);
				currentPlayerMoves.Add (6, Schedules._6plOs2 [6]);
				break;
			}

			break;

		case "7 Player":
			_7pl_players [0].gameObject.SetActive (true);
			_7pl_players [1].gameObject.SetActive (true);
			_7pl_players [2].gameObject.SetActive (true);
			_7pl_players [3].gameObject.SetActive (true);
			_7pl_players [4].gameObject.SetActive (true);
			_7pl_players [5].gameObject.SetActive (true);
			_7pl_players [6].gameObject.SetActive (true);

			currentPlayers.Add (_7pl_players [0]);
			currentPlayers.Add (_7pl_players [1]);
			currentPlayers.Add (_7pl_players [2]);
			currentPlayers.Add (_7pl_players [3]);
			currentPlayers.Add (_7pl_players [4]);
			currentPlayers.Add (_7pl_players [5]);
			currentPlayers.Add (_7pl_players [6]);

			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._7plAll [1]);
				currentPlayerMoves.Add (3, Schedules._7plAll [3]);
				currentPlayerMoves.Add (4, Schedules._7plAll [4]);
				currentPlayerMoves.Add (5, Schedules._7plAll [5]);
				currentPlayerMoves.Add (6, Schedules._7plAll [6]);
				currentPlayerMoves.Add (7, Schedules._7plAll [7]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._7plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOsOther0 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOsOther0 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOsOther0 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOsOther0 [7]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._7plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOsOther1 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOsOther1 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOsOther1 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOsOther1 [7]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._7plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOsOther2 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOsOther2 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOsOther2 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOsOther2 [7]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._7plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOs0 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOs0 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOs0 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOs0 [7]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._7plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOs1 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOs1 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOs1 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOs1 [7]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._7plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._7plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._7plOs2 [4]);
				currentPlayerMoves.Add (5, Schedules._7plOs2 [5]);
				currentPlayerMoves.Add (6, Schedules._7plOs2 [6]);
				currentPlayerMoves.Add (7, Schedules._7plOs2 [7]);
				break;
			}
			break;

		case "8 Player":
			_8pl_players [0].gameObject.SetActive (true);
			_8pl_players [1].gameObject.SetActive (true);
			_8pl_players [2].gameObject.SetActive (true);
			_8pl_players [3].gameObject.SetActive (true);
			_8pl_players [4].gameObject.SetActive (true);
			_8pl_players [5].gameObject.SetActive (true);
			_8pl_players [6].gameObject.SetActive (true);
			_8pl_players [7].gameObject.SetActive (true);

			currentPlayers.Add (_8pl_players [0]);
			currentPlayers.Add (_8pl_players [1]);
			currentPlayers.Add (_8pl_players [2]);
			currentPlayers.Add (_8pl_players [3]);
			currentPlayers.Add (_8pl_players [4]);
			currentPlayers.Add (_8pl_players [5]);
			currentPlayers.Add (_8pl_players [6]);
			currentPlayers.Add (_8pl_players [7]);

			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._8plAll [1]);
				currentPlayerMoves.Add (3, Schedules._8plAll [3]);
				currentPlayerMoves.Add (4, Schedules._8plAll [4]);
				currentPlayerMoves.Add (5, Schedules._8plAll [5]);
				currentPlayerMoves.Add (6, Schedules._8plAll [6]);
				currentPlayerMoves.Add (7, Schedules._8plAll [7]);
				currentPlayerMoves.Add (8, Schedules._8plAll [8]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._8plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOsOther0 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOsOther0 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOsOther0 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOsOther0 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOsOther0 [8]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._8plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOsOther1 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOsOther1 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOsOther1 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOsOther1 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOsOther1 [8]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._8plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOsOther2 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOsOther2 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOsOther2 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOsOther2 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOsOther2 [8]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._8plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOs0 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOs0 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOs0 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOs0 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOs0 [8]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._8plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOs1 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOs1 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOs1 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOs1 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOs1 [8]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._8plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._8plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._8plOs2 [4]);
				currentPlayerMoves.Add (5, Schedules._8plOs2 [5]);
				currentPlayerMoves.Add (6, Schedules._8plOs2 [6]);
				currentPlayerMoves.Add (7, Schedules._8plOs2 [7]);
				currentPlayerMoves.Add (8, Schedules._8plOs2 [8]);
				break;
			}
			break;

		case "9 Player":
			_9pl_players [0].gameObject.SetActive (true);
			_9pl_players [1].gameObject.SetActive (true);
			_9pl_players [2].gameObject.SetActive (true);
			_9pl_players [3].gameObject.SetActive (true);
			_9pl_players [4].gameObject.SetActive (true);
			_9pl_players [5].gameObject.SetActive (true);
			_9pl_players [6].gameObject.SetActive (true);
			_9pl_players [7].gameObject.SetActive (true);
			_9pl_players [8].gameObject.SetActive (true);


			currentPlayers.Add (_9pl_players [0]);
			currentPlayers.Add (_9pl_players [1]);
			currentPlayers.Add (_9pl_players [2]);
			currentPlayers.Add (_9pl_players [3]);
			currentPlayers.Add (_9pl_players [4]);
			currentPlayers.Add (_9pl_players [5]);
			currentPlayers.Add (_9pl_players [6]);
			currentPlayers.Add (_9pl_players [7]);
			currentPlayers.Add (_9pl_players [8]);

			switch (currentSchedule) {
			case ScheduleTypes.IncludeAll:
				currentPlayerMoves.Add (1, Schedules._9plAll [1]);
				currentPlayerMoves.Add (3, Schedules._9plAll [3]);
				currentPlayerMoves.Add (4, Schedules._9plAll [4]);
				currentPlayerMoves.Add (5, Schedules._9plAll [5]);
				currentPlayerMoves.Add (6, Schedules._9plAll [6]);
				currentPlayerMoves.Add (7, Schedules._9plAll [7]);
				currentPlayerMoves.Add (8, Schedules._9plAll [8]);
				currentPlayerMoves.Add (9, Schedules._9plAll [9]);
				break;
			case ScheduleTypes.OstracizeOther0:
				currentPlayerMoves.Add (1, Schedules._9plOsOther0 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOsOther0 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOsOther0 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOsOther0 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOsOther0 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOsOther0 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOsOther0 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOsOther0 [9]);
				break;
			case ScheduleTypes.OstracizeOther1:
				currentPlayerMoves.Add (1, Schedules._9plOsOther1 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOsOther1 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOsOther1 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOsOther1 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOsOther1 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOsOther1 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOsOther1 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOsOther1 [9]);
				break;
			case ScheduleTypes.OstracizeOther2:
				currentPlayerMoves.Add (1, Schedules._9plOsOther2 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOsOther2 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOsOther2 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOsOther2 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOsOther2 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOsOther2 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOsOther2 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOsOther2 [9]);
				break;
			case ScheduleTypes.OstracizeSubject0:
				currentPlayerMoves.Add (1, Schedules._9plOs0 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOs0 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOs0 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOs0 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOs0 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOs0 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOs0 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOs0 [9]);
				break;
			case ScheduleTypes.OstracizeSubject1:
				currentPlayerMoves.Add (1, Schedules._9plOs1 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOs1 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOs1 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOs1 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOs1 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOs1 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOs1 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOs1 [9]);
				break;
			case ScheduleTypes.OstracizeSubject2:
				currentPlayerMoves.Add (1, Schedules._9plOs2 [1]);
				currentPlayerMoves.Add (3, Schedules._9plOs2 [3]);
				currentPlayerMoves.Add (4, Schedules._9plOs2 [4]);
				currentPlayerMoves.Add (5, Schedules._9plOs2 [5]);
				currentPlayerMoves.Add (6, Schedules._9plOs2 [6]);
				currentPlayerMoves.Add (7, Schedules._9plOs2 [7]);
				currentPlayerMoves.Add (8, Schedules._9plOs2 [8]);
				currentPlayerMoves.Add (9, Schedules._9plOs2 [9]);
				break;
			}
			break;
		}
		ballHolder = currentPlayers [0];

		if (!string.IsNullOrEmpty (Game.currConf.CurrentCondition.BgImagePath)) {
			StartCoroutine ("LoadBG");
		}
		StartCoroutine ("StartGame");
	}

    public tk2dSpriteAnimator anim;
    private void CustomGuy()
    {
        var fileName = string.Empty;

        if (!string.IsNullOrEmpty(Game.currConf.CurrentCondition.CustomBoyImagesFolder) &&
            Directory.Exists(Game.currConf.CurrentCondition.CustomBoyImagesFolder))
        {
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

                var fileData = File.ReadAllBytes(Game.currConf.CurrentCondition.CustomBallImage);
                var texture = new Texture2D(78, 78, TextureFormat.ARGB32, true);
                texture.LoadImage(fileData);
                var frame = tk2dSprite.CreateFromTexture(texture, tk2dSpriteCollectionSize.Explicit(1, 1080), new Rect(0, 0, 78, 78), new Vector2(39, 39));
                frame.name = "idle";
                anim.CurrentClip.frames[0] = new tk2dSpriteAnimationFrame();
                //anim.CurrentClip.frames[0].spriteCollection = 

				tk2dSprite s;


            }
        }
    }

    private void CustomBall()
    {
        if(!string.IsNullOrEmpty(Game.currConf.CurrentCondition.CustomBallImage) && File.Exists(Game.currConf.CurrentCondition.CustomBallImage))
        {
            var fileData = File.ReadAllBytes(Game.currConf.CurrentCondition.CustomBallImage);
            var t = new Texture2D(78,78,TextureFormat.ARGB32,true);
            t.LoadImage(fileData);
            var v = tk2dSprite.CreateFromTexture(t, tk2dSpriteCollectionSize.Explicit(1, 1080), new Rect(0,0,78,78),new  Vector2(39,39));
            v.name = "CustomPlayBall";
            v.transform.parent = playBall.transform;
            v.transform.localPosition = Vector3.zero;
            playBall.GetComponent<MeshRenderer>().enabled = false;

            foreach (var b in playerBalls)
            {
                b.GetComponent<MeshRenderer>().enabled = false;
                var d = Instantiate(v);
                d.transform.parent = b.transform;
                d.transform.localPosition = Vector3.zero;
                b.Translate(0, 0, -1, Space.World);
            }
        }
    }

    IEnumerator LoadBG ()
	{
		WWW f = new WWW ("file://" + Game.currConf.CurrentCondition.BgImagePath);
		yield return f;
		if (string.IsNullOrEmpty (f.error) && f.texture != null) {
			BGrenderer.sharedMaterial.mainTexture = f.texture;
			BGrenderer.gameObject.SetActive (true);
		}
	}

	IEnumerator StartGame ()
	{


		var ballHolderNum = int.Parse (ballHolder.name [ballHolder.name.Length - 1].ToString ());
		var throwTo = 1;
		if (ballHolderNum == 2 && Game.currConf.CurrentCondition.ShouldSpectate) {// If this is a spectator mode
			throwTo = Random.Range (1, currentPlayerMoves.Count + 2);
			if (throwTo == 2)
				throwTo = Random.Range (3, currentPlayerMoves.Count + 2);
			Debug.Log ("Spectator And Throwing To: " + throwTo);
		} else {// If not spectator mode
			Debug.Log ("GNT: " + (ballHolder.name [ballHolder.name.Length - 1].ToString ()));
		    if (Game.CustomSchedIndex <= 0) // If the current schedule is a Predefined one.
		    {
                // Predefined schedules cannot have custom messages etc in them.
		        throwTo = GetNextTarget(currentPlayerMoves[int.Parse(ballHolder.name[ballHolder.name.Length - 1].ToString())]).nextPlayer;
		        currentThrowDelay = Random.Range(2, 6);
		    }
		    else
		    {
                getNextAfterInstruction:
                var x = GetNextTarget(null);
                throwTo = x.nextPlayer;
                if(throwTo==0)//Getnext Target will have already shown the instruction at this point
                {
                    Debug.Log("Instructions has been shown. Waiting: " + x.instructionDuration);
                    yield return new WaitForSeconds(x.instructionDuration);
                    instructions.gameObject.SetActive(!true);
                    goto getNextAfterInstruction;
                }
		    }
		}
        UnityEngine.Debug.Log("Waiting For:" + currentThrowDelay);
		yield return new WaitForSeconds (currentThrowDelay);
		ThrowTo (currentPlayers [throwTo - 1]);
	}

	TwoInts  GetNextTarget (List<string> moves)
	{
		if (Game.CustomSchedIndex <= 0) {//If the current schedule is a predefined one
	    
			var retval = moves [0].ToCharArray () [Random.Range (0, moves [0].Length)].ToString ();
			//moves [0] = moves [0].Replace (retval, string.Empty);
			moves [0] = moves [0].Remove (moves [0].IndexOf (retval), 1);
			if (moves [0].Length == 0)
				moves.RemoveAt (0);
			//Debug.Log (retval + " - " + moves [0]);
			return new TwoInts ( int.Parse(retval), 0) ;
		} else {
			Debug.Log ("THR: " + throwCount);
			var ballHolderNum = int.Parse (ballHolder.name [ballHolder.name.Length - 1].ToString ());
			/*
			if(throwCount >= Game.CustomSchedThrowCount)
			{
				Application.LoadLevel("ThankYou");
				return 0;
			}
*/
			if (Game.CustomScheduleThrows.Count == 0) {
				var nextRandom = Random.Range (1, int.Parse (Game.currConf.GameMode [0].ToString ()) + 1);
				while (nextRandom == ballHolderNum) {
					nextRandom = Random.Range (1, int.Parse (Game.currConf.GameMode [0].ToString ()) + 1);
				}
				return new TwoInts(nextRandom,0);
			}
			Loop:
			var nextThrow = Game.CustomScheduleThrows [0];
			currentThrowDelay = nextThrow.Delay; //Saving the delay for the next throw.
			Debug.Log("THR_DEL:" + currentThrowDelay);
			if (nextThrow.isChatMessage) {
                if (!nextThrow.IsInstruction)
                {
                    var chatMessage = nextThrow.msg;
                    GameObject.Find(Game.currConf.GameMode[0] + "pl_p" + chatMessage.sender).SendMessage("Say", chatMessage);
                    Game.CustomScheduleThrows.RemoveAt(0);
                    goto Loop;
                }
                else
                {
                    Debug.Log("Instructions are: " + nextThrow.msg.message);
                    Game.CustomScheduleThrows.RemoveAt(0);
                    lblInstructions.text = nextThrow.msg.message;
                    lblInstructions.Commit();
                    instructions.gameObject.SetActive(true);
                    LogInstruction(nextThrow.msg.message, (int)nextThrow.msg.duration);
                    return new TwoInts(0,(int)nextThrow.msg.duration);//Implies an instruction message for now.
                }
			}
			var nextPlayer = Regex.Match (nextThrow.ThrowTo, @"\d+").Value;
			Debug.Log ("NXT: " + nextPlayer);
			Game.CustomScheduleThrows.RemoveAt (0);
			if (ballHolderNum.ToString () != nextPlayer)
				return new TwoInts(int.Parse (nextPlayer),0);
			else {
				if (Game.CustomScheduleThrows.Count == 0) {
					var nextRandom = Random.Range (1, int.Parse (Game.currConf.GameMode [0].ToString ()) + 1);
					while (nextRandom == ballHolderNum) {
						nextRandom = Random.Range (1, int.Parse (Game.currConf.GameMode [0].ToString ()) + 1);
					}
					return new TwoInts(nextRandom,0);
				} else {
					nextPlayer = Regex.Match (Game.CustomScheduleThrows [0].ThrowTo, @"\d+").Value;
					Game.CustomScheduleThrows.RemoveAt (0);
					return new TwoInts(int.Parse (nextPlayer),0);
				}
			}
		}
	}

    private void LogInstruction(string message, int duration)
    {
        log.AppendFormat("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"\n", Game.ParticipantID, DateTime.Now.ToString(), "instruction", message,duration);
        Debug.Log(log);

    }

    private void PrintSched (List<string> list)
	{
		var str = "";
		foreach (string s in list) {
			str += (s + ",");
		}
		Debug.Log (str);
	}

	void PlayerClicked (CyberBoy clickedPlayer)
	{
		if (ballHolder.name.Contains ("p2") && !Game.currConf.CurrentCondition.ShouldSpectate) {			
			++throwsMade;
			lblThrowsMade.text = string.Format ("Throws made: {0:00}", throwsMade);
			lblThrowsMade.Commit ();
			ThrowTo (clickedPlayer);
			LogOwnThrow (int.Parse (clickedPlayer.name.Substring (clickedPlayer.name.Length - 1)));
		}
	}

	void ThrowTo (CyberBoy targetPlayer)
	{

		if (!isThrowing && ballHolder.name != targetPlayer.name) {
			isThrowing = true;

			if (targetPlayer.transform.position.x > ballHolder.transform.position.x)
				ballHolder.SendMessage ("LookRight");
			else
				ballHolder.SendMessage ("LookLeft");

			playBall.transform.position = ballHolder.transform.Find ("Ball").position;

			ballHolder.GetComponent<tk2dSpriteAnimator> ().Play ("throw");
            ballHolder.SendMessage("ThrowPosiBall");
			ballHolder.GetComponent<tk2dSpriteAnimator> ().AnimationEventTriggered +=
	            (tk2dSpriteAnimator a, tk2dSpriteAnimationClip b, int c) =>
	            {
	                if (b.frames[c].eventInt < 4)
	                {
	                    ballHolder.ThrowTrigger(b,c);
                        return;
	                }
				ballHolder.GetComponent<tk2dSpriteAnimator> ().AnimationEventTriggered = null;
				playBall.gameObject.SetActive (true);
				ballHolder.transform.Find ("Ball").gameObject.SetActive (false);
				ballHolder.SendMessage ("BackToIdle");
				playBall.transform.positionTo (1f, targetPlayer.transform.Find ("Ball").position).setOnCompleteHandler (
	                    (AbstractGoTween o) =>
				{
					var whoThrew = ballHolder;
					ballHolder = targetPlayer;
					playBall.gameObject.SetActive (false);
					ballHolder.SendMessage ("CatchIt");
					isThrowing = false;

					BroadcastMessage ("LookToBallHolder", ballHolder);
					++throwCount;
						lblTotalThrows.text = string.Format ("Total Throws: {0:00}", throwCount);
						lblTotalThrows.Commit();
					Debug.Log (throwCount);

					if (ballHolder.name.Contains ("p2")) {
						++throwsTaken;
						lblThrowsTaken.text = string.Format ("Throws taken: {0:00}", throwsTaken);
						lblThrowsTaken.Commit ();
						LogCatch (int.Parse (whoThrew.name.Substring (whoThrew.name.Length - 1)));

					}
					if (!whoThrew.name.Contains ("p2") && !targetPlayer.name.Contains ("p2")) {
						LogNPCThrow (whoThrew, targetPlayer);
					}
					if (Game.CustomSchedIndex != 0 && throwCount >= Game.currConf.ThrowCount) {
						//SaveLog();
						Application.LoadLevel ("ThankYou");
						return;
					}
					if (Game.CustomSchedIndex == 0 && throwCount >= Game.currConf.ThrowCount) {
						//End Game Here
						//SaveLog();
						Application.LoadLevel ("ThankYou");
						return;
					} else if (!ballHolder.name.Contains ("p2") || Game.currConf.CurrentCondition.ShouldSpectate) {
						StartCoroutine ("StartGame");
					}

				}
				);

			};
		} else {
			//StartCoroutine("StartGame");
		}

	}

	void LogNPCThrow (CyberBoy whoThrew, CyberBoy targetPlayer)
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"player{3}-player{4}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "npc-throw", (whoThrew.name.Substring (whoThrew.name.Length - 1)), (targetPlayer.name.Substring (targetPlayer.name.Length - 1)));
	}

	void LogOwnThrow (int toPlayerNum)
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"player-{3}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "throw", toPlayerNum);
		Debug.Log (log);
	}

	void LogCatch (int caughtFrom)
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"player-{3}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "catch", caughtFrom);
		Debug.Log (log);

	}

	void LogChat (string chatMsg)
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"{3}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "chat", chatMsg);
		Debug.Log (log);
	}

	void LogGameStart ()
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"Condition {3}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "game-start", Game.currConf.CurrentConditionName);
	}

	void LogQualtricsID ()
	{
		log.AppendFormat ("\"{0}\",\"{1}\",\"{2}\",\"{3}\"\n", Game.ParticipantID, DateTime.Now.ToString (), "qualtrics-id",Game.ParticipantID);
	}
}


    struct TwoInts
    {
        public int nextPlayer;
        public int instructionDuration;
   

    public TwoInts(int v1, int v2) : this()
    {
        nextPlayer = v1;
        instructionDuration = v2;
    }
}
