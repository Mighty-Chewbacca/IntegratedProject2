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
			GUI.Box (new Rect (screenPos.x, 50, (DataStore.NPCText[this.gameObject.name].Length*14),100),DataStore.NPCText[this.gameObject.name]);
						
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
