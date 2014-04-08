/*
this script should be attached to the sign object that we want to act as a checkpoint
it saves the name of the attached object to the DataStore
player can be loaded back by changing it's translation coordinates to the coordiantes of the sign

the script also takes a snapshot of the current player inventory.


Saved Properties:
- checkpoint object's name
	(position can be retrieved like this; GameObject.Find("char").transform.position = GameObject.Find(DataStore.DT.checkpoint).transform.position);

- player's inventory

 */

using UnityEngine;
using System.Collections;

public class SaveCheckpointScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		//set up Player Inventory
		// first parameter is the name of the object the second is the amount
		
		if (!DataStore.PlayerInventory.ContainsKey ("can")) {DataStore.PlayerInventory.Add ("can", 0);}
		if (!DataStore.PlayerInventory.ContainsKey ("bottle")) {DataStore.PlayerInventory.Add ("bottle", 0);}
		if (!DataStore.PlayerInventory.ContainsKey ("paper")) {DataStore.PlayerInventory.Add ("paper", 0);}
		
	}


	void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {


            // save player's positon
            DataStore.DT.checkpoint = this.gameObject.name;
            print(this.gameObject.name);

            //--- test load back ---
            //print (GameObject.Find(DataStore.DT.checkpoint).transform.position);
            //GameObject.Find("char").transform.position = new Vector3(13.2f, 10.0f, 0.0f);



            //save player inventory

            DataStore.PlayerInventory["can"] = Inventory.can;
            DataStore.PlayerInventory["bottle"] = Inventory.bottle;
            DataStore.PlayerInventory["paper"] = Inventory.paper;

            DataStore.DT.SaveToFile();

            print("progress saved!");
        }
	}

}
