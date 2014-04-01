using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{
	//comments!!!
	//This is health!!!!
	public int health = 4;
	public Texture2D heart;
	public float timeBetweenDamage = 1.0f;
    private int damage;
	private bool damageCalled = false;

	Animator charAnimation;

	void Start () 
	{
		charAnimation = GetComponent<Animator>();

			//set up Player Inventory (in case there's no saved data)
			// first parameter is the name of the object the second is the amount
			
			if (!DataStore.PlayerInventory.ContainsKey ("can")) {DataStore.PlayerInventory.Add ("can", 0);}
			if (!DataStore.PlayerInventory.ContainsKey ("bottle")) {DataStore.PlayerInventory.Add ("bottle", 0);}
			if (!DataStore.PlayerInventory.ContainsKey ("paper")) {DataStore.PlayerInventory.Add ("paper", 0);}
			
	

	}


	void LoadLastCheckpoint()
	{
        health = 4;
		//spawn player back to the last checkpoint position
		GameObject.Find ("Player").transform.position = GameObject.Find (DataStore.DT.checkpoint).transform.position;

		//load back the inventory

		Inventory.can = DataStore.PlayerInventory ["can"];
		Inventory.bottle = DataStore.PlayerInventory ["bottle"];
		Inventory.paper = DataStore.PlayerInventory ["paper"];

		print ("progress loaded!");

		}


	void Death()
	{
		Debug.Log("Called Death() Method successfully");
		charAnimation.SetBool ("Dead", true);

		LoadLastCheckpoint ();
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.collider.tag == "1Damage" && damageCalled == false) 
		{
            damage = 1;
			damageCalled = true; 
			StartCoroutine(DamageTimer ());
		}

        if (col.collider.tag == "2Damage" && damageCalled == false)
        {
            damage = 2;
            damageCalled = true;
            StartCoroutine(DamageTimer());
        } 
		else if (col.collider.tag == "death") 
		{
			health = 0;
			Death ();
		}
	}

	IEnumerator DamageTimer() 
	{
        health = health - damage;
		yield return new WaitForSeconds (timeBetweenDamage);
		damageCalled = false;
	}
	
	void Update()
	{
		if (health > 4) 
		{
			health = 4;
		}
		else if (health < 0)
		{
			health = 0;
		}

        if (health == 0)
        {
            Death();
        }
	}
}
