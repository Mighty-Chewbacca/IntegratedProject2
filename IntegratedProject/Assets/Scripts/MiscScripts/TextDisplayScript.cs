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
    public int screenWidth;
    private float timeSincelastTouched = 2.0f;
    bool canTouch = true;



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
        if (!DataStore.NPCText.ContainsKey("DoorSign")) { DataStore.NPCText.Add("DoorSign", "Get a key to unlock the door!"); }
        if (!DataStore.NPCText.ContainsKey("TeleSign")) { DataStore.NPCText.Add("TeleSign", "'E' to go back to level 1"); }
        if (!DataStore.NPCText.ContainsKey("FruitSign")) { DataStore.NPCText.Add("FruitSign", "This Fruit can heal you!"); }
        if (!DataStore.NPCText.ContainsKey("CheckPoint1")) { DataStore.NPCText.Add("CheckPoint1", "Signs like me save your progress!"); }
		if (!DataStore.NPCText.ContainsKey("EndTutSign")) { DataStore.NPCText.Add("EndTutSign", "Now you're on your own! Collect as much trash as possible!"); }
        if (!DataStore.NPCText.ContainsKey("Clyde")) { DataStore.NPCText.Add("Clyde", "Press T to finish the game!"); }
        if (!DataStore.NPCText.ContainsKey("HubTeleportSign")) { DataStore.NPCText.Add("HubTeleportSign", "Right Click to go to the HUB!"); }


        //chat for the sign that teaches how to unlock a door
        #region doorUnlock
        if (!DataStore.NPCText.ContainsKey("DoorSign0")) { DataStore.NPCText.Add("DoorSign0", "Use your key to open this!"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign1")) { DataStore.NPCText.Add("DoorSign1", "You can get a key from the HUB"); }
        if (!DataStore.NPCText.ContainsKey("DoorSign2")) { DataStore.NPCText.Add("DoorSign2", "Press 'action' to open the door"); }
        #endregion

        // chat for keymaster in hub
        #region keymaster
        if (!DataStore.NPCText.ContainsKey("KeyMaster0")) { DataStore.NPCText.Add("KeyMaster0", "Hi there, I'm the Keyman!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster1")) { DataStore.NPCText.Add("KeyMaster1", "I make you keys from cans"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster2")) { DataStore.NPCText.Add("KeyMaster2", "A key will cost you 5 cans!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster3")) { DataStore.NPCText.Add("KeyMaster3", "would you like one?"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster4")) { DataStore.NPCText.Add("KeyMaster4", "Thank you!"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster5")) { DataStore.NPCText.Add("KeyMaster5", "All recycling helps the city"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster6")) { DataStore.NPCText.Add("KeyMaster6", "You dont have enough cans"); }
        if (!DataStore.NPCText.ContainsKey("KeyMaster7")) { DataStore.NPCText.Add("KeyMaster7", "Come back later!"); }

        #endregion

        //clyde in hub chats
        #region Clyde(hub)
        if (!DataStore.NPCText.ContainsKey("ClydeH0")) { DataStore.NPCText.Add("ClydeH0", "Hi there"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH1")) { DataStore.NPCText.Add("ClydeH1", "Welcome to the athletes village!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH2")) { DataStore.NPCText.Add("ClydeH2", "Its not really done yet though"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH3")) { DataStore.NPCText.Add("ClydeH3", "Could you help me finish it?"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH4")) { DataStore.NPCText.Add("ClydeH4", "Thank you! we really need to look the best"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH5")) { DataStore.NPCText.Add("ClydeH5", "the CommonWealth games are coming soon!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH6")) { DataStore.NPCText.Add("ClydeH6", "Collect recycling for the workers"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH7")) { DataStore.NPCText.Add("ClydeH7", "talk to them and they will get to work!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeH8")) { DataStore.NPCText.Add("ClydeH8", "Together we can leave a lasting legacy!"); }

        #endregion

        //clyde in tutorial chats
        #region Clyde(tutorial)
        if (!DataStore.NPCText.ContainsKey("ClydeT0")) { DataStore.NPCText.Add("ClydeT0", "Hi there"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT1")) { DataStore.NPCText.Add("ClydeT1", "Congrats on getting through the tutorial!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT2")) { DataStore.NPCText.Add("ClydeT2", "I'm Clyde, the Glasgow 2014 Mascot!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT3")) { DataStore.NPCText.Add("ClydeT3", "I really need your help"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT4")) { DataStore.NPCText.Add("ClydeT4", "Meet me back at the HUB to help me"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT5")) { DataStore.NPCText.Add("ClydeT5", "Oh silly me!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT6")) { DataStore.NPCText.Add("ClydeT6", "The Athletes village is the HUB!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT7")) { DataStore.NPCText.Add("ClydeT7", "Swing by and say high later!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT8")) { DataStore.NPCText.Add("ClydeT8", "Oh before i forget,"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT9")) { DataStore.NPCText.Add("ClydeT9", "Here is your key to continue!"); }
        if (!DataStore.NPCText.ContainsKey("ClydeT10")) { DataStore.NPCText.Add("ClydeT10", "I already gave you your key!"); }

        #endregion

        // Builder chats
        #region Builder
        if (!DataStore.NPCText.ContainsKey("Builder0")) { DataStore.NPCText.Add("Builder0", "Talk to me to upgrade the Houses"); }
        if (!DataStore.NPCText.ContainsKey("Builder1")) { DataStore.NPCText.Add("Builder1", "It will cost you 5 Bottles and paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder2")) { DataStore.NPCText.Add("Builder2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Builder3")) { DataStore.NPCText.Add("Builder3", "Congratulations you have helped me build them!"); }
        if (!DataStore.NPCText.ContainsKey("Builder4")) { DataStore.NPCText.Add("Builder4", "Sorry, you dont have enough Bottles or Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Builder5")) { DataStore.NPCText.Add("Builder5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Builder6")) { DataStore.NPCText.Add("Builder6", "Come back when you get it!"); }
        if (!DataStore.NPCText.ContainsKey("Builder7")) { DataStore.NPCText.Add("Builder7", "The houses are already finished!"); }
        #endregion

        // gardener chats
        #region Gardener
        if (!DataStore.NPCText.ContainsKey("Gardener0")) { DataStore.NPCText.Add("Gardener0", "Talk to me to upgrade the gardens"); }
        if (!DataStore.NPCText.ContainsKey("Gardener1")) { DataStore.NPCText.Add("Gardener1", "It will cost you 5 Bottles"); }
        if (!DataStore.NPCText.ContainsKey("Gardener2")) { DataStore.NPCText.Add("Gardener2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Gardener3")) { DataStore.NPCText.Add("Gardener3", "Congratulations, the Gardens are done!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener4")) { DataStore.NPCText.Add("Gardener4", "Sorry, you dont have enough Bottles!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener5")) { DataStore.NPCText.Add("Gardener5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Gardener6")) { DataStore.NPCText.Add("Gardener6", "Come back when you get it!"); }
        #endregion

        // decorator chats
        #region Decorator
        if (!DataStore.NPCText.ContainsKey("Decorator0")) { DataStore.NPCText.Add("Decorator0", "Talk to me to upgrade decorations"); }
        if (!DataStore.NPCText.ContainsKey("Decorator1")) { DataStore.NPCText.Add("Decorator1", "It will cost you 5 Paper"); }
        if (!DataStore.NPCText.ContainsKey("Decorator2")) { DataStore.NPCText.Add("Decorator2", "Are you sure?"); }
        if (!DataStore.NPCText.ContainsKey("Decorator3")) { DataStore.NPCText.Add("Decorator3", "Congratulations, the decorations are done!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator4")) { DataStore.NPCText.Add("Decorator4", "Sorry, you dont have enough Paper!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator5")) { DataStore.NPCText.Add("Decorator5", "It's okay, you just need to find more!"); }
        if (!DataStore.NPCText.ContainsKey("Decorator6")) { DataStore.NPCText.Add("Decorator6", "Come back when you get it!"); }
        #endregion

        
        //set main chamera for tracking
		MyCamera = GameObject.Find("Main Camera");
		target = this.gameObject.transform;
		//assign global skin from DT
		myskin = DataStore.DT.skin;
        screenHeight = Screen.height;
        screenWidth = Screen.width;

	}


	


	void OnTriggerEnter2D(Collider2D other) 
    {
		//turn on gui display
        if ((other.tag == "Player") && (canTouch))
		guiEnabled = true;
	}

    //void OnTriggerExit2D(Collider2D other) 
    //{
    //    //turn off gui display
    //    guiEnabled = false;

    //}

	void OnGUI () 
    {		
		if (guiEnabled == true)
        {
			//draw gui box
			GUI.skin = myskin;
			// 14 pixel width per character including spaces and spec chars
			GUI.Box (new Rect (screenPos.x, (screenHeight - 500), (DataStore.NPCText[this.gameObject.name].Length*12),100),DataStore.NPCText[this.gameObject.name]);
            Time.timeScale = 0;
            canTouch = false;

            if (GUI.Button(new Rect((screenWidth - 225), (screenHeight - 75), 200, 60), "Dismiss"))
            {
                Time.timeScale = 1;
                guiEnabled = false;
                StartCoroutine(LastTouchTimer());
            }
						
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

    IEnumerator LastTouchTimer()
    {
        yield return new WaitForSeconds(timeSincelastTouched);
        canTouch = true;
    }
}
