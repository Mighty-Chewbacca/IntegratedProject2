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

    void OnMouseDown()
    {
        //if(input.GetKeyDown("space")) -- move to update method and use this line
        if (canPress == true && playerInRange == true)
        {
            MyBuilding.currentSprite++;
            canPress = false;
        }

    }

    void Update()
    {
        distance = Vector2.Distance(player.transform.position, button.transform.position);

        if (distance < 1)
        {
            test++;
            playerInRange = true;
        }
        else playerInRange = false;
    }
}
