using UnityEngine;
using System.Collections;

public class KeyMasterChat : MonoBehaviour
{
    private int chatValue = 0;
    private Vector3 screenPos;
    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;
    public GUISkin myskin;
    bool guiEnabled = false;
    private GameObject MyCamera;
    public Transform target;
    private float timeSincelastTouched = 2.0f;
    bool canTouch = true;

    // Use this for initialization
    void Start()
    {
        this.name = "KeyMaster0";
        myskin = DataStore.DT.skin;
        MyCamera = GameObject.Find("TheCamera");
        target = this.gameObject.transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //turn on gui display
        if ((other.tag == "Player") && (canTouch))
            guiEnabled = true;
    }

    void Update()
    {
        Chat();
        screenPos = MyCamera.camera.WorldToScreenPoint(target.position);
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

        if (guiEnabled == true)
        {
            //draw gui box
            GUI.skin = myskin;
            // 14 pixel width per character including spaces and spec chars
            GUI.Box(new Rect(screenPos.x, (screenHeight - 500), (DataStore.NPCText[this.gameObject.name].Length * 12), 100), DataStore.NPCText[this.gameObject.name]);
            Time.timeScale = 0;
            canTouch = false;

            if (GUI.Button(new Rect((screenWidth - 225), (screenHeight - 75), 200, 60), "Dismiss"))
            {
                Time.timeScale = 1;
                guiEnabled = false;
                chatValue = 0;
                StartCoroutine(LastTouchTimer());
            }
            if (chatValue == 0)
            {
                if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay"))
                {
                    chatValue = 1;
                }
            }
        }


        if (chatValue == 1)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay"))
            {
                chatValue = 2;
                Chat();
            }
        }
        if (chatValue == 2)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 3;
                Chat();
            }
        }
        if (chatValue == 3)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes"))
            {
                if (Inventory.can < 5)
                {
                    chatValue = 6;
                    Chat();
                }

                if (Inventory.can >= 5)
                {
                    Inventory.can -= 5;
                    Inventory.keys++;
                    chatValue = 4;
                    Chat();
                }
            }

            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 200), 200, 60), "No"))
            {
                chatValue = 0;
                Time.timeScale = 1;
                guiEnabled = false;
                Chat();
                StartCoroutine(LastTouchTimer());
            }
        }
        if (chatValue == 4)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay Thanks!"))
            {
                chatValue = 5;
                Chat();
            }
        }

        if (chatValue == 5)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Bye!"))
            {
                chatValue = 0;
                Time.timeScale = 1;
                guiEnabled = false;
                Chat();
                StartCoroutine(LastTouchTimer());
            }
        }

        if (chatValue == 6)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "I'll get some!"))
            {
                chatValue = 0;
                Time.timeScale = 1;
                guiEnabled = false;
                Chat();
                StartCoroutine(LastTouchTimer());
            }
        }
    }

    IEnumerator LastTouchTimer()
    {
        yield return new WaitForSeconds(timeSincelastTouched);
        canTouch = true;
    }
}
