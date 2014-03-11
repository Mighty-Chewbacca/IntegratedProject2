using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
	public Inventory playerInv;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Can")
        {
            print("can got");
			playerInv.can ++;
            //update gui
            //set coin to inactive
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Bottle")
        {
            print("can got");
            playerInv.bottle++;
            //update gui
            //set coin to inactive
            gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Paper")
        {
            print("paper got");
            playerInv.paper++;
            //update gui
            //set coin to inactive
            gameObject.SetActive(false);
        }
    }
}
