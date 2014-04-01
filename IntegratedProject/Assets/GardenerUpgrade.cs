using UnityEngine;
using System.Collections;

public class GardenerUpgrade : MonoBehaviour
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
        this.name = "Gardener0";
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

            if (chatValue == 3)
                chatValue = 3;
            else chatValue = 0;
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
            this.name = "Gardener0";
        }
        if (chatValue == 1)
        {
            this.name = "Gardener1";
        }
        if (chatValue == 2)
        {
            this.name = "Gardener2";
        }
        if (chatValue == 3)
        {
            this.name = "Gardener3";
        }
        if (chatValue == 4)
        {
            this.name = "Gardener4";
        }
        if (chatValue == 5)
        {
            this.name = "Gardener5";
        }
    }

    //displays the buttons for moving forward in the chat
    void OnGUI()
    {
        GUI.skin = myskin;

        if (chatValue == 1 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Continue"))
            {
                chatValue = 2;
            }
        }
        if (chatValue == 2 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes"))
            {
                if (Inventory.bottle >= 5)
                {
                    MyBuilding.currentSprite++;
                    Inventory.bottle = -5;
                    chatValue = 3;
                }

                if (Inventory.bottle < 5)
                {
                    chatValue = 4;
                }
            }

            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 200), 200, 60), "No"))
            {
                chatValue = 0;
            }
        }
        if (chatValue == 4 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Sorry"))
            {
                chatValue = 5;
            }
        }
        if (chatValue == 5 && playerInRange)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay! Thank you!"))
            {
                chatValue = 0;
            }
        }
    }
}
