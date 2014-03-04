using UnityEngine;
using System.Collections;

public class PickupUI : MonoBehaviour
{
    public Texture2D pickupSprite;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(200, 10, 30, 30), pickupSprite, ScaleMode.StretchToFill, true, 10.0F);
    }
}
