using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void interact(Inventory inventory) {
        
    }

    [SerializeField] public string interactionText = "";
}
