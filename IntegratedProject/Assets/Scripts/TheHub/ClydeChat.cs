using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
{
	public ChangeSprites Building1, Building2, Building3;
    public IsClicked B1Button, B2Button, B3Button;
    public bool canPress;

	void Start ()
	{
        canPress = true;
	}

    void Update()
    {
        if (B1Button.canPress == false)
        {
            B2Button.canPress = false;
            B3Button.canPress = false;
            canPress = true;
        }

        if (B2Button.canPress == false)
        {
            B1Button.canPress = false;
            B3Button.canPress = false;
            canPress = true;
        }

        if (B3Button.canPress == false)
        {
            B1Button.canPress = false;
            B2Button.canPress = false;
            canPress = true;
        }
    }

	void OnMouseDown()
	{
        if (canPress == true)
        {
            canPress = false;
            B1Button.canPress = true;
            B2Button.canPress = true;
            B3Button.canPress = true;

            //Instantiate(chatBox, new Vector2(-2, 4), Quaternion.identity);
            //Instantiate(B1Button, new Vector2(4, 2), Quaternion.identity);
            //Instantiate(B2Button, new Vector2(2, 2), Quaternion.identity);
            //Instantiate(B3Button, new Vector2(0, 2), Quaternion.identity);
        }
	}
}
