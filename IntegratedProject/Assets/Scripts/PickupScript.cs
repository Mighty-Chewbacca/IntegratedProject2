using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
    public Texture2D pickupSprite;
	public Inventory playerInv;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("can got");
			playerInv.can ++;
            //update gui
            //set coin to inactive
            gameObject.SetActive(false);
        }
    }
}
