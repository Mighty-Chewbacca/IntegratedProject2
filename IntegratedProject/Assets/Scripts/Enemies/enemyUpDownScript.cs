using UnityEngine;
using System.Collections;

public class enemyUpDownScript : MonoBehaviour 
{
	public float moveTimer = 2f; // the number of seconds for which the enemy will move in one direction
	public float moveSpeed = 0.01f; // determines how fast the enemy travels, very sensitive
	private bool moveCycle;
    public int health = 5; // amount of health the enemy has, enemy dies once this reaches 0
    public float timeBetweenDamage = 1.5f; // the amount of time for which the enemy is invulnerable after being attacked
    private bool damageCalled = false;
	
	// Use this for initialization
	void Start () 
	{
		moveCycle = true; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.timeScale == 1)
        {
            if (moveCycle == true)
            {
                transform.Translate(Vector3.up * (Time.deltaTime + moveSpeed));
                StartCoroutine(MovementTimer());

            }
            else if (moveCycle == false)
            {
                transform.Translate(Vector3.down * (Time.deltaTime + moveSpeed));
                StartCoroutine(MovementTimer());
            }
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
            StartCoroutine(DamageTimer());
        }

        else if (col.collider.tag == "death")
        {
            RemoveMe();
        }
    }

    IEnumerator DamageTimer()
    {
        health--;
        yield return new WaitForSeconds(timeBetweenDamage);
        damageCalled = false;
    }

    void RemoveMe()
    {
        Destroy(gameObject);
    }
}

