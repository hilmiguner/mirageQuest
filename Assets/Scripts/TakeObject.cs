using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public bool isTakeable = false;
    private bool isTaking = false;
    public Inventory characterInventory;
    public string tag = "GreenCrystal";
    public NearestCrystal nc;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "GreenCrystal1") {
            tag = "Untagged";
        }
        gameObject.tag = tag;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTakeable && Input.GetKey("e") && !isTaking) {
            isTaking = true;
            characterInventory.crystalNumber += 1;
            Destroy(gameObject);
            int index = (int)char.GetNumericValue(gameObject.name[gameObject.name.Length - 1]) - 1;
            nc.crystalVectors[index] = new Vector3(1000f, 1000f, 1000f);
        }
    }
}
