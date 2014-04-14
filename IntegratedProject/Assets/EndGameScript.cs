using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

    GUISkin myskin;
    private GameObject MyCamera;
    private Vector3 screenPos;
    public Texture2D clydesprite;
    private Rect clydeRect;
    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;
    bool guiEnabled = false;
    public Transform target;

	// Use this for initialization
	void Start () 
    {
        myskin = DataStore.DT.skin;
        clydeRect = new Rect(10, 50, 190, 356);
	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (DecoratorUpgrade.decorationsUpgraded == true && GardenerUpgrade.gardensUpgraded == true && BuilderUpgrade.housesUpgraded == true)
        {
            Time.timeScale = 0;
            guiEnabled = true;
        }
	
	}

    void OnGUI()
    {
        GUI.skin = myskin;

        GUI.Box(new Rect(200, 100, 500, 100), DataStore.DT.PlayerName + " Well done you completed the Athletes Village on time!");
        GUI.DrawTexture(clydeRect, clydesprite, ScaleMode.StretchToFill, true, 10.0F);
        if (GUI.Button(new Rect((screenWidth - 225), (screenHeight - 75), 200, 60), "End Game"))
        {
            Time.timeScale = 1;
            Application.LoadLevel(0);
        }

    }
}
