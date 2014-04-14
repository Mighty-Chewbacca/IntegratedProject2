/*
used materials; http://www.youtube.com/watch?v=NOWfloaxDX4
used materials; http://www.youtube.com/watch?v=myQcCCa4jlM

*/

using UnityEngine;
using System.Collections;

//show GUI stuff in dev. mode
[ExecuteInEditMode]

public class TextDisplayScript : MonoBehaviour {

	//declarations

	public GUISkin myskin;

	private bool guiEnabled = false;
	private GameObject MyCamera; 
	public Transform target;
	private Vector3 screenPos;
    public int screenHeight;
    public int screenWidth;
    private float timeSincelastTouched = 2.0f;
    bool canTouch = true;



	// Use this for initialization
	void Start ()
    {        
        //set main chamera for tracking
		MyCamera = GameObject.Find("TheCamera");
		target = this.gameObject.transform;
		//assign global skin from DT
		myskin = DataStore.DT.skin;
        screenHeight = Screen.height;
        screenWidth = Screen.width;

	}


	


	void OnTriggerEnter2D(Collider2D other) 
    {
		//turn on gui display
        if ((other.tag == "Player") && (canTouch))
		guiEnabled = true;
	}

    //void OnTriggerExit2D(Collider2D other) 
    //{
    //    //turn off gui display
    //    guiEnabled = false;

    //}

	void OnGUI () 
    {		
		if (guiEnabled == true)
        {
			//draw gui box
			GUI.skin = myskin;
			// 14 pixel width per character including spaces and spec chars
			GUI.Box (new Rect (screenPos.x, (screenHeight - 500), (DataStore.NPCText[this.gameObject.name].Length*8),100),DataStore.NPCText[this.gameObject.name]);
            Time.timeScale = 0;
            canTouch = false;

            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                guiEnabled = false;
                StartCoroutine(LastTouchTimer());
            }
		}
	}

	


	// Update is called once per frame
	void Update () 
    {
		//keep tracking the position
        screenPos = MyCamera.camera.WorldToScreenPoint(target.position);
	}

    IEnumerator LastTouchTimer()
    {
        yield return new WaitForSeconds(timeSincelastTouched);
        canTouch = true;
    }
}
