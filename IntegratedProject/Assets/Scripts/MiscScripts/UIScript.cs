using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour
{
	public Texture2D heart, emptyHeart, can, bottle, paper;
	//public Inventory playersInv;
	public HealthScript playersHealth;
	public GameObject canText, bottleText, paperText;
    public int screenHeight, screenWidth;


	
	// Use this for initialization
	void Start ()
	{
        screenHeight = Screen.height;
        screenWidth = Screen.width;
	}
	
	// Update is called once per frame
	void Update ()
	{
		canText.guiText.text = " " + Inventory.can;
		bottleText.guiText.text = " " + Inventory.bottle;
		paperText.guiText.text = " " + Inventory.paper;
		
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
		GUI.DrawTexture(new Rect((screenWidth - 280), 10, 40, 40), can, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 200), 10, 60, 40), bottle, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 100), 10, 60, 40), paper, ScaleMode.StretchToFill, true, 10.0F);
    }

    void DrawHealth()
    {
        switch (playersHealth.health)
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