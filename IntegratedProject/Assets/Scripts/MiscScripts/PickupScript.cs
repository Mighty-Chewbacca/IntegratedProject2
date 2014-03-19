using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour
{
	//public Inventory playerInv;
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Can")
		{
			print("can got");
			Inventory.can ++;
			//update gui
			//set coin to inactive
			gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Bottle")
		{
			print("can got");
			Inventory.bottle++;
			//update gui
			//set coin to inactive
			gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Paper")
		{
			print("paper got");
			Inventory.paper++;
			//update gui
			//set coin to inactive
			gameObject.SetActive(false);
		}
	}
}