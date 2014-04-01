using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
{

    //public bool isClicked;
    public ChangeSprites MyBuilding;
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
        this.name = "ClydeH0";
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
            this.name = "ClydeH0";
        }
        if (chatValue == 1)
        {
            this.name = "ClydeH1";
        }
        if (chatValue == 2)
        {
            this.name = "ClydeH2";
        }
        if (chatValue == 3)
        {
            this.name = "ClydeH3";
        }
        if (chatValue == 4)
        {
            this.name = "ClydeH4";
        }
        if (chatValue == 5)
        {
            this.name = "ClydeH5";
        }
        if (chatValue == 6)
        {
            this.name = "ClydeH6";
        }
        if (chatValue == 7)
        {
            this.name = "ClydeH7";
        }
        if (chatValue == 8)
        {
            this.name = "ClydeH8";
        }
    }

    //displays the buttons for moving forward in the chat
    void OnGUI()
    {
        GUI.skin = myskin;

        if (chatValue == 1 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Thanks"))
            {
                chatValue = 2;
            }
        }
        if (chatValue == 2 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Really?"))
            {
                    chatValue = 3;
            }
        }

        if (chatValue == 3 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes!"))
            {
                chatValue = 4;
            }
        }
        if (chatValue == 4 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 5;
            }
        }
        if (chatValue == 5 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 6;
            }
        }
        if (chatValue == 6 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay"))
            {
                chatValue = 7;
            }
        }
        if (chatValue == 7 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Let's Go!"))
            {
                chatValue = 8;
            }
        }
    }
}
