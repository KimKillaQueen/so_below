using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int maxInventorySpace;
    public List<Item> items;

    private void Start() {
        items = new List<Item>(maxInventorySpace);
    }
    public bool giveItem(Item item) {
        if(items.Count < maxInventorySpace) {
            items.Add(item);
            return true;
        }

        return false;
    }

    public bool takeItem(Item item) {
        int targetItemIndex = items.FindIndex(obj => {
            return obj.name == item.name;
        });

        if(targetItemIndex != -1) {
            items.RemoveAt(targetItemIndex);
            Debug.Log("Coal removed");
            return true;
        } else {
            return false;
        }
    }
}
