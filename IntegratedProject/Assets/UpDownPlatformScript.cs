using UnityEngine;
using System.Collections;

public class UpDownPlatformScript : MonoBehaviour
{
    public float moveTimer = 2f; // the number of seconds for which the platform will move in one direction
    public float moveSpeed = 0.01f; // determines how fast the platform travels, very sensitive
    private bool moveCycle;

    // Use this for initialization
    void Start()
    {
        moveCycle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (moveCycle == true)
        {
            transform.Translate(Vector3.down * (Time.deltaTime + moveSpeed));
            StartCoroutine(MovementTimer());

        }
        else if (moveCycle == false)
        {
            transform.Translate(Vector3.up * (Time.deltaTime + moveSpeed));
            StartCoroutine(MovementTimer());
        }
    }

    IEnumerator MovementTimer()
    {
        if (moveCycle == false)
        {
            yield return new WaitForSeconds(moveTimer);
            moveCycle = true;
        }
        else
        {
            yield return new WaitForSeconds(moveTimer);
            moveCycle = false;
        }
    }
}
