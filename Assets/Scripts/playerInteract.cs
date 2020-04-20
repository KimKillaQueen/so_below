using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Interactables> allInteractables;
    [SerializeField] public float interactionRadius = 3.0f;
    [SerializeField] public float shovelRotationAmount = 40.0f;
    [SerializeField] public GameObject shovel;
    private bool shovelUp = false;

    public string currentDescription = "";
    public Transform shovelIntialRotation;
    public Transform shovelUpRotation;
    void Start()
    {
        allInteractables = new List<Interactables>(FindObjectsOfType<Interactables>());   
        // shovelIntialRotation = shovel.transform.rotation;
        


    }

    // Update is called once per frame
    void Update()
    {
        var target = search();
        if(target && Input.GetKeyDown(KeyCode.Space)) {
            target.interact(GetComponent<Inventory>());
            if(!shovelUp && target.GetType() == typeof(Interactable_coalPile)) {
                shovelUp = true;
            } else if(target.GetType() == typeof(Interactable_furnace)) {
                shovelUp = false;
            }
            
        }

        if(shovelUp && transform.rotation.eulerAngles.x > -90.0f) {
            // Quaternion tempRotation = Quaternion.AngleAxis(-40.0f, Vector3.right);
            float degree = Mathf.LerpAngle(transform.rotation.eulerAngles.x, -90.0f, 0.1f);
            shovel.transform.Rotate(degree, 0.0f, 0.0f);
        } else if(!shovelUp && transform.rotation.eulerAngles.x < -50.0f) {
            // shovel.transform.rotation = Quaternion.RotateTowards(shovel.transform.rotation, shovelIntialRotation.rotation, 3.0f);
            // Vector3 degree = shovelIntialRotation.localToWorldMatrix.rotation.eulerAngles;
            // shovel.transform.rotation = Quaternion.Euler(degree.x, shovel.transform.rotation.y, shovel.transform.rotation.z);
            float degree = Mathf.LerpAngle(transform.rotation.eulerAngles.x, -50.0f, 0.1f);
            shovel.transform.Rotate(-degree, 0.0f, 0.0f);
            // Quaternion tempRotation = Quaternion.AngleAxis(-40.0f, Vector3.right);
            // shovel.transform.rotation = Quaternion.Slerp(shovel.transform.rotation, shovelIntialRotation.rotation, 0.1f);
            // shovelUpRotation = shovelIntialRotation * tempRotation;
            // shovel.transform.rotation = Quaternion.Slerp(shovel.transform.rotation, shovelIntialRotation, 0.5f);
        } else {

        }

        updateUI();
    }

    private Interactables search() {
        var target = allInteractables.Find(delegate (Interactables interactable) {
            var playerPos = transform.position;
            var interactablePos = interactable.transform.position;
            return (interactablePos - playerPos).magnitude < interactionRadius;
        });

        if(target) {
            currentDescription = target.interactionText;
        } else {
            currentDescription = "";
        }
        return target;
    }

    private void updateUI() {
        FindObjectOfType<Text>().text = currentDescription;
    }

    

}
