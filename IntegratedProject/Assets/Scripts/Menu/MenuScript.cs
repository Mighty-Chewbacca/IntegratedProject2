using UnityEngine;
using System.Collections;

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
    public Texture2D HelpScreen, CreditsScreen, maleSprite, femaleSprite, playerSprite;
    private string nameInput;
    public bool nameEntered, genderChosen;

	void Start ()
	{
        myskin = DataStore.DT.skin;
		currentMenu = "Main";
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        nameEntered = false;
        genderChosen = false;
	}

	void OnGUI()
	{
        GUI.skin = myskin;

		if(currentMenu == "Main")
		{
			Menu_Main();
		}

        if (currentMenu == "Play")
        {
            Menu_Play();
        }

		if(currentMenu == "Credits")
		{
			Menu_Credits();
		}

        if (currentMenu == "Help")
        {
            Menu_Help();
        }

	}

    //creation for the main menu
	private void Menu_Main()
	{
		if(GUI.Button (new Rect((screenWidth/2 - 75), (screenHeight/2), 200, 60),"Play"))
		{
            SwitchTo("Play");         
		}

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 60), 200, 60), "Credits"))
		{
			SwitchTo("Credits");
		}

        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 120), 200, 60), "Help"))
		{
			SwitchTo("Help");
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

        //only start if name and gender are chosen
        if (GUI.Button(new Rect((100), (screenHeight - 60), 200, 60), "Start Game"))
        {
            if (genderChosen)
            {
                Application.LoadLevel(1);
            }
        }

        //// save name button
        //if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 60), 200, 60), "Enter"))
        //{
        //    DataStore.DT.PlayerName = nameInput;
        //    nameEntered = true;
        //}

        //girl button     
        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 120), 200, 60), "Girl"))
        {
            DataStore.DT.PlayerGender = DataStore.Gender.female;
            genderChosen = true;
        }
        //boy button
        if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 180), 200, 60), "Boy"))
        {
            DataStore.DT.PlayerGender = DataStore.Gender.male;
            genderChosen = true;
        }

        GUI.DrawTexture(new Rect((screenWidth - 235), (screenHeight - 440), 190, 356), playerSprite, ScaleMode.StretchToFill, true, 10.0F);
        GUI.Label(new Rect((screenWidth / 2 - 75), (screenHeight / 2 ), 200, 40), "Please choose your gender below!");
        //GUI.Label(new Rect((screenWidth / 2 - 75), (screenHeight / 2 - 40), 200, 40), "Please enter your name below! Maximum of 8 letters!");
        //nameInput = GUI.TextField(new Rect((screenWidth / 2 - 75), (screenHeight / 2), 200, 60), nameInput, 8);
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

    //used to switch between the different menus
	public void SwitchTo(string nextmenu)
	{
		currentMenu = nextmenu;
	}
}
