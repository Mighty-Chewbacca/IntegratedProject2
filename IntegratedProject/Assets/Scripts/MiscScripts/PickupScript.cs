using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour
{
	//public Inventory playerInv;
	public HealthScript playersHealth;
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Can")
		{
			print("can got");
			Inventory.can ++;
			gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Bottle")
		{
			print("can got");
			Inventory.bottle++;
			gameObject.SetActive(false);
		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Paper")
		{
			print("paper got");
			Inventory.paper++;
			gameObject.SetActive(false);
		}

		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Apple")
		{
			print("Apple got");
			playersHealth.health++;
			gameObject.SetActive(false);
		}
	}
}