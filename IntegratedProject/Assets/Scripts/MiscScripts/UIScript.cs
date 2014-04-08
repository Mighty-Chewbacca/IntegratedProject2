using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
	public Texture2D heart, emptyHeart, can, bottle, paper, key, BG;
    public int screenHeight, screenWidth;

	// Use this for initialization
	void Start ()
	{
        screenHeight = Screen.height;
        screenWidth = Screen.width;

	}
	
    //called once per frame, used to draw ui on screen
    //draws health and inventory, still to add weapon indicator
	void OnGUI()
	{
        DrawUI();
        DrawHealth();
	}

    void DrawUI()
    {
        GUI.DrawTexture(new Rect((screenWidth - 390), 5, 100, 80), BG, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect((screenWidth - 285), 5, 60, 80), BG, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect((screenWidth - 110), 5, 80, 80), BG, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect((screenWidth - 210), 5, 80, 80), BG, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 275), 10, 40, 40), can, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 200), 10, 60, 40), bottle, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 100), 10, 60, 40), paper, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect((screenWidth - 380), 10, 80, 40), key, ScaleMode.StretchToFill, true, 10.0F);

        GUI.Box(new Rect((screenWidth - 275), 50, 40, 35), "X " + Inventory.can);
        GUI.Box(new Rect((screenWidth - 200), 50, 40, 35), "X " + Inventory.bottle);
        GUI.Box(new Rect((screenWidth - 100), 50, 40, 35), "X " + Inventory.paper);
        GUI.Box(new Rect((screenWidth - 380), 50, 40, 35), "X " + Inventory.keys);
    }

    void DrawHealth()
    {
        switch (HealthScript.health)
        {
            case 4:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(190, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                break;

            case 3:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(190, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                break;

            case 2:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(190, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                break;

            case 1:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(190, 10, 60, 60), emptyHeart, ScaleMode.StretchToFill, true, 10.0F);
                break;
        }
    }
}