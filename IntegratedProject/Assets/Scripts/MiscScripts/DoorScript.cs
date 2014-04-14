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
        if (!DataStore.DoorsOpened.ContainsKey("Door1")) { DataStore.DoorsOpened.Add("Door1", true); }
        if (!DataStore.DoorsOpened.ContainsKey("Door2")) { DataStore.DoorsOpened.Add("Door2", true); }
        if (!DataStore.DoorsOpened.ContainsKey("Door3")) { DataStore.DoorsOpened.Add("Door3", true); }
        if (!DataStore.DoorsOpened.ContainsKey("Door4")) { DataStore.DoorsOpened.Add("Door4", true); }
        if (!DataStore.DoorsOpened.ContainsKey("Door5")) { DataStore.DoorsOpened.Add("Door5", true); }
        if (!DataStore.DoorsOpened.ContainsKey("Door6")) { DataStore.DoorsOpened.Add("Door6", true); }
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        doorLocked = DataStore.DoorsOpened[this.name];

        AudioClip openSound;
        openSound = (AudioClip)Resources.Load("SFX/openDoor");

        au_dooropen = (AudioSource)gameObject.AddComponent("AudioSource");
        au_dooropen.clip = openSound;
        au_dooropen.loop = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
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
