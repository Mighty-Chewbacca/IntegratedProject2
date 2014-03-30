/*    USED REFERENCES:
// https://docs.unity3d.com/Documentation/ScriptReference/Physics2D.Raycast.html
//http://answers.unity3d.com/questions/464954/raycast-tag-null-reference-exception.html

 */



using UnityEngine;
using System.Collections;

public class movementScript : MonoBehaviour 
{
	//speed value
	public float maxSpeed = 10.0f;
	public bool facingRight = true;
	public bool isLifting = false;
	
	
	public bool grounded = true;
	public float jumpforce = 6000f;
	public float distance;
	public const float jumperror = 1.8f; //DONT CHANGE THIS !!!
	
	public  float LH = -0.66f;
	public  float RH = 0.66f;
	
	public static RaycastHit2D RHray; 
	public static RaycastHit2D LHray;
	
	public bool isDebug = false;

	public float move;
	
	
	
	Animator charAnimation;
	
	// Use this for initialization
	void Start () 
	{
		charAnimation = GetComponent<Animator> ();
		
	}
	
	
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// moving the player sideways
		move = Input.GetAxis("Horizontal");
		charAnimation.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		
		if(move > 0 && !facingRight)    {FlipFacing();}
		else if(move < 0 && facingRight)    {FlipFacing();}
		
		// player jump
		
		//doing a raycast on the two edges of the player char, to see if it's standing above the ground, in a set disctance
		RHray = Physics2D.Raycast(new Vector2((transform.position.x + RH),transform.position.y), -Vector2.up,jumperror,1<<8);
		LHray = Physics2D.Raycast(new Vector2((transform.position.x + LH),transform.position.y), -Vector2.up,jumperror,1<<8);
		
		
		if (isDebug) {
			Debug.DrawRay (new Vector2 ((transform.position.x + RH), transform.position.y), -Vector2.up * 10f, Color.red, 0.01f);
			Debug.DrawRay (new Vector2 ((transform.position.x + LH), transform.position.y), -Vector2.up * 10f, Color.cyan, 0.01f);
			
			if (RHray) {
				Debug.Log (RHray.collider.name);
			}
			if (LHray) {
				Debug.Log (LHray.collider.name);
			}
		}
		if (((RHray) ||(LHray)))
		{

			grounded = true;
			
		}

		if (!isLifting){
		
			if((grounded) && (Input.GetKey(KeyCode.Space)))
			{
				grounded = false;
				charAnimation.SetBool("Grounded", false);
				rigidbody2D.AddForce(new Vector2 (0, jumpforce));
			}
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
