using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    //comments!!!
    //This is health!!!!
    public static short health = 4;
    public static short maxHealt = 4;
    public Texture2D heart;
    public float timeBetweenDamage = 1.0f, colourFlashTime = 0.000001f;
    short damage1 = 1, damage2 = 2;

    private bool damageCalled = false;

    Animator charAnimation;

    void Start()
    {
        charAnimation = GetComponent<Animator>();
    }





    void Death()
    {
        Debug.Log("Called Death() Method successfully");
        charAnimation.SetBool("Dead", true);

        SpawnPlayer.SpawnPlayerToLastCheckpoint(true, true);
        //LoadLastCheckpoint ();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "1Damage" && damageCalled == false)
        {
            damageCalled = true;
            StartCoroutine(DamageTimer(damage1));
        }
        if (col.collider.tag == "2Damage" && damageCalled == false)
        {
            damageCalled = true;
            StartCoroutine(DamageTimer(damage2));
        }
        else if (col.collider.tag == "death" && damageCalled == false)
        {
            health = 0;
            Death();
        }
    }

    IEnumerator DamageTimer(short damage)
    {
        health -= damage;
        yield return new WaitForSeconds(timeBetweenDamage);
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
    }

    void OnGUI()
    {
        switch (health)
        {
            case 4:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(190, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                break;

            case 3:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(130, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);

                break;

            case 2:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                GUI.DrawTexture(new Rect(70, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);

                break;

            case 1:
                GUI.DrawTexture(new Rect(10, 10, 60, 60), heart, ScaleMode.StretchToFill, true, 10.0F);
                break;

            case 0:
                Death();
                break;
        }
    }
}

