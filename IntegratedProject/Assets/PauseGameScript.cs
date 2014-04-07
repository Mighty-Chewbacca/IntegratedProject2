using System;
using UnityEngine;

public class PauseGameScript : MonoBehaviour
{
    bool gamePaused = false;
    int screenWidth = 1024, screenHeight = 768;
    GUISkin mySkin = DataStore.DT.skin;

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Time.timeScale = 1;
            SpawnPlayer.SpawnPlayerToLastCheckpoint(true, true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = togglePause();
        }
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        if (gamePaused)
        {
            GUI.Box(new Rect((screenWidth / 2 - 100), (screenHeight / 2 - 225), 300, 100), "The Game is Paused");
            if (GUI.Button(new Rect((screenWidth / 2 - 150), (screenHeight / 2 - 100), 200, 60), "Resume"))
                gamePaused = togglePause();

            if (GUI.Button(new Rect((screenWidth / 2 - 150), (screenHeight / 2 -30), 200, 60), "Main Menu"))
            {
                gamePaused = togglePause();
                Application.LoadLevel(0);
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
