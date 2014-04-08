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
}
