using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
{
	public ChangeSprites Building1, Building2, Building3;
    public GameObject chatBox, B1Button, B2Button, B3Button;
    private bool canPress;

	void Start ()
	{
        canPress = true;
	}

	void OnMouseDown()
	{
        if (canPress == true)
        {
            canPress = false;
            Instantiate(chatBox, new Vector2(-2, 4), Quaternion.identity);
            Instantiate(B1Button, new Vector2(4, 2), Quaternion.identity);
            Instantiate(B2Button, new Vector2(2, 2), Quaternion.identity);
            Instantiate(B3Button, new Vector2(0, 2), Quaternion.identity);
        }
		//Building1.currentSprite ++;
		//Building2.currentSprite ++;
		//Building3.currentSprite ++;
	}

	void Update () 
	{

	}
}
