using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_furnace : Interactables
{
    // Start is called before the first frame update

        private Item item;

        private void Start() {
            item = new Item();
            item.name = "coal";
        }
        public override void interact(Inventory inventory) { 
            if(inventory.takeItem(item)) {
                Debug.Log("Player fed coal to furnace");
                
            } else {
                Debug.Log("Player has no coal");                
            }
        }

}
