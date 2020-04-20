using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_coalPile : Interactables {
    // public override void
    private Item item;
    private void Start() {
        item = new Item();
        item.name = "coal";    
    } 
    public override void interact(Inventory inventory) {
        if(inventory.giveItem(item)) {
            Debug.Log("player given coal");
        } else {
            Debug.Log("player inventory full");
        }
    }

    
}
