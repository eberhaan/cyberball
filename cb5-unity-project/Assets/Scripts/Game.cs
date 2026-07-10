using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UnityEngine;
using Cyberball.Common;

public class Game
{
	public const string VERSION = "5.4.0.2";

	public const string MEDIALAB_SUBJECT_INFO_FILE = @"C:\MediaLab\CurrentSubjectInfo.txt";
		static Game ()
		{
				//PrefsToFile ();
				//FileToPrefs ();

		}

	//New fields

	public static CBConfig currConf;

		

		

		
//	public static string WelcomeMessage
//	{
//		get{
//			return PlayerPrefs.GetString("WELCOME_TEXT");		
//		}
//		set
//		{
//			PlayerPrefs.SetString ("WELCOME_TEXT",value);
//			PlayerPrefs.Save();
//		}
//	}

		public static void SetPlayerColors (string[] colors)
		{
				for (int i=0; i<colors.Length; i++) {
						PlayerPrefs.SetString ("PLAYER_COLOR_" + (i + 1), colors [i]);		
				}
				PlayerPrefs.Save ();
		}

	public static string GetPlayerPicPath (int playerNum)
	{
		return currConf.PlayerDetails[playerNum-1].PlayerPic;
	}

		public static string[] GetPlayerColors ()
		{
				var colors = new []{"","","","","","","","",""};
				for (int i=0; i<colors.Length; i++) {
						colors [i] = PlayerPrefs.GetString ("PLAYER_COLOR_" + (i + 1));
		
				}
				return colors;
		}

		public static Color GetPlayerColor (int playerNum)
		{
				var colStr = PlayerPrefs.GetString ("PLAYER_COLOR_" + playerNum);
				if (string.IsNullOrEmpty (colStr))
						return Color.white;

				//var rgbs = colStr.Split ('#');
		return HexToColor (colStr.Replace("#",string.Empty));
	}

		public static string[] GetNames ()
		{
				var names = new []{"","","","","","","","",""};
				for (int i=0; i<names.Length; i++) {
						names [i] = PlayerPrefs.GetString ("PLAYER_NAME_" + (i + 1));
				}
				return names;
		}

		public static string GetName (int playerNum)
		{
				return PlayerPrefs.GetString ("PLAYER_NAME_" + playerNum) + string.Empty;
		}

		public static bool StatsEnabled {
				get {
						return PlayerPrefs.GetInt ("STATS_ENABLED") == 1;		
				}
				set {
						PlayerPrefs.SetInt ("STATS_ENABLED", value ? 1 : 0);
						PlayerPrefs.Save ();
				}
		}

		public static void SetPlayerNames (string[] tempNames)
		{
				for (int i=0; i<tempNames.Length; i++) {
						PlayerPrefs.SetString ("PLAYER_NAME_" + (i + 1), tempNames [i]);
				}
				PlayerPrefs.Save ();
		}

		

		

		public static string ParticipantID {
				get {
						return PlayerPrefs.GetString ("PARTICIPANT_ID");
				}
				set {
						PlayerPrefs.SetString ("PARTICIPANT_ID", value);
						PlayerPrefs.Save ();
				}
		}

		public static int ConditionCount {
				get {
						return 2;
						return PlayerPrefs.GetInt ("CONTITION_COUNT");
				}
				set {
						PlayerPrefs.SetInt ("CONTITION_COUNT", value);	
						PlayerPrefs.Save ();
				}
		}

		

		public static int CurrentCondition_Old {
				get {
						return PlayerPrefs.GetInt ("CURR_CONDITION");
				}
				set {
						PlayerPrefs.SetInt ("CURR_CONDITION", value);
						PlayerPrefs.Save ();
				}
		}



	public static ScheduleTypes GetScheduleForCondition (int condition)
		{
				return (ScheduleTypes) Enum.Parse (typeof(ScheduleTypes), PlayerPrefs.GetString ("SCHED_FOR_CONDITION_" + condition).Trim());
		}

		public static void  SetScheduleForCondition (int condition, string schedule)
		{
				PlayerPrefs.SetString ("SCHED_FOR_CONDITION_" + condition, schedule);
				PlayerPrefs.Save ();
		}



