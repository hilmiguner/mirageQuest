using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMapCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        print("Henüz rüyada kaçabilecek gücün yok");
    }
}