using UnityEngine;
using System.Collections;

//helpers include -- http://answers.unity3d.com/questions/542356/touching-a-gui-texture.html

public class MenuScript : MonoBehaviour
#region tutorials
//used youtube tutorial for this but modified to work for us
//http://www.youtube.com/watch?v=50Ry2z_6E2Y
// and the following forum post(s)
//http://answers.unity3d.com/questions/220291/drawtexture-background-fit-screen.html
#endregion

{

	public string currentMenu;
    private int screenHeight, screenWidth;
    private GUISkin myskin;
    public Texture2D HelpScreen, CreditsScreen, MainScreen, PlayerScreen, maleSprite, femaleSprite, playerSprite;
    private string nameInput = "";
    public bool nameEntered, genderChosen;
    Rect maleRect, femaleRect;
    Vector2 mouse;

	void Start ()
	{
        CreateDictionaryEntries();
        myskin = DataStore.DT.skin;
		currentMenu = "Main";
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        nameEntered = false;
        genderChosen = false;
        maleRect = new Rect(65, (screenHeight - 400), 190, 356);
        femaleRect = new Rect((screenWidth - 235), (screenHeight - 400), 190, 356);
        //DataStore.DT.ResetPlayer();
        //DataStore.DT.SaveToFile();
	}

    void Update()
    {
        //get the current mouse pos
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        //check if the male sprite has been chosen (only in play menu)
        if (maleRect.Contains(mouse) && Input.GetMouseButtonDown(0) && currentMenu == "Play")
        {
            DataStore.DT.PlayerGender = DataStore.Gender.male;
            Application.LoadLevel(1);
        }

        //check if the female sprite has been chosen (only in play menu)
        if (femaleRect.Contains(mouse) && Input.GetMouseButtonDown(0) && currentMenu == "Play")
        {
            DataStore.DT.PlayerGender = DataStore.Gender.female;
            Application.LoadLevel(1);
        }
    }

    void OnGUI()
    {
        GUI.skin = myskin;

        if (currentMenu == "Main")
        {
            Menu_Main();
        }

        if (currentMenu == "Play")
        {
            Menu_Play();
        }

        if (currentMenu == "Credits")
        {
            Menu_Credits();
        }

        if (currentMenu == "Help")
        {
            Menu_Help();
        }
        if (currentMenu == "Load")
        {
            Menu_Load();
        }
        if (currentMenu == "Name")
        {
            Menu_Name();
        }
    }

    //creation for the main menu
	private void Menu_Main()
	{
        GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), MainScreen);

		if(GUI.Button (new Rect((screenWidth/2 - 75), (screenHeight/2), 200, 60),"Play"))
		{
            SwitchTo("Name");         
		}

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 60), 200, 60), "Credits"))
		{
			SwitchTo("Credits");
		}

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 120), 200, 60), "Help"))
		{
			SwitchTo("Help");
		}

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 240), 200, 60), "Load"))
        {
            SwitchTo("Load");
        }

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 180), 200, 60), "Exit"))
        {
            Application.Quit();
        }
	}


    //play menu will let player type their name, and choose a gender for their character
    private void Menu_Play()
    {
        if (DataStore.DT.PlayerGender == DataStore.Gender.male)
        {
            playerSprite = maleSprite;
        }
        if (DataStore.DT.PlayerGender == DataStore.Gender.female)
        {
            playerSprite = femaleSprite;
        }
        //go back to main menu
        if (GUI.Button(new Rect((screenWidth - 240), (screenHeight - 60), 200, 60), "Back"))
        {
            SwitchTo("Main");
        }
        GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), PlayerScreen);
        GUI.DrawTexture(femaleRect, femaleSprite, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(maleRect, maleSprite, ScaleMode.StretchToFill, true, 10.0F);
        GUI.Box(new Rect((screenWidth / 2 - 75), (screenHeight / 2 ), 200, 80), "Please choose your gender!");

    }


    //gui stuff for the credits screen
	private void Menu_Credits()
	{
        GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), CreditsScreen);

        if (GUI.Button(new Rect((screenWidth - 240), (screenHeight - 60), 200, 60), "Back"))
        {
            SwitchTo("Main");
        }
		
	}

    //gui stuff for the help screen
    private void Menu_Help()
    {
        GUI.DrawTexture(new Rect (0,0, screenWidth, screenHeight), HelpScreen);

        if (GUI.Button(new Rect((screenWidth - 240), (screenHeight - 60), 200, 60), "Back"))
        {
            SwitchTo("Main");
        }

    }

    //gui stuff for the load screen
    private void Menu_Load()
    {

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 120), 200, 60), "Load Game"))
        {
            DataStore.DT.LoadFromFile();
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 180), 200, 60), "Delete save"))
        {
            DataStore.DT.ResetPlayer();
            DataStore.DT.SaveToFile();
            SwitchTo("Main");
        }
        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 60), 200, 60), "Return"))
        {
            SwitchTo("Main");
        }

    }

    void Menu_Name()
    {
        GUI.DrawTexture(new Rect(0, 0, screenWidth, screenHeight), MainScreen);

        // save name button
        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 -140), 200, 60), "Enter"))
        {
            DataStore.DT.PlayerName = nameInput;
            SwitchTo("Play");
        }



        if (GUI.Button(new Rect((screenWidth - 240), (screenHeight - 60), 200, 60), "Back"))
        {
            SwitchTo("Main");
        }

        GUI.Box(new Rect((100), (screenHeight / 2- 40), 500, 100), "Please enter your name above! Maximum of 8 letters!");
        nameInput = GUI.TextField(new Rect((screenWidth / 2 - 75), (screenHeight / 2 - 200), 200, 60), nameInput, 8);
    }

    //used to switch between the different menus
	public void SwitchTo(string nextmenu)
	{
		currentMenu = nextmenu;
	}

    void CreateDictionaryEntries()
    {
        //set up Player Inventory (in case there's no saved data)
        // first parameter is the name of the object the second is the amount

        if (!DataStore.PlayerInventory.ContainsKey("can")) { DataStore.PlayerInventory.Add("can", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("bottle")) { DataStore.PlayerInventory.Add("bottle", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("paper")) { DataStore.PlayerInventory.Add("paper", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("keys")) { DataStore.PlayerInventory.Add("keys", 0); }
        if (!DataStore.HUBBuildings.ContainsKey("houses")) { DataStore.HUBBuildings.Add("houses", 0); }
        if (!DataStore.HUBBuildings.ContainsKey("gardens")) { DataStore.HUBBuildings.Add("gardens", 0); }
        if (!DataStore.HUBBuildings.ContainsKey("decorations")) { DataStore.HUBBuildings.Add("decorations", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("hammer")) { DataStore.PlayerInventory.Add("hammer", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("trowel")) { DataStore.PlayerInventory.Add("trowel", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("paintbrush")) { DataStore.PlayerInventory.Add("paintbrush", 0); }

        //set up NPC dialogs
        // first parameter is the name of the object the second is the dialogue
        if (!DataStore.NPCText.ContainsKey("PickObject")) { DataStore.NPCText.Add("PickObject", "press 'E' to lift up some objects!"); }
        if (!DataStore.NPCText.ContainsKey("DropObject")) { DataStore.NPCText.Add("DropObject", "Press 'E' again to drop them."); }
        if (!DataStore.NPCText.ContainsKey("JumpSign")) { DataStore.NPCText.Add("JumpSign", "Press Space to jump"); }
        if (!DataStore.NPCText.ContainsKey("MoveSign")) { DataStore.NPCText.Add("MoveSign", "Use A and D to move Left/Right!"); }
        if (!DataStore.NPCText.ContainsKey("MovingPSign")) { DataStore.NPCText.Add("MovingPSign", "Some Platforms even move!"); }
        if (!DataStore.NPCText.ContainsKey("PickupsSign")) { DataStore.NPCText.Add("PickupsSign", "You should pick up all rubbish!"); }
        if (!DataStore.NPCText.ContainsKey("EnemySign")) { DataStore.NPCText.Add("EnemySign", "This wee guy takes off 1 heart!"); }
        if (!DataStore.NPCText.ContainsKey("AttackSign")) { DataStore.NPCText.Add("AttackSign", "Click the mouse to attack!"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign")) { DataStore.NPCText.Add("DoorSign", "Get a key to unlock the door!"); }
        if (!DataStore.NPCText.ContainsKey("TeleSign")) { DataStore.NPCText.Add("TeleSign", "RightClick to go back to level 1"); }
        if (!DataStore.NPCText.ContainsKey("FruitSign")) { DataStore.NPCText.Add("FruitSign", "This Fruit can heal you!"); }
        if (!DataStore.NPCText.ContainsKey("CheckPoint1")) { DataStore.NPCText.Add("CheckPoint1", "Signs like me save your progress!"); }
        if (!DataStore.NPCText.ContainsKey("EndTutSign")) { DataStore.NPCText.Add("EndTutSign", "Now you're on your own! Collect as much trash as possible!"); }
        if (!DataStore.NPCText.ContainsKey("HubTeleportSign")) { DataStore.NPCText.Add("HubTeleportSign", "Right Click to go to the HUB!"); }


        //chat for the sign that teaches how to unlock a door
        #region doorUnlock
        if (!DataStore.NPCText.ContainsKey("DoorSign0")) { DataStore.NPCText.Add("DoorSign0", "Use your key to open this!"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign1")) { DataStore.NPCText.Add("DoorSign1", "You can get a key from the HUB"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign2")) { DataStore.NPCText.Add("DoorSign2", "Press 'action' to open the door"); }
        #endregion

        // chat for keymaster in hub
        #region keymaster
        if (!DataStore.NPCText.ContainsKey("KeyMaster0")) { DataStore.NPCText.Add("KeyMaster0", "Hi there, I'm the Keyman!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster1")) { DataStore.NPCText.Add("KeyMaster1", "I make you keys from cans"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster2")) { DataStore.NPCText.Add("KeyMaster2", "A key will cost you 5 cans!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster3")) { DataStore.NPCText.Add("KeyMaster3", "would you like one?"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster4")) { DataStore.NPCText.Add("KeyMaster4", "Thank you!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster5")) { DataStore.NPCText.Add("KeyMaster5", "All recycling helps the city"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster6")) { DataStore.NPCText.Add("KeyMaster6", "You dont have enough cans"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster7")) { DataStore.NPCText.Add("KeyMaster7", "Come back later!"); }

        #endregion

        //clyde in hub chats
        #region Clyde(hub)
        if (!DataStore.NPCText.ContainsKey("ClydeH0")) { DataStore.NPCText.Add("ClydeH0", "Hi there"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH1")) { DataStore.NPCText.Add("ClydeH1", "Welcome to the athletes village!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH2")) { DataStore.NPCText.Add("ClydeH2", "Its not really done yet though"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH3")) { DataStore.NPCText.Add("ClydeH3", "Could you help me finish it?"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH4")) { DataStore.NPCText.Add("ClydeH4", "Thank you! we really need to look the best"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH5")) { DataStore.NPCText.Add("ClydeH5", "the CommonWealth games are coming soon!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH6")) { DataStore.NPCText.Add("ClydeH6", "Collect recycling for the workers"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH7")) { DataStore.NPCText.Add("ClydeH7", "talk to them and they will get to work!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH8")) { DataStore.NPCText.Add("ClydeH8", "Together we can leave a lasting legacy!"); }

        #endregion

        //clyde in tutorial chats
        #region Clyde(tutorial)
        if (!DataStore.NPCText.ContainsKey("ClydeT0")) { DataStore.NPCText.Add("ClydeT0", "Hi there"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT1")) { DataStore.NPCText.Add("ClydeT1", "Congrats on getting through the tutorial!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT2")) { DataStore.NPCText.Add("ClydeT2", "I'm Clyde, the Glasgow 2014 Mascot!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT3")) { DataStore.NPCText.Add("ClydeT3", "I really need your help"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT4")) { DataStore.NPCText.Add("ClydeT4", "Meet me back at the HUB to help me"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT5")) { DataStore.NPCText.Add("ClydeT5", "Oh silly me!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT6")) { DataStore.NPCText.Add("ClydeT6", "The Athletes village is the HUB!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT7")) { DataStore.NPCText.Add("ClydeT7", "Swing by and say high later!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT8")) { DataStore.NPCText.Add("ClydeT8", "Oh before i forget,"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT9")) { DataStore.NPCText.Add("ClydeT9", "Here is your key to continue!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT10")) { DataStore.NPCText.Add("ClydeT10", "I already gave you your key!"); }

        #endregion

        // Builder chats
        #region Builder
        if (!DataStore.NPCText.ContainsKey("Builder0")) { DataStore.NPCText.Add("Builder0", "Talk to me to upgrade the Houses"); }
        if (!DataStore.NPCText.ContainsKey("Builder1")) { DataStore.NPCText.Add("Builder1", "It will cost you 5 paper and a hammer!"); }
        if (!DataStore.NPCText.ContainsKey("Builder2")) { DataStore.NPCText.Add("Builder2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Builder3")) { DataStore.NPCText.Add("Builder3", "Congratulations you have helped me build them!"); }
        if (!DataStore.NPCText.ContainsKey("Builder4")) { DataStore.NPCText.Add("Builder4", "Sorry, you dont have enough Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder5")) { DataStore.NPCText.Add("Builder5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Builder6")) { DataStore.NPCText.Add("Builder6", "Come back when you get it!"); }
        if (!DataStore.NPCText.ContainsKey("Builder7")) { DataStore.NPCText.Add("Builder7", "The houses are already finished!"); }
        if (!DataStore.NPCText.ContainsKey("Builder8")) { DataStore.NPCText.Add("Builder8", "Sorry, you still need my hammer!"); }
        #endregion

        // gardener chats
        #region Gardener
        if (!DataStore.NPCText.ContainsKey("Gardener0")) { DataStore.NPCText.Add("Gardener0", "Talk to me to upgrade the gardens"); }
        if (!DataStore.NPCText.ContainsKey("Gardener1")) { DataStore.NPCText.Add("Gardener1", "It will cost you 5 Bottles"); }
        if (!DataStore.NPCText.ContainsKey("Gardener2")) { DataStore.NPCText.Add("Gardener2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Gardener3")) { DataStore.NPCText.Add("Gardener3", "Congratulations, the Gardens are done!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener4")) { DataStore.NPCText.Add("Gardener4", "Sorry, you dont have enough Bottles!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener5")) { DataStore.NPCText.Add("Gardener5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener6")) { DataStore.NPCText.Add("Gardener6", "Come back when you get it!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener7")) { DataStore.NPCText.Add("Gardener7", "Sorry you still need my trowel!"); }
        #endregion

        // decorator chats
        #region Decorator
        if (!DataStore.NPCText.ContainsKey("Decorator0")) { DataStore.NPCText.Add("Decorator0", "Talk to me to upgrade decorations"); }
        if (!DataStore.NPCText.ContainsKey("Decorator1")) { DataStore.NPCText.Add("Decorator1", "It will cost you 5 Paper"); }
        if (!DataStore.NPCText.ContainsKey("Decorator2")) { DataStore.NPCText.Add("Decorator2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Decorator3")) { DataStore.NPCText.Add("Decorator3", "Congratulations, the decorations are done!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator4")) { DataStore.NPCText.Add("Decorator4", "Sorry, you dont have enough Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator5")) { DataStore.NPCText.Add("Decorator5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator6")) { DataStore.NPCText.Add("Decorator6", "Come back when you get it!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator7")) { DataStore.NPCText.Add("Decorator7", "Sorry you still need my paintbrush!"); }
        #endregion

    }
}
