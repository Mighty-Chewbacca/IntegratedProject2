using UnityEngine;
using System.Collections;

public class GenderScript : MonoBehaviour
{

    private SpriteRenderer myRenderer;
    public Sprite fSprite, mSprite;
    public RuntimeAnimatorController male, female; 
    Animator myanimator;

    // Use this for initialization
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myanimator = gameObject.GetComponent<Animator>();

        if (DataStore.DT.PlayerGender == DataStore.Gender.female)
        {
            myRenderer.sprite = fSprite;
            myanimator.runtimeAnimatorController = female;
        }

        if (DataStore.DT.PlayerGender == DataStore.Gender.male)
        {
            myRenderer.sprite = mSprite;
            myanimator.runtimeAnimatorController = male;
        }
    }
}
