using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_furnace : Interactables
{
    // Start is called before the first frame update

    private float fuelTimer = 50.0f;
    private float currentFuelLeft = 50.0f;
    private float refuelTime = 3.0f;
    private Item item;
    public List<Light> lights;
    public List<float> intensities;
    public bool refueling = false;

    private void Start()
    {
        item = new Item();
        item.name = "coal";

        lights = new List<Light>(FindObjectsOfType<Light>());
        foreach (var light in lights)
        {
            intensities.Add(light.intensity);
        }
    }

    private void Update()
    {
        if (!refueling)
        {
            currentFuelLeft -= Time.deltaTime;
            for (int x = 0; x < lights.Count; x++)
            {
                lights[x].intensity = Mathf.Max(intensities[x], lights[x].intensity) * (currentFuelLeft / fuelTimer);
            }
        }
        // FindObjectsOfType<Light>().intensity *= currentFuelLeft / fuelTimer;

    }
    public override void interact(Inventory inventory)
    {
        if (inventory.takeItem(item))
        {
            Debug.Log("Player fed coal to furnace");
            currentFuelLeft = fuelTimer;
            refueling = true;
            StartCoroutine("lightRise");
        }
        else
        {
            Debug.Log("Player has no coal");
        }
    }

    private IEnumerator lightRise()
    {
        float timer = 0.0f;

        while (timer < refuelTime)
        {
            for (int x = 0; x < lights.Count; x++)
            {
                lights[x].intensity += intensities[x] * (timer / refuelTime);
                lights[x].intensity = Mathf.Min(lights[x].intensity, intensities[x] * 1.25f);
            }
            timer += Time.deltaTime;

            yield return null;
        }

        refueling = false;

        
    }

}
