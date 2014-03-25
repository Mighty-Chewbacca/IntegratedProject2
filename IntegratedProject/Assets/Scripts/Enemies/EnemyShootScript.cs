using UnityEngine;
using System.Collections;

public class EnemyShootScript : MonoBehaviour 
{
	private Vector3 rotation = new Vector3(-1, 0, 0);
	public GameObject objBullet;
	public bool damageCalled;
	public int timeBetweenShooting; 

	void Start ()
	{
		damageCalled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		if (damageCalled == false) 
		{
			damageCalled = true;
			StartCoroutine (DamageTimer ());
		}
	}

	IEnumerator DamageTimer() 
	{
		Instantiate (objBullet, transform.position, Quaternion.LookRotation (rotation));
		yield return new WaitForSeconds (timeBetweenShooting);
		damageCalled = false;
	}


}