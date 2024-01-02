using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixAudio : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InvokeFunc() {
        audioSource.Play();
    }

    // public void playScreamSound() {
    //     Invoke("InvokeFunc", 1);
    // }
    public void playScreamSound() {
        audioSource.Play();
    }
}
