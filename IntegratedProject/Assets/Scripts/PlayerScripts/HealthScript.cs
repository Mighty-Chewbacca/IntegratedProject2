using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
    //comments!!!
    //This is health!!!!
    public static short health = 4;
    public static short maxHealt = 4;
    public Texture2D heart;
    public float timeBetweenDamage = 1.0f;

    private bool damageCalled = false;

    Animator charAnimation;

    void Start()
    {
        charAnimation = GetComponent<Animator>();

        //set up Player Inventory (in case there's no saved data)
        // first parameter is the name of the object the second is the amount

        if (!DataStore.PlayerInventory.ContainsKey("can")) { DataStore.PlayerInventory.Add("can", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("bottle")) { DataStore.PlayerInventory.Add("bottle", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("paper")) { DataStore.PlayerInventory.Add("paper", 0); }
        if (!DataStore.PlayerInventory.ContainsKey("keys")) { DataStore.PlayerInventory.Add("keys", 0); }



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
        if (col.collider.tag == "Enemy" && damageCalled == false)
        {
            damageCalled = true;
            StartCoroutine(DamageTimer());
        }
        else if (col.collider.tag == "death")
        {
            health = 0;
            Death();
        }
    }

    IEnumerator DamageTimer()
    {
        health--;
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

