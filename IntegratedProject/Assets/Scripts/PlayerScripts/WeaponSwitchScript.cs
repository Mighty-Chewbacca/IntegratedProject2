using UnityEngine;
using System.Collections;

public class WeaponSwitchScript : MonoBehaviour 
{		
	public MeleeeAttack meleeAtk;
	public AttackScript atkScript;
	public bool weaponCheck;
		
	void Start()
	{
		meleeAtk = GetComponent<MeleeeAttack>();
		atkScript = GetComponent<AttackScript>();
	}
		
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && weaponCheck == true)
		{
			Debug.Log("Melee selected");
			weaponCheck = false;
			meleeAtk.enabled = true;
			atkScript.enabled = false;
		}
		else if (Input.GetKeyDown(KeyCode.Q) && weaponCheck == false)
		{
			Debug.Log("Gun selected");
			weaponCheck = true;
			meleeAtk.enabled = false;
			atkScript.enabled = true;
		}
	}
}


