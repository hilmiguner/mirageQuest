using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtWhat : MonoBehaviour
{
    public InteractScript interactionScript;
    private TakeObject takeObjectScript;
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
        if (Physics.Raycast(ray, out RaycastHit hit, 2.5f)) {
            print(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "GreenCrystal" && interactionScript.gameObject.activeSelf == false) {
                interactionScript.gameObject.SetActive(true);
                takeObjectScript = hit.collider.gameObject.GetComponent<TakeObject>();
                takeObjectScript.isTakeable = true;
            }
        }
        else {
            if(interactionScript.gameObject.activeSelf == true) {
                interactionScript.gameObject.SetActive(false);
            }
            if(takeObjectScript) {
                takeObjectScript.isTakeable = false;
            }
        }
    }
}
