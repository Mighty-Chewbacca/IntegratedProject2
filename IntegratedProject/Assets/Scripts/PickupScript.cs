using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour 
{
    public Texture2D pickupSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("coin got");

            //update gui
            //set coin to inactive
            gameObject.SetActive(false);
        }
    }
}
