/* USED RESOURCES
//	http://forum.unity3d.com/threads/63964-transform-localEulerAngles-x-10-does-not-work-in-C

*/

using UnityEngine;
using System.Collections;

public class MeleeeAttack : MonoBehaviour {

	public float swingSpeed = 5000.0f;
	public float maxAngle = 160.0f;
	public float minAngle = 359.9f;
	private bool movingUp = true;
	private bool motiondone = false;
    private bool isSwinging = false;




	void SwingArm()


	{
		//this.GetComponent (BoxCollider2D).collider2D.enabled = false;
		//this.collider2D.enabled = true;

		do 
        {
		if (movingUp) 
        {
			transform.Rotate (Vector3.forward * Time.deltaTime * swingSpeed);
		}
		else 
        {
			transform.Rotate (Vector3.back * Time.deltaTime * swingSpeed);
		}
		
		
		//turn rotation on the top
		if (transform.rotation.eulerAngles.z > maxAngle) {
			movingUp = false;		
		}
		
		//turn rotation on the bottom
		if ((transform.rotation.eulerAngles.z < minAngle)&& (transform.rotation.eulerAngles.z > 350f) ) {

			
				motiondone = true; //exit the loop
                isSwinging = false;
			//reset the postition and direction
			movingUp = true;
			transform.localEulerAngles = new Vector3(0,0,1f);


			
			}
		
		}while(!motiondone);

		//this.GetComponent (BoxCollider2D).collider2D.enabled = false;
		//this.collider2D.enabled = false;
		return;
	}





	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.M) )
		{
            isSwinging = true;
		}

        if (isSwinging)
        {
            SwingArm();
        }
	

}
}
