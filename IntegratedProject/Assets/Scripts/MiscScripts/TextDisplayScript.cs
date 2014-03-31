/*
used materials; http://www.youtube.com/watch?v=NOWfloaxDX4
used materials; http://www.youtube.com/watch?v=myQcCCa4jlM

*/

using UnityEngine;
using System.Collections;

//show GUI stuff in dev. mode
[ExecuteInEditMode]

public class TextDisplayScript : MonoBehaviour {

	//declarations

	public GUISkin myskin;

	private bool guiEnabled = false;
	private GameObject MyCamera; 
	public Transform target;
	private Vector3 screenPos;
    public int screenHeight;



	// Use this for initialization
	void Start ()
    {
		//set up NPC dialogs
		// first parameter is the name of the object the second is the dialogue
        if (!DataStore.NPCText.ContainsKey("PickObject")) { DataStore.NPCText.Add("PickObject", "press 'E' to lift up some objects!"); }
        if (!DataStore.NPCText.ContainsKey("DropObject")) { DataStore.NPCText.Add("DropObject", "Press 'E' again to drop them."); }
        if (!DataStore.NPCText.ContainsKey("JumpSign")) { DataStore.NPCText.Add("JumpSign", "Press Space to jump"); }
        if (!DataStore.NPCText.ContainsKey("MoveSign")) { DataStore.NPCText.Add("MoveSign", "Use A and D to move Left/Right!"); }
        if (!DataStore.NPCText.ContainsKey("MovingPSign")) { DataStore.NPCText.Add("MovingPSign", "Some Platforms even move!"); }
        if (!DataStore.NPCText.ContainsKey("PickupsSign")) { DataStore.NPCText.Add("PickupsSign", "You should pick up all rubbish!"); }
        if (!DataStore.NPCText.ContainsKey("EnemySign")) { DataStore.NPCText.Add("EnemySign", "This wee guy takes off 1 heart!"); }
        if (!DataStore.NPCText.ContainsKey("AttackSign")) { DataStore.NPCText.Add("AttackSign", "Click the mouse to attack!"); }
        if (!DataStore.NPCText.ContainsKey("Clyde")) { DataStore.NPCText.Add("Clyde", "Press T to finish the game!"); }
        if (!DataStore.NPCText.ContainsKey("Clyde(HUB)")) { DataStore.NPCText.Add("Clyde(HUB)", "Click me then a worker to build!"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign")) { DataStore.NPCText.Add("DoorSign", "Collect all trash to unlock door"); }
        if (!DataStore.NPCText.ContainsKey("TeleSign")) { DataStore.NPCText.Add("TeleSign", "'T' to go back to level 1"); }

        // Builder chats
        #region Builder
        if (!DataStore.NPCText.ContainsKey("Builder0")) { DataStore.NPCText.Add("Builder0", "click me to upgrade the Houses"); }
        if (!DataStore.NPCText.ContainsKey("Builder1")) { DataStore.NPCText.Add("Builder1", "It will cost you 5 Bottles and paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder2")) { DataStore.NPCText.Add("Builder2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Builder3")) { DataStore.NPCText.Add("Builder3", "Congratulations, the Houses have begun building!"); }
        if (!DataStore.NPCText.ContainsKey("Builder4")) { DataStore.NPCText.Add("Builder4", "Sorry, you dont have enough Bottles or Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder5")) { DataStore.NPCText.Add("Builder5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Builder6")) { DataStore.NPCText.Add("Builder6", "Come back when you get it!"); }
        if (!DataStore.NPCText.ContainsKey("Builder7")) { DataStore.NPCText.Add("Builder7", "Do you want to finish the houses?"); }
        if (!DataStore.NPCText.ContainsKey("Builder8")) { DataStore.NPCText.Add("Builder8", "It will cost you 5 Bottles and paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder9")) { DataStore.NPCText.Add("Builder9", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Builder10")) { DataStore.NPCText.Add("Builder10", "Congratulations, the Houses have been finished!"); }
        #endregion

        // gardener chats
        #region Gardener
        if (!DataStore.NPCText.ContainsKey("Gardener0")) { DataStore.NPCText.Add("Gardener0", "click me to upgrade the gardens"); }
        if (!DataStore.NPCText.ContainsKey("Gardener1")) { DataStore.NPCText.Add("Gardener1", "It will cost you 5 Bottles"); }
        if (!DataStore.NPCText.ContainsKey("Gardener2")) { DataStore.NPCText.Add("Gardener2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Gardener3")) { DataStore.NPCText.Add("Gardener3", "Congratulations, the Gardens are done!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener4")) { DataStore.NPCText.Add("Gardener4", "Sorry, you dont have enough Bottles!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener5")) { DataStore.NPCText.Add("Gardener5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener6")) { DataStore.NPCText.Add("Gardener6", "Come back when you get it!"); }
        #endregion

        // decorator chats
        #region Decorator
        if (!DataStore.NPCText.ContainsKey("Decorator0")) { DataStore.NPCText.Add("Decorator0", "click me to upgrade decorations"); }
        if (!DataStore.NPCText.ContainsKey("Decorator1")) { DataStore.NPCText.Add("Decorator1", "It will cost you 5 Paper"); }
        if (!DataStore.NPCText.ContainsKey("Decorator2")) { DataStore.NPCText.Add("Decorator2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Decorator3")) { DataStore.NPCText.Add("Decorator3", "Congratulations, the decorations are done!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator4")) { DataStore.NPCText.Add("Decorator4", "Sorry, you dont have enough Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator5")) { DataStore.NPCText.Add("Decorator5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator6")) { DataStore.NPCText.Add("Decorator6", "Come back when you get it!"); }
        #endregion

        if (!DataStore.NPCText.ContainsKey("CheckPoint1")) { DataStore.NPCText.Add("CheckPoint1", "Signs like me save your progress!"); }
		if (!DataStore.NPCText.ContainsKey("EndTutSign")) { DataStore.NPCText.Add("EndTutSign", "Now you're on your own! Collect as much trash as possible!"); }

        //set main chamera for tracking
		MyCamera = GameObject.Find("Main Camera");
		target = this.gameObject.transform;
		//assign global skin from DT
		myskin = DataStore.DT.skin;
        screenHeight = Screen.height;

	}


	


	void OnTriggerEnter2D(Collider2D other) 
    {
		//turn on gui display
        if (other.tag == "Player")
		guiEnabled = true;
	}

	void OnTriggerExit2D(Collider2D other) 
    {
		//turn off gui display
		guiEnabled = false;

	}

	void OnGUI () 
    {		
		if (guiEnabled)
        {
			//draw gui box
			GUI.skin = myskin;
			// 14 pixel width per character including spaces and spec chars
			GUI.Box (new Rect (screenPos.x, (screenHeight - 500), (DataStore.NPCText[this.gameObject.name].Length*12),100),DataStore.NPCText[this.gameObject.name]);
						
			//print(DataStore.NPCText[this.gameObject.name].Length);
			//print(GetInstanceID());
			//	print(this.gameObject.name);
		}
	}

	


	// Update is called once per frame
	void Update () 
    {
		//keep tracking the position
        screenPos = MyCamera.camera.WorldToScreenPoint(target.position);
	}
}
