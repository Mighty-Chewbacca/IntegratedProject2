using UnityEngine;
using System.Collections;

public class IsClicked : MonoBehaviour {

    //public bool isClicked;
    public int test;
    public ChangeSprites MyBuilding;
    public bool canPress, playerInRange;
    public GameObject player, button;
    public float distance;

	// Use this for initialization
	void Start () 
    {
        canPress = false;
	}

    void Update()
    {
        distance = Vector2.Distance(player.transform.position, button.transform.position);
        if (distance < 2)
        {
                test++;
                playerInRange = true;
        }
        else playerInRange = false;

        if (canPress == true && playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MyBuilding.currentSprite++;
                canPress = false;
            }
        }

    }
}
