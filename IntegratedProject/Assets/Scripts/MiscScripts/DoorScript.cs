using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{

    //public Inventory playersInv;
    public GameObject player;
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
        distance = Vector2.Distance(player.transform.position, this.transform.position);

		if (distance < 2 && (Inventory.keys >= 1))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.keys--;
                doorLocked = false;
                Unlock();
            }
        }
	
	}

    void Unlock()
    {
        this.collider2D.enabled = false;
        //change sprite to open door
    }
}
