// resources used;  http://answers.unity3d.com/questions/323195/how-can-i-have-a-static-class-i-can-access-from-an.html
// 					http://unitygems.com/saving-data-1-remember-me/
//					http://www.dotnetperls.com/list
//					http://www.dotnetperls.com/enum

//You must include these namespaces
//to use BinaryFormatter
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class DataStore : MonoBehaviour
{
	public static DataStore DT;


	public GUISkin skin;
	public int score;

	public string PlayerProgress = "almost done";
	public int NPCCount;
	public string checkpoint = "MoveSign";


	public static Dictionary<string,string> NPCText = new Dictionary<string,string>();

	public string PlayerName = "";
	public enum Gender {male, female};
	public Gender PlayerGender = Gender.male; //defaults to male

	public static Dictionary<string,short> PlayerInventory = new Dictionary<string,short>();

	public static Dictionary<string,int> HUBBuildings = new Dictionary<string,int>();


	void Awake()
	{
		if(DT != null)
			GameObject.Destroy(DT);
		else
			DT = this;
		
		DontDestroyOnLoad(this);
	}



	//save stuff to file
	public void SavaToFile(object source, string fileName)
		{
		Debug.Log("save methood begins");
			//Get a binary formatter
			var b = new BinaryFormatter();
			//Create a file
			var f = File.Create(Application.persistentDataPath + "/" + fileName + ".dat");
			//Save the scores
			b.Serialize(f, source);
			f.Close();
		Debug.Log("save method ended");
		}

	//load data back from file
	public object LoadData(string objectName)
	{
		var output = new object();

		Debug.Log("load methood begins");

		//Binary formatter for loading back
			var b = new BinaryFormatter();
		//Get the file
			var f = File.Open(Application.persistentDataPath + "/" + objectName + ".dat", FileMode.Open);
		//Load back the scores
		output = b.Deserialize(f);
			f.Close();
        Debug.Log("load methood ends");
		return output;		
	}







}