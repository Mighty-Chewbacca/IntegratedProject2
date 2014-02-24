using UnityEngine;
using System.Collections;

public class ChangeSprites : MonoBehaviour 
{
	public int currentSprite;
	public Sprite level1, level2, level3;
    public IsClicked MyButton;
	private SpriteRenderer myRenderer;
	void Start () 
	{
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
		currentSprite = 0;
		myRenderer.sprite = level1;
	}

	void Update ()
	{
		if (currentSprite == 1) 
		{
			myRenderer.sprite = level2;
		}
		if (currentSprite == 2) 
		{
			myRenderer.sprite = level3;
		}
	}
}
