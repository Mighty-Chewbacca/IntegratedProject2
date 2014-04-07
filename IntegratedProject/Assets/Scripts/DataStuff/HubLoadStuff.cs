using UnityEngine;
using System.Collections;

public class HubLoadStuff : MonoBehaviour {

   public ChangeSprites houses, gardens, decorations;

	// Use this for initialization
	void Start () 
    {

        if (!DataStore.HUBBuildings.ContainsKey("houses")) { DataStore.HUBBuildings.Add("houses", 0); }
        if (!DataStore.HUBBuildings.ContainsKey("gardens")) { DataStore.HUBBuildings.Add("gardens", 0); }
        if (!DataStore.HUBBuildings.ContainsKey("decorations")) { DataStore.HUBBuildings.Add("decorations", 0); }

        houses.currentSprite = DataStore.HUBBuildings["houses"];
        gardens.currentSprite = DataStore.HUBBuildings["gardens"];
        decorations.currentSprite = DataStore.HUBBuildings["decorations"];	
	}
}
