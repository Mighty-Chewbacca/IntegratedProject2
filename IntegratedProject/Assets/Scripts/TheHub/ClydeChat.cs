using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
{
	public ChangeSprites Building1, Building2, Building3;

	void Start ()
	{
	}

	void OnMouseDown()
	{
		Building1.currentSprite ++;
		Building2.currentSprite ++;
		Building3.currentSprite ++;
	}

	void Update () 
	{

	}
}
