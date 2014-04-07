using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
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
        this.name = "ClydeH0";
        myskin = DataStore.DT.skin;
        MyCamera = GameObject.Find("Main Camera");
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
                if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
                {
                    chatValue = 1;
                }
            }
        }


        if (chatValue == 1)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Thanks"))
            {
                chatValue = 2;
                Chat();
            }
        }
        if (chatValue == 2)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Really?"))
            {
                chatValue = 3;
                Chat();
            }
        }
        if (chatValue == 3)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes"))
            {
                    chatValue = 4;
                    Chat();
            }
        }
        if (chatValue == 4)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 5;
                Chat();
            }
        }

        if (chatValue == 5)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "..."))
            {
                chatValue = 6;
                Chat();
            }
        }

        if (chatValue == 6)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Okay"))
            {
                chatValue = 7;
                Chat();
            }
        }

        if (chatValue == 7)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Let's Go!"))
            {
                chatValue = 8;
                Chat();
            }
        }

        if (chatValue == 8)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Wooooo!"))
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
