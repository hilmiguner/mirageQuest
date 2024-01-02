using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfMapCheck : MonoBehaviour
{
    public Inventory inventory;
    public CharacterMovement cm;
    public PhoenixMovement pm;
    public GameObject astra;
    public AudioSource[] audioSources;
    public AudioSource audioSource;
    public bool isAstraEnteredFog = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = pm.GetComponents<AudioSource>();
        foreach(AudioSource auSource in audioSources) {
            if(auSource.clip.name == "Cry") {
                audioSource = auSource;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(inventory.hasWand) {
            SceneManager.LoadScene("CreditScene");
        }
        else if(!isAstraEnteredFog) {
            isAstraEnteredFog = true;
            pm.canPhoenixMove = true;
            cm.isFrozen = true;
            audioSource.Play();
            pm.target.position = new Vector3(astra.transform.position.x, astra.transform.position.y + 2f, astra.transform.position.z);
            pm.isAstraAttached = true;
            pm.isLerpMax = false;
        }
    }
}
