using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour 
{
	//speed value
	public float maxSpeed = 10.0f;
	public bool facingRight = true;
	public bool grounded = true;
	public float jumpforce = 500f;
 	public GameObject jumpCollider;
	bool isAnimationOn = false;


	Animator charAnimation;

	// Use this for initialization
	void Start () 
	{
		if (isAnimationOn) { charAnimation = GetComponent<Animator> (); }
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Ground")
        {
			grounded = true;
			if (isAnimationOn) {charAnimation.SetBool ("Grounded", true);}
			Debug.Log("grounded");
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis("Horizontal");
		if (isAnimationOn) {charAnimation.SetFloat ("Speed", Mathf.Abs (move));	}
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		if(move > 0 && !facingRight)
		{
			FlipFacing();
		}
		else if(move < 0 && facingRight)
		{
			FlipFacing();
		}
/*
if (Input.GetKey (KeyCode.E)) {
			charAnimation.SetBool("Kick",true);
		} 

*/

		if(Input.GetKeyDown(KeyCode.Space) & grounded == true)
		{
            grounded = false;
            charAnimation.SetBool("Grounded", false);
            Debug.Log("went to orbit");
			rigidbody2D.AddForce(new Vector2 (0, jumpforce));
		}


	}
	
	void FlipFacing()
	{
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
