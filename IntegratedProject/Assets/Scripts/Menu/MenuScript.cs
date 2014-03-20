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
    public Texture2D HelpScreen, CreditsScreen;

	void Start ()
	{
        myskin = DataStore.DT.skin;
		currentMenu = "Main";
        screenHeight = Screen.height;
        screenWidth = Screen.width;
	}

	void OnGUI()
	{
        GUI.skin = myskin;

		if(currentMenu == "Main")
		{
			Menu_Main();
		}

		if(currentMenu == "Settings")
		{
			Menu_Settings();
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
            Application.LoadLevel(1);
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

	private void Menu_Settings()
	{
        if (GUI.Button(new Rect((screenWidth - 120), (screenHeight - 40), 200, 60), "Back"))
		{
			SwitchTo("Main");
		}
		
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
