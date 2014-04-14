using UnityEngine;
using System.Collections;

public class StoryItemDespawn : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (this.gameObject.tag == "trowel")
        {
            if (Inventory.trowel > 0)
            {
                this.collider2D.enabled = false;
                this.renderer.enabled = false;
            }
        }
        if (this.gameObject.tag == "hammer")
        {
            if (Inventory.hammer > 0)
            {
                this.collider2D.enabled = false;
                this.renderer.enabled = false;
            }
        }
        if (this.gameObject.tag == "paintbrush")
        {
            if (Inventory.paintbrush > 0)
            {
                this.collider2D.enabled = false;
                this.renderer.enabled = false;
            }
        }
	}
}