		public static void PrefsToFile ()
		{
		/*
				var filePath = Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory) + "/cyberball-config.csv";
				StringBuilder configs = new StringBuilder ();

				configs.AppendLine ("NO_OF_PLAYERS," + Mode);
				configs.AppendLine ("MAX_THROWS," + MaxThrows);
				configs.AppendLine ("CHAT_ENABLED," + ChatEnabled);
				configs.AppendLine ("STATS_ENABLED," + StatsEnabled);
				configs.AppendLine ("ID_ENABLED," + AskForId);
				configs.AppendLine ("LOG_PATH," + LogFilePath);
				configs.AppendLine ("IsRandomAssignment," + IsRandomAssignment);
		configs.AppendLine ("CURR_CONDITION," + CurrentConditionName);
				configs.AppendLine ("SCHED_FOR_CONDITION_1," + GetScheduleForCondition (1));
				configs.AppendLine ("SCHED_FOR_CONDITION_2," + GetScheduleForCondition (2));
				configs.AppendLine ("SPECTATE," + IsSpectator);
				configs.AppendLine ("BG_PATH," + BGFilePath);
				configs.AppendLine ("WELCOME_PATH," + WelcomeTextFilePath);
        
				for (int i=0; i<9; i++) {
						configs.AppendLine ("PLAYER_COLOR_" + (i + 1) + "," + PlayerPrefs.GetString ("PLAYER_COLOR_" + (i + 1)));        
				}
				for (int i=0; i<9; i++) {
						configs.AppendLine ("PLAYER_NAME_" + (i + 1) + "," + PlayerPrefs.GetString ("PLAYER_NAME_" + (i + 1)));
				}
				File.WriteAllText (filePath, configs.ToString ());
				*/
		}

		public static void FileToPrefs ()
		{
		/*
				var filePath = Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory) + "/cyberball-config2.csv";
				var configs = File.ReadAllLines (filePath);

				Mode = GetValueFor (configs, "NO_OF_PLAYERS");
				MaxThrows = int.Parse (GetValueFor (configs, "MAX_THROWS"));
				ChatEnabled = bool.Parse (GetValueFor (configs, "CHAT_ENABLED"));
				StatsEnabled = bool.Parse (GetValueFor (configs, "STATS_ENABLED"));
				AskForId = bool.Parse (GetValueFor (configs, "ID_ENABLED"));
				LogFilePath = GetValueFor (configs, "LOG_PATH");
				IsRandomAssignment = bool.Parse (GetValueFor (configs, "IsRandomAssignment"));
		CurrentConditionName =( GetValueFor (configs, "CURR_CONDITION"));
				SetScheduleForCondition (1, GetValueFor (configs, "SCHED_FOR_CONDITION_1"));
				SetScheduleForCondition (2, GetValueFor (configs, "SCHED_FOR_CONDITION_2"));
				IsSpectator = bool.Parse (GetValueFor (configs, "SPECTATE"));
				BGFilePath = GetValueFor (configs, "BG_PATH");
				WelcomeTextFilePath = GetValueFor (configs, "WELCOME_PATH");

				List<string> colors = new List<string> ();
				for (int i=1; i<=9; i++) {
						colors.Add (GetValueFor (configs, "PLAYER_COLOR_" + i));
				}
				SetPlayerColors (colors.ToArray ());

				List<string> names = new List<string> ();
				for (int i=1; i<=9; i++) {
						names.Add (GetValueFor (configs, "PLAYER_NAME_" + i));
				}
				SetPlayerNames (names.ToArray ());

                ParseCustomSchedules(configs);


		    PlayerPrefs.Save ();
		    */
		}

    private static void ParseCustomSchedules(string[] configs)
    {
		/*
        CustomSchedCount = Convert.ToInt32(GetValueFor(configs, "CUSTOM_SCHED_COUNT"));


		var customSchedName = GetCustomScheduleForCondition(CurrentConditionName);
        Debug.Log(("HAHA") + CustomSchedName);
		string[] scheduleconfig;
        if (
			!Enum.IsDefined(typeof(ScheduleTypes),customSchedName)
		    )
        {
            CustomSchedName = customSchedName;
			scheduleconfig = File.ReadAllLines(Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory) + @"\schedule-" + CustomSchedName.Trim() + ".csv");
			CustomSchedIndex = int.Parse(GetValueFor(scheduleconfig, "CUSTOM_SCHED_INDEX_" + customSchedName));
            Debug.Log("CS: " + CustomSchedName + " - " + CustomSchedIndex);
        }
        else
            return;

		var schedThrowCount = int.Parse(GetValueFor(scheduleconfig, "CUSTOM_SCHED_THROWCOUNT_" + CustomSchedIndex));

        List<CBThrow> customThrows = new List<CBThrow>();
        var ballHolder = "Player 1";
            for (int j = 1; j <= schedThrowCount; j++)
            {
                
			var throwTo = GetValueFor(scheduleconfig, "CUSTOM_SCHED_" + CustomSchedIndex + "_THROW_THROWTO_" + j);
			var delay = int.Parse(GetValueFor(scheduleconfig, "CUSTOM_SCHED_" + CustomSchedIndex + "_THROW_DELAY_" + j));
                    
                if(!ballHolder.Contains("Player 2"))
                    customThrows.Add(new CBThrow { Delay = delay,  ThrowTo = Regex.Match(throwTo, @"\d+").Value });
                ballHolder = throwTo;
            }
           
            //Debug.Log(playerThrows.ToArray());


            Game.CustomScheduleThrows = customThrows;

        */
    }

