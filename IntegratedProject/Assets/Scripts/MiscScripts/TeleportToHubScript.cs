using UnityEngine;
using System.Collections;

public class TeleportToHubScript : MonoBehaviour 
{
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetMouseButtonDown(1) && (other.tag == "Player"))
        {
            Time.timeScale = 1;
            Application.LoadLevel(2);
        }
    }
}
