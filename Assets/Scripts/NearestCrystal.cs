using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestCrystal : MonoBehaviour
{
    public Vector3[] crystalVectors = new Vector3[6];
    public int nearestCrystalNumber = 1;
    public PhoenixMovement pm;
    public GameObject pfp;
    private int lastIndex = 1;
    public bool isFoundAllCrystals = false;
    public OutOfMapCheck oomc;
    // Start is called before the first frame update
    void Start()
    {
        crystalVectors[0] = new Vector3(-2.4f, 111.1f, 34.8f);
        crystalVectors[1] = new Vector3(59.3f, 105.2f, 28.2f);
        crystalVectors[2] = new Vector3(-64.1f, 123.3f, 22.2f);
        crystalVectors[3] = new Vector3(76.3f, 122.2f, -24.9f);
        crystalVectors[4] = new Vector3(-89.9f, 104.7f, -65.9f);
        crystalVectors[5] = new Vector3(71.7f, 112.6f, -75.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFoundAllCrystals && !oomc.isAstraEnteredFog) {        
            float min = 10000.0f;
            int minIndex = -1;
            int count = 0;
            float distance;
            foreach (Vector3 vector in crystalVectors) 
            {
                distance = Vector3.Distance(transform.position, vector);
                if(distance < min) {
                    min = distance;
                    minIndex = count;
                }
                count++;
            }
            nearestCrystalNumber = minIndex+1;
            string name = "PhoneixFlyPoint"+nearestCrystalNumber;
            pfp = GameObject.Find(name);
            pm.target = pfp.transform;
            if(lastIndex != nearestCrystalNumber) {
                pm.lerpValue = 0.0f;
                pm.isLerpMax = false;
            }
            lastIndex = nearestCrystalNumber;
        }
    }
}