	public static string FileToPrefsXML ()
	{

		try {

			DirectoryInfo d = new DirectoryInfo(Environment.GetFolderPath (Environment.SpecialFolder.DesktopDirectory) + "/cb-files");

            if (d.GetFiles("*.cbe").Count() == 0)
            {
                throw new Exception("No .cbe found");
                return "No .cbe found";
            }
            if (d.GetFiles("*.cbe").Count()>1)
			{
				throw new Exception("Cannot play with multiple configs");
				return "Cannot play with multiple configs";
			}

			var file = d.GetFiles("*.cbe").ToList().OrderByDescending(f=>f.LastWriteTime).SingleOrDefault();

			if(file==null)
			{
				throw new FileNotFoundException("No .cbe file was found at " + d.FullName);
				return "No .cbe file was found at " + d.FullName;
			}

			var fileName = file.FullName;

			currConf = Cyberball.Common.ConfigIO.ReadConfig (fileName);
			//currConf.isChatEnabled = true;
			/*
			BGFilePath = GetValueFor (configs, "BG_PATH");
			WelcomeTextFilePath = GetValueFor (configs, "WELCOME_PATH");
			SetScheduleForCondition (1, GetValueFor (configs, "SCHED_FOR_CONDITION_1"));
			SetScheduleForCondition (2, GetValueFor (configs, "SCHED_FOR_CONDITION_2"));
			*/
			
			List<string> colors = new List<string> ();
			for (int i=1; i<=9; i++) {
				colors.Add (currConf.PlayerDetails [i - 1].PlayerColor);
			}
			SetPlayerColors (colors.ToArray ());
			
			List<string> names = new List<string> ();
			for (int i=1; i<=9; i++) {
				names.Add (currConf.PlayerDetails [i - 1].PlayerName);
			}
			SetPlayerNames (names.ToArray ());
			

			//ParseCustomSchedulesXML ();
			
			
			PlayerPrefs.Save ();
		} catch (Exception ex) {
			return ex.Message;
		}
		return string.Empty;
	}

	public static void ParseCustomSchedulesXML ()
	{
		var currentCondition = currConf.CurrentCondition;
		if (
			currentCondition.ScheduleType.HasValue
			)
		{
			return; // This is a built in schedule. We do not need to do anything
		}

		Game.CustomSchedIndex = 1;

		List<CBThrow> customThrows = new List<CBThrow>();
		var ballHolder = "Player 1";
		for (int j = 0; j < currentCondition.CustomSchedule.throws.Count; j++)
		{
			var throwTo = currentCondition.CustomSchedule.throws[j].ThrowTo + "";
			var delay = currentCondition.CustomSchedule.throws[j].Delay;
			
			if(!ballHolder.Contains("Player 2") || currentCondition.CustomSchedule.throws[j].isChatMessage)
				customThrows.Add(currentCondition.CustomSchedule.throws[j]);
			if(!currentCondition.CustomSchedule.throws[j].isChatMessage)
			{
			ballHolder = throwTo;
				++Game.CustomSchedThrowCount;
			}
		}
		//Debug.Log(playerThrows.ToArray());
		Game.CustomScheduleThrows = customThrows;
		Debug.Log ("tHROWS nEEDED: " + Game.CustomSchedThrowCount);
	}

	static string GetCustomScheduleForCondition (int currentCondition)
	{
		return PlayerPrefs.GetString ("SCHED_FOR_CONDITION_" + currentCondition).Trim ();
	}

    public static List<CBThrow> CustomScheduleThrows { get; set; }

    public static int CustomSchedIndex { get; set; }

    public static string CustomSchedName { get; set; }

    public static int CustomSchedCount {
        get { return PlayerPrefs.GetInt("CUSTOM_SCHED_COUNT"); }
        set { PlayerPrefs.SetInt("CUSTOM_SCHED_COUNT", value); PlayerPrefs.Save(); }
    }

    static string GetValueFor (string[] configs, string key)
		{
				var row = configs.Where (s => s.StartsWith (key + ",")).Single ();
		var value = 	row.Substring (row.IndexOf (",") + 1);	
		Debug.Log (key + "-" + value);
		return value;
		}
	// Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.

    static Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

	public static int CustomSchedThrowCount {
		get;
		set;
	}
}
