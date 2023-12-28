using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    public bool isTakeable = false;
    private bool isTaking = false;
    public Inventory characterInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTakeable && Input.GetKey("e") && !isTaking) {
            isTaking = true;
            characterInventory.crystalNumber += 1;
            Destroy(gameObject);
        }
    }
}
