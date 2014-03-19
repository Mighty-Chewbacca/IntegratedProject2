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
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect((screenWidth - 280), 10, 40, 40), can, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 200), 10, 60, 40), bottle, ScaleMode.StretchToFill, true, 10.0F);
		GUI.DrawTexture(new Rect((screenWidth - 100), 10, 60, 40), paper, ScaleMode.StretchToFill, true, 10.0F);
	}
}