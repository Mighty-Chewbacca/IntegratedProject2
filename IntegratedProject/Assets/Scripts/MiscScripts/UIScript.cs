using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour 
{
    public Texture2D heart, emptyHeart, can, bottle, paper;
    public Inventory playersInv;
    public HealthScript playersHealth;
    public GameObject canText, bottleText, paperText;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        canText.guiText.text = " " + playersInv.can;
        bottleText.guiText.text = " " + playersInv.bottle;
        paperText.guiText.text = " " + playersInv.paper;
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(1010, 10, 40, 40), can, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect(1200, 10, 60, 40), bottle, ScaleMode.StretchToFill, true, 10.0F);
        GUI.DrawTexture(new Rect(1380, 10, 60, 40), paper, ScaleMode.StretchToFill, true, 10.0F);
    }
}
