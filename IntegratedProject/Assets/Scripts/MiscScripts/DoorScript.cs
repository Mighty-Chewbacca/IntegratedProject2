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
    public AudioSource au_dooropen;

	// Use this for initialization
	void Start () 
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        //set the doors locked value to that stored in the Dt, loaded from save
        doorLocked = DataStore.DoorsOpened[this.name];

        //audio stuff for door opneing
        AudioClip openSound;
        openSound = (AudioClip)Resources.Load("SFX/openDoor");
        au_dooropen = (AudioSource)gameObject.AddComponent("AudioSource");
        au_dooropen.clip = openSound;
        au_dooropen.loop = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if player is close enough open door, cant use trigger because it would let the player pass through door
        distance = Vector2.Distance(player.transform.position, this.transform.position);

		if (distance < 2 && (Inventory.keys >= 1) && doorLocked == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Inventory.keys--;
                au_dooropen.Play();
                doorLocked = false;
            }
        }

        //set sprite to correct one depending on door state
        if (doorLocked == true)
        {
            myRenderer.sprite = close;
        }

        if (doorLocked == false)
        {
            Unlock();
            myRenderer.sprite = open;
        }
	}

    void Unlock()
    {
        this.collider2D.enabled = false;
        DataStore.DoorsOpened[this.name] = false;
        DataStore.DT.SaveToFile();
    }
}
