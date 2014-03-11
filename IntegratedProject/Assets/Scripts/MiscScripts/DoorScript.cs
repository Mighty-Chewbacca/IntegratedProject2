using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{

    public Inventory playersInv;
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

        if (distance < 2 && (playersInv.can == 3 && playersInv.bottle == 2 && playersInv.paper == 2))
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
