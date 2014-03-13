using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{

    //public Inventory playersInv;
    public GameObject player, thisObject;
    public float distance;
    public bool doorLocked;

	// Use this for initialization
	void Start () 
    {
        doorLocked = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        distance = Vector2.Distance(player.transform.position, thisObject.transform.position);

		if (distance < 2 && (Inventory.can == 3 && Inventory.bottle == 2 && Inventory.paper == 2))
        {
            doorLocked = false;
            Unlock();
        }
	
	}

    void Unlock()
    {
        thisObject.SetActive(false);
    }
}
