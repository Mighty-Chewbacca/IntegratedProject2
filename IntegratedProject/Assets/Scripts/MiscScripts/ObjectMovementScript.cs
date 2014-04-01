using UnityEngine;
using System.Collections;

public class ObjectMovementScript : MonoBehaviour 
{
    //object NEEDS 
        // box collider (or any collider)
        // rigidbody2d with 1000000 mass, 1000000 angular drag and 1000000 gravity scale, must also be fixed angle
    public GameObject player;
    public movementScript playerMovementScript;
    public float distance;
    public bool isLifted = false;

	// Update is called once per frame
	void Update () 
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);

        if (distance < 2.5f && (Input.GetKeyDown(KeyCode.E)) && isLifted == false)
        {
            Lifted();
        }

        else if (Input.GetKeyDown(KeyCode.E) && isLifted == true)
        {
            isLifted = false;
            playerMovementScript.isLifting = false;
        }

        if (isLifted == true)
        {
            //flip the object to the front of the player depending on which way they are facing
            if (playerMovementScript.facingRight == true)
                //offset the position so it is infront of the player not on top of them
                this.transform.position = new Vector3(player.transform.position.x + 2, this.transform.position.y, player.transform.position.z);

            if (playerMovementScript.facingRight == false)
                this.transform.position = new Vector3(player.transform.position.x - 2, this.transform.position.y, player.transform.position.z);

            //stop the player jumping whilst holding the object
            playerMovementScript.isLifting = true;
        }
	}

    void Lifted()
    {
        isLifted = true;
    }
}
