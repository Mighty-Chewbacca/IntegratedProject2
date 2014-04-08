using UnityEngine;
using System.Collections;

public class HubLoadStuff : MonoBehaviour {

   public ChangeSprites houses, gardens, decorations;

	// Use this for initialization
	void Start () 
    {
        houses.currentSprite = DataStore.HUBBuildings["houses"];
        gardens.currentSprite = DataStore.HUBBuildings["gardens"];
        decorations.currentSprite = DataStore.HUBBuildings["decorations"];	
	}
}
