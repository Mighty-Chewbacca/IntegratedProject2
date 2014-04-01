using UnityEngine;
using System.Collections;

public class DoorUnlockTutorial : MonoBehaviour
{
    public bool playerInRange;
    public GameObject player;
    public float distance;
    private int chatValue = 0;
    public GUISkin myskin;


    // Use this for initialization
    void Start()
    {
        this.name = "DoorSign0";
        myskin = DataStore.DT.skin;
    }

    void Update()
    {
        CheckDistance();

        if (distance < 2)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
            chatValue = 0;
        }

        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && chatValue == 0)
            {
                chatValue = 1;
            }
        }
        Chat();
    }

    //check the distance between the player and the decorator
    void CheckDistance()
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);
    }

    //controls chat with npc, to tell you to upgrade
    void Chat()
    {
        if (chatValue == 0)
        {
            this.name = "DoorSign0";
        }
        if (chatValue == 1)
        {
            this.name = "DoorSign1";
        }
    }
}
