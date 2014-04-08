using UnityEngine;
using System.Collections;

public class ShootSideScript : MonoBehaviour 
{
	private Vector3 rotation;
	public GameObject objBullet;
	public bool facingRight = true;

	// Use this for initialization
	void Start () 
	{
    	rotation = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetMouseButtonDown(0))
		{
			HandleBullets();
		}
	}

	void FixedUpdate ()
	{
		float move = Input.GetAxis("Horizontal");

		if(move > 0 && !facingRight)    {FlipFacing();}
		else if(move < 0 && facingRight)    {FlipFacing();}
	}

	void HandleBullets()
	{
		Instantiate (objBullet, transform.position, Quaternion.LookRotation (rotation));
	}

	void FlipFacing()
	{
		facingRight = !facingRight;

		if (facingRight == true) 
		{
			rotation = new Vector3(1, 0, 0);
		}
		else
		{
			rotation = new Vector3(-1, 0, 0); 
		}
	}
}
