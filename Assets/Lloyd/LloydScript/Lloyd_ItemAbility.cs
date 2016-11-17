
using UnityEngine;
using System.Collections;
/// <summary>
/// this class give the player gameObject special ability when it touch the item
/// </summary>
public class Lloyd_ItemAbility : MonoBehaviour {
    /// <summary>
    /// check to see if the player touches the item
    /// </summary>
    bool isTouchItem = false;
    /// <summary>
    /// check to see which ability does item give the player
    /// </summary>
    public int itemPowerIndex = 0;
    /// <summary>
    /// this turn of the mesh renderer once the player touches the item
    /// </summary>
    MeshRenderer visible;
	// Use this for initialization
	void Start () {
        visible = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
    /// <summary>
    /// This activate once the player touch the item
    /// </summary>
    /// <param name="obj">check to see if the obj is the game player</param>
    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Player" && !isTouchItem)
        {
            switch (itemPowerIndex)
            {
                case 0:
                    HudManager.jumpCount = 1;
                    turnOffItem();
                    break;
                case 1:
                    HudManager.shieldCount = 1;
                    turnOffItem();
                    break;
                case 2:
                    HudManager.PickUpCombo();
                    turnOffItem();
                    break;
                case 3:
                    staticController.boost = true;
                    turnOffItem();
                    break;

            }

        }
    }
    void turnOffItem()
    {
        isTouchItem = true;
        Destroy(visible);
    }
}
