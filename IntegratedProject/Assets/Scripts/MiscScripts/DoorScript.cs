using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour 
{

    //public Inventory playersInv;
    public GameObject player;
    public float distance;
    public bool doorLocked;
    public Sprite open, close;
    SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () 
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        doorLocked = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);

		if (distance < 2 && (Inventory.keys >= 1))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Inventory.keys--;
                doorLocked = false;
                Unlock();
            }
        }

        if (doorLocked)
            myRenderer.sprite = close;
        else myRenderer.sprite = open;
	
	}

    void Unlock()
    {
        this.collider2D.enabled = false;
        //change sprite to open door
    }
}
