using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	public Texture2D cursorImage; //variable which will hold the custom cursor texture
	public Texture2D cursorNPC; //variable which will hold the custom cursor texture when mouse is over a NPC
	public int cursorDimensions = 20; // x and y dimensions for displaying the cursor
	public bool mouseOverPlayerCheck;

	
	void Start()
	{
		Screen.showCursor = false; //turns off the default windows cursor from displaying
	}

	void OnGUI()
	{
		if (mouseOverPlayerCheck == false) 
		{
			GUI.DrawTexture (new Rect (Input.mousePosition.x - cursorDimensions / 2, Screen.height - Input.mousePosition.y - cursorDimensions / 2, cursorDimensions, cursorDimensions), cursorImage);
		}
	}

	void OnMouseEnter() 
	{
		mouseOverPlayerCheck = true;
	}

	void OnMouseExit() 
	{
		mouseOverPlayerCheck = false;
	}
}
