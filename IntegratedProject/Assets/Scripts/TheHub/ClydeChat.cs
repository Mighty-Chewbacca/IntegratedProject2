using UnityEngine;
using System.Collections;

public class ClydeChat : MonoBehaviour
{
    public GameObject player;
    public bool canPress;
    public float distance;

	void Start ()
	{
        canPress = true;
	}

    void Update()
    {
        CheckDistance();

        if (distance < 2.5)
        {
            if (canPress)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    canPress = false;
                }
            }
        }
    }
    void CheckDistance()
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);
    }
}
