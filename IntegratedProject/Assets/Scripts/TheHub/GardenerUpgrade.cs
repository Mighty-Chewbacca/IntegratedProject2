﻿using UnityEngine;
using System.Collections;

public class GardenerUpgrade : MonoBehaviour
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
    public ChangeSprites MyBuilding;
    public static bool gardensUpgraded = false;

    // Use this for initialization
    void Start()
    {
        this.name = "Gardener0";
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
        if (MyBuilding.currentSprite == 1)
            gardensUpgraded = true;
        Chat();
        screenPos = MyCamera.camera.WorldToScreenPoint(target.position);
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
        if (chatValue == 6)
        {
            this.name = "Gardener6";
        }
        if (chatValue == 7)
        {
            this.name = "Gardener7";
        }
    }

    //displays the buttons for moving forward in the chat
    void OnGUI()
    {
        GUI.skin = myskin;

        if (guiEnabled == true)
        {
            if (MyBuilding.currentSprite == 1)
            {
                chatValue = 3;
            }
            //draw gui box
            GUI.skin = myskin;
            // 14 pixel width per character including spaces and spec chars
            GUI.Box(new Rect(screenPos.x, (screenHeight - 500), (DataStore.NPCText[this.gameObject.name].Length * 8), 100), DataStore.NPCText[this.gameObject.name]);
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
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Cool"))
            {
                chatValue = 2;
                Chat();
            }
        }
        if (chatValue == 2)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Yes"))
            {
                if (Inventory.bottle < 5)
                {
                    chatValue = 4;
                    Chat();
                }
                if (Inventory.trowel < 1)
                {
                    chatValue = 7;
                    Chat();
                }

                if (Inventory.bottle >= 5 && Inventory.trowel > 0)
                {
                    Inventory.bottle -= 5;
                    MyBuilding.currentSprite++;
                    SaveBuildingState();
                    chatValue = 3;
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
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Oh Okay"))
            {
                chatValue = 5;
                Chat();
            }
        }

        if (chatValue == 5)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Will do"))
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
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Thanks"))
            {
                chatValue = 0;
                Time.timeScale = 1;
                guiEnabled = false;
                Chat();
                StartCoroutine(LastTouchTimer());
            }
        }
        if (chatValue == 7)
        {
            if (GUI.Button(new Rect((screenWidth / 2 - 75), (screenHeight / 2 + 140), 200, 60), "Oh Okay"))
            {
                chatValue = 5;
                Chat();
            }
        }
    }

    IEnumerator LastTouchTimer()
    {
        yield return new WaitForSeconds(timeSincelastTouched);
        canTouch = true;
    }

    void SaveBuildingState()
    {
        DataStore.HUBBuildings["gardens"] = MyBuilding.currentSprite;

        DataStore.DT.SyncDataWithDT();
    }
}
