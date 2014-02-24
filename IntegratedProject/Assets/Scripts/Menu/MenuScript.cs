using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{

	public string currentMenu;

	void Start ()
	{
		currentMenu = "Main";
	}

	void OnGUI()
	{
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

	}

	private void Menu_Main()
	{
		GUI.Box(new Rect(20, 40, 100, 20), "Play");
		GUI.Box(new Rect(20, 70, 100, 20), "Credits");
		GUI.Box(new Rect(20, 100, 100, 20), "Exit");

		if(GUI.Button (new Rect(20, 40, 100, 20),"Play"))
		{
            Application.LoadLevel(1);
		}

		if(GUI.Button (new Rect(20, 70, 100, 20),"Credits"))
		{
			Navigate("Credits");
		}

		if(GUI.Button (new Rect(20, 100, 100, 20),"Exit"))
		{
			Application.Quit();
		}
	}

	private void Menu_Settings()
	{
		if(GUI.Button (new Rect(20, 130, 100, 20),"Back"))
		{
			Navigate("Main");
		}
		
	}

	private void Menu_Credits()
	{
		if(GUI.Button (new Rect(20, 160, 100, 20),"Back"))
		{
			Navigate("Main");
		}
		
	}

	public void Navigate(string nextmenu)
	{
		currentMenu = nextmenu;
	}
}
