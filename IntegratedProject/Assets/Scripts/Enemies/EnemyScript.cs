using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public int health = 5; // amount of health the enemy has, enemy dies once this reaches 0
	public GameObject enemy;
	public float moveTimer = 2f; // the number of seconds for which the enemy will move in one direction
	public float moveSpeed = 0.01f; // determines how fast the enemy travels, very sensitive
	public float timeBetweenDamage = 1.5f; // the amount of time for which the enemy is invulnerable after being attacked
	private bool moveCycle;
	private bool damageCalled = false;
    private int jumpforce = 250;

	// Use this for initialization
	void Start () 
	{
		moveCycle = true; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (moveCycle == true) 
		{
			transform.Translate(Vector3.left * (Time.deltaTime + moveSpeed));
			StartCoroutine(MovementTimer ());

		} 
		else if (moveCycle == false)
		{
			transform.Translate(Vector3.right * (Time.deltaTime + moveSpeed));
			StartCoroutine(MovementTimer ());
		}
		if (health <= 0) 
		{
			RemoveMe();
		}
	}

	IEnumerator MovementTimer() 
	{
		if (moveCycle == false) 
		{
			yield return new WaitForSeconds (moveTimer);
			moveCycle = true;
		} 
		else
		{
			yield return new WaitForSeconds (moveTimer);
			moveCycle = false; 
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "Bullet" && damageCalled == false) 
		{
			damageCalled = true; 
			StartCoroutine(DamageTimer ());
		}
        if (col.collider.tag == "Ground")
        {
            rigidbody2D.AddForce(new Vector2(0, jumpforce));
        } 
		else if (col.collider.tag == "death") 
		{
			RemoveMe();
		}
	}
	
	IEnumerator DamageTimer() 
	{
		health--;
		yield return new WaitForSeconds (timeBetweenDamage);
		damageCalled = false;
	}

	void RemoveMe()
	{
		Destroy(gameObject);
	}
}

