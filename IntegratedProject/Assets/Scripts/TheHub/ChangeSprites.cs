using UnityEngine;
using System.Collections;

public class ChangeSprites : MonoBehaviour 
{
	public int currentSprite;
	public Sprite level1, level2;
    public IsClicked MyButton;
	private SpriteRenderer myRenderer;




	void Start () 
	{
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
		currentSprite = 0;
		myRenderer.sprite = level1;


		//set up Player Inventory
		// first parameter is the name of the object the second is the amount
		
		if (!DataStore.HUBBuildings.ContainsKey (this.name)) {DataStore.HUBBuildings.Add (this.name, 0);}
	}

	void Update ()
	{
		if (currentSprite == 1) 
		{
			DataStore.HUBBuildings[this.name] = 1;
			myRenderer.sprite = level2;
		}
	}
}
