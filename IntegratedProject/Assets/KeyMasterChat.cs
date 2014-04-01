using UnityEngine;
using System.Collections;

public class KeyMasterChat : MonoBehaviour
{
    public bool playerInRange;
    public GameObject player;
    public float distance;
    private int chatValue = 0;
    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;
    public GUISkin myskin;


    // Use this for initialization
    void Start()
    {
        this.name = "KeyMaster0";
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
            this.name = "KeyMaster0";
        }
        if (chatValue == 1)
        {
            this.name = "KeyMaster1";
        }
        if (chatValue == 2)
        {
            this.name = "KeyMaster2";
        }
        if (chatValue == 3)
        {
            this.name = "KeyMaster3";
        }
        if (chatValue == 4)
        {
            this.name = "KeyMaster4";
        }
        if (chatValue == 5)
        {
            this.name = "KeyMaster5";
        }
        if (chatValue == 6)
        {
            this.name = "KeyMaster6";
        }
        if (chatValue == 7)
        {
            this.name = "KeyMaster7";
        }
    }

    //displays the buttons for moving forward in the chat
    void OnGUI()
    {
        GUI.skin = myskin;

        if (chatValue == 1 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Hello"))
            {
                chatValue = 2;
            }
        }
        if (chatValue == 2 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 3;
            }
        }
        if (chatValue == 3 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes"))
            {
                if (Inventory.can >= 5)
                {
                    Inventory.can -= 5;
                    Inventory.keys++;
                    chatValue = 4;
                }

                if (Inventory.can < 5)
                {
                    chatValue = 6;
                }
            }

            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 200), 200, 60), "No"))
            {
                chatValue = 0;
            }
        }
        if (chatValue == 4 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay Thanks!"))
            {
                chatValue = 5;
            }
        }
        if (chatValue == 6 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "I'll go get some!"))
            {
                chatValue = 7;
            }
        }
    }
}
