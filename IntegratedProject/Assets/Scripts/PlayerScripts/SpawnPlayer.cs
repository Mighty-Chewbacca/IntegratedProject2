using UnityEngine;
using System.Collections;

public class SpawnPlayer : MonoBehaviour {

public static void SpawnPlayerToLastCheckpoint(bool doReloadInverntory, bool doReloadHealt)
	{

		//give back lives
		if (doReloadHealt) 
		{
		 HealthScript.health = HealthScript.maxHealt;
		}

		//load back the inventory
		if (doReloadInverntory)
		    {
		Inventory.can = DataStore.PlayerInventory ["can"];
		Inventory.bottle = DataStore.PlayerInventory ["bottle"];
		Inventory.paper = DataStore.PlayerInventory ["paper"];
			}

		//spawn player back to the last checkpoint position
		GameObject.Find ("char").transform.position = GameObject.Find (DataStore.DT.checkpoint).transform.position;
		
		print ("progress loaded!");
		
	}


}
