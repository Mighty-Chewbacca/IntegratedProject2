using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour 
{
	public GameObject objBullet;

	//input variables (variables used to process and handle input)
	private Vector3 inputRotation;
	private Vector3 inputMovement;

	// calculation variables (variables used for calculation)
	private Vector3 tempVector;
	private Vector3 tempVector2;

	public bool playerHasWeapon = true;
	public bool playerHasMelee = true;

	// Update is called once per frame
	void Update () 
	{		
		FindInput ();
	}

	void FindInput ()
	{
		tempVector2 = new Vector3(Screen.width * 0.5f,Screen.height * 0.5f, 0); // the position of the middle of the screen
		tempVector = Input.mousePosition; // find the position of the mouse on screen
		tempVector.z = tempVector.y; // input mouse position gives us 2D coordinates, I am moving the Y coordinate to the Z coorindate in temp Vector and setting the Y coordinate to 0, so that the Vector will read the input along the X (left and right of screen) and Z (up and down screen) axis, and not the X and Y (in and out of screen) axis tempVector.y = 0;
		inputRotation = tempVector - tempVector2; // the direction we want face/aim/shoot is from the middle of the screen to where the mouse is pointing

		if ( Input.GetMouseButtonDown(0))
		{
			HandleBullets();
		}
	}

	void HandleBullets ()
	{
		tempVector = Quaternion.AngleAxis(8f, Vector3.up) * inputRotation;
		tempVector = (transform.position + (tempVector.normalized * 0.8f));
		//Instantiate(ptrScriptVariable.objBullet, tempVector, Quaternion.LookRotation(inputRotation) ); // create a bullet, and rotate it based on the vector inputRotation
		Instantiate(objBullet, tempVector, Quaternion.LookRotation(inputRotation) );
	}
}