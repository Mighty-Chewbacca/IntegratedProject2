using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float bulletLifetime = 1; // how long the bullet will stay alive for
	public float moveSpeed = 30f; // how fast the bullet moves
	private float timeSpentAlive; // how long the bullet has stayed alive for

	// Update is called once per frame
	void Update () 
	{
		timeSpentAlive += Time.deltaTime;
		if (timeSpentAlive > bulletLifetime) // once the bullet has been alive for as long as bulletLifetime it will be removed
		{
			removeMe();
		}
		// move the bullet
		transform.Translate(0, 0, moveSpeed * Time.deltaTime);
		transform.position = new Vector3(transform.position.x, transform.position.y, 0); // because the bullet has a rigid body we don't want it moving off it's Z axis
	}

	void removeMe ()
	{
		Destroy(gameObject); // remove the bullet
	}

	void OnCollisionEnter2D(Collision2D Other)
	{
		Physics2D.IgnoreLayerCollision (9, 10); // collision between player and bullet is ignored
		removeMe(); 
	}

}