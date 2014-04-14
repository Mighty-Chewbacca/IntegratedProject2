using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour
{
    public SoundScript player;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Can")
		{
            
			print("can got");
			Inventory.can ++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
			gameObject.SetActive(false);

		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Bottle")
		{
			print("can got");
			Inventory.bottle++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
			gameObject.SetActive(false);

		}
		
		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Paper")
		{
			print("paper got");
			Inventory.paper++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
			gameObject.SetActive(false);

		}

		if (other.gameObject.tag == "Player" && this.gameObject.tag == "Apple" && HealthScript.health < 4)
		{
			print("Apple got");
            HealthScript.health++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
			gameObject.SetActive(false);

		}
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "hammer")
        {
            Inventory.hammer++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
            gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "paintbrush")
        {
            Inventory.paintbrush++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
            gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "trowel")
        {
            Inventory.trowel++;
            player.au_pickup.Play();
            DataStore.DT.SyncDataWithDT();
            gameObject.SetActive(false);

        }
	}
}