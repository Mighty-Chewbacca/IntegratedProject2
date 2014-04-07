// resources used;  http://answers.unity3d.com/questions/323195/how-can-i-have-a-static-class-i-can-access-from-an.html
// 					http://unitygems.com/saving-data-1-remember-me/
//					http://www.dotnetperls.com/list
//					http://www.dotnetperls.com/enum
//					http://support.microsoft.com/kb/816149
//					http://stackoverflow.com/questions/1968328/read-numbers-from-a-text-file-in-c-sharp
//					http://stackoverflow.com/questions/29482/cast-int-to-enum-in-c-sharp

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
    //core stuff, don't reset these
    public static DataStore DT;
    public GUISkin skin;
    public static Dictionary<string, string> NPCText = new Dictionary<string, string>();
    public enum Gender { male, female };

    //duno' what's this
    public static Dictionary<string, int> HUBBuildings = new Dictionary<string, int>();
    public int NPCCount;

    //player relevant stuff, needs to be reseted when starting new game
    public int score;
    public string PlayerProgress = "";
    public string checkpoint = "MoveSign";
    public string PlayerName = "";
    public Gender PlayerGender = Gender.male; //defaults to male
    public static Dictionary<string, short> PlayerInventory = new Dictionary<string, short>();




    void Awake()
    {
        if (DT != null)
            GameObject.Destroy(DT);
        else
            DT = this;

        DontDestroyOnLoad(this);
    }



    //save all stuff to file, line by line

    public void SaveToFile()
    {

        //Pass the filepath and filename to the StreamWriter Constructor
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "//" + "SaveGame_1" + ".save");


        sw.WriteLine(score);
        sw.WriteLine(PlayerProgress);
        sw.WriteLine(checkpoint);
        sw.WriteLine(PlayerName);
        sw.WriteLine(PlayerGender);
        sw.WriteLine(DataStore.PlayerInventory["can"]);
        sw.WriteLine(DataStore.PlayerInventory["bottle"]);
        sw.WriteLine(DataStore.PlayerInventory["paper"]);

        //Close the file
        sw.Close();
    }

    //load all data back from file	
    public void LoadFromFile()
    {
        using (TextReader reader = File.OpenText(Application.persistentDataPath + "//" + "SaveGame_1" + ".save"))
        {
            DataStore.DT.score = int.Parse(reader.ReadLine());
            DataStore.DT.PlayerProgress = reader.ReadLine();
            DataStore.DT.checkpoint = reader.ReadLine();
            DataStore.DT.PlayerName = reader.ReadLine();
            DataStore.DT.PlayerGender = (Gender)Enum.Parse(typeof(Gender), reader.ReadLine());
            DataStore.PlayerInventory["can"] = short.Parse(reader.ReadLine());
            DataStore.PlayerInventory["bottle"] = short.Parse(reader.ReadLine());
            DataStore.PlayerInventory["paper"] = short.Parse(reader.ReadLine());
        }

        Inventory.can = DataStore.PlayerInventory["can"];
        Inventory.bottle = DataStore.PlayerInventory["bottle"];
        Inventory.paper = DataStore.PlayerInventory["paper"];
        Debug.Log(DataStore.PlayerInventory["paper"]);

    }

    public void ResetPlayer()
    {

        //reset player relevant values in DT

        DataStore.DT.score = 0;
        DataStore.DT.PlayerProgress = "";
        DataStore.DT.checkpoint = "MoveSign"; //THIS SHOULD BE CHANGED TO THE VERY FIRST, DEFAULT CHECKPOINT
        DataStore.DT.PlayerName = "";
        DataStore.DT.PlayerGender = DataStore.Gender.male; //defaults to male

        DataStore.PlayerInventory["can"] = 0;
        DataStore.PlayerInventory["bottle"] = 0;
        DataStore.PlayerInventory["paper"] = 0;

        //sync this with the current inventory

        Inventory.can = DataStore.PlayerInventory["can"];
        Inventory.bottle = DataStore.PlayerInventory["bottle"];
        Inventory.paper = DataStore.PlayerInventory["paper"];



    }

    /* NOT IN USE any longer
        public void SavaToFile0(string fileName)
            {
            Debug.Log("save methood begins");
                //Get a binary formatter
                var b = new BinaryFormatter();
                //Create a file
                var f = File.Create(Application.persistentDataPath + "/" + fileName + ".dat");
                //Save player relevant date			
                //b.Serialize(f, source);

                        b.Serialize(f,score);
                        b.Serialize(f,PlayerProgress);
                        b.Serialize(f,checkpoint);
                        b.Serialize(f,PlayerName);
                        b.Serialize (f, PlayerGender);
                        b.Serialize (f, PlayerInventory);
			

                //close file
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

    */






}