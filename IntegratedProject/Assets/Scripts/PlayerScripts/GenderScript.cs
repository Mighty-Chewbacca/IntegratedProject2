using UnityEngine;
using System.Collections;

public class GenderScript : MonoBehaviour
{

    private SpriteRenderer myRenderer;
    public Sprite fSprite, mSprite;

    // Use this for initialization
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (DataStore.DT.PlayerGender == DataStore.Gender.female)
            myRenderer.sprite = fSprite;

        if (DataStore.DT.PlayerGender == DataStore.Gender.male)
            myRenderer.sprite = mSprite;
    }
}
