using UnityEngine;
using System.Collections;

public class player_animator_data : MonoBehaviour {

	public string[] char_state = new string[] {"idle","walk","jump","kick","die"};


	public int state = 0;
	public float speed = 8f;


	Animator myanimator;

	// Use this for initialization
	void Start () {
		myanimator = GetComponent<Animator>();

	
	}
	
	// Update is called once per frame
	void Update () {

		myanimator.SetInteger("state",state);		
		Movement ();

	}

	void Movement()

	{

	

		if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector2.right * speed * Time.deltaTime);
						transform.eulerAngles = new Vector2 (0, 0);
						state = 1;
		
		} else if (Input.GetKey (KeyCode.A)) {
						transform.Translate (Vector2.right * speed * Time.deltaTime);
						transform.eulerAngles = new Vector2 (0, 180);
						state = 1;
				} 
		else if (Input.GetKey (KeyCode.W)) {
			state = 4;
		} 

		else if (Input.GetKey (KeyCode.S)) {
			state = 2;
		} 


		else {
			state=0;		
		}




	}


}
