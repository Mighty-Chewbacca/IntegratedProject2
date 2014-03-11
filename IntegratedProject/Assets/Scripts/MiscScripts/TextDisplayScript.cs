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



	// Use this for initialization
	void Start () {
	
		//set up NPC dialogs
		// first parameter is the name of the object the second is the dialogue

		if (!DataStore.NPCText.ContainsKey ("npc1")) {DataStore.NPCText.Add ("npc1", "Welcome Adventurer! I'm the first NPC.");}
		if (!DataStore.NPCText.ContainsKey ("npc2")) {DataStore.NPCText.Add ("npc2", "And I'm the second :P");}
		if (!DataStore.NPCText.ContainsKey ("npc3")) {DataStore.NPCText.Add ("npc3", "Gues what?! If you go any further you die :)");}
        if (!DataStore.NPCText.ContainsKey("PickObject")) { DataStore.NPCText.Add("PickObject", "press 'L' to lift up some objects!"); }
        if (!DataStore.NPCText.ContainsKey("DropObject")) { DataStore.NPCText.Add("DropObject", "Press 'L' again to drop them."); }
        if (!DataStore.NPCText.ContainsKey("JumpSign")) { DataStore.NPCText.Add("JumpSign", "Press Space to jump"); }
        if (!DataStore.NPCText.ContainsKey("MoveSign")) { DataStore.NPCText.Add("MoveSign", "Use the Arrow Keys to move"); }
        if (!DataStore.NPCText.ContainsKey("MovingPSign")) { DataStore.NPCText.Add("MovingPSign", "Some Platforms even move!"); }
        if (!DataStore.NPCText.ContainsKey("PickupsSign")) { DataStore.NPCText.Add("PickupsSign", "You should pick up all rubbish!"); }
        if (!DataStore.NPCText.ContainsKey("EnemySign")) { DataStore.NPCText.Add("EnemySign", "Enemies take 5 hits to kill"); }
        if (!DataStore.NPCText.ContainsKey("AttackSign")) { DataStore.NPCText.Add("AttackSign", "Click the mouse to attack!"); }
        if (!DataStore.NPCText.ContainsKey("Clyde")) { DataStore.NPCText.Add("Clyde", "Press 'T' to continue!"); }
        if (!DataStore.NPCText.ContainsKey("Clyde(HUB)")) { DataStore.NPCText.Add("Clyde(HUB)", "Click me then a worker to build!"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign")) { DataStore.NPCText.Add("DoorSign", "Collect all trash to unlock door"); }
        if (!DataStore.NPCText.ContainsKey("TeleSign")) { DataStore.NPCText.Add("TeleSign", "'T' to go back to level 1"); }
        if (!DataStore.NPCText.ContainsKey("Builder")) { DataStore.NPCText.Add("Builder", "Click me to upgrade houses"); }
        if (!DataStore.NPCText.ContainsKey("Gardener")) { DataStore.NPCText.Add("Gardener", "click me to upgrade gardens"); }
        if (!DataStore.NPCText.ContainsKey("Decorator")) { DataStore.NPCText.Add("Decorator", "click me to upgrade decorations"); }


		//set main chamera for tracking
		MyCamera = GameObject.Find("Main Camera");
		target = this.gameObject.transform;
		//assign global skin from DT
		myskin = DataStore.DT.skin;

	}


	


	void OnTriggerEnter2D(Collider2D other) {


		//turn on gui display
		guiEnabled = true;
	}

	void OnTriggerExit2D(Collider2D other) {

		//turn off gui display
		guiEnabled = false;

	}

	void OnGUI () {
				
		if (guiEnabled) {
						//draw gui box
			GUI.skin = myskin;

			// 14 pixel width per character including spaces and spec chars
			GUI.Box (new Rect (screenPos.x, 250, (DataStore.NPCText[this.gameObject.name].Length*14),100),DataStore.NPCText[this.gameObject.name]);
						
			print(DataStore.NPCText[this.gameObject.name].Length);
			//print(GetInstanceID());
			//	print(this.gameObject.name);
						}
		}

	


	// Update is called once per frame
	void Update () {

		//keep tracking the position
		screenPos = MyCamera.camera.WorldToScreenPoint(target.position);

	
	}
}
