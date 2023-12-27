using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtWhat : MonoBehaviour
{
    public InteractScript interactionScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookingObject();
    }

    private void LookingObject()
    {
        Ray ray = new Ray(transform.position , transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 2.0f)) {
            if(hit.collider.gameObject.name == "GreenCrystal" && interactionScript.gameObject.activeSelf == false) {
                interactionScript.gameObject.SetActive(true);
            }
        }
        else {
            if(interactionScript.gameObject.activeSelf == true) {
                interactionScript.gameObject.SetActive(false);
            }
        }
    }
}
