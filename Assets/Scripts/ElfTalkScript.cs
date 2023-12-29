using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfTalkScript : MonoBehaviour
{
    public bool isTalking = false;
 
    public Subtitle_UI_Script UI_Subtitle_Script;

    private List<KeyValuePair<string, float>> initialTalk_1 = new List<KeyValuePair<string, float>>();

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        addNewPair(initialTalk_1, "Hello my child, my name is Hyperion and I am the protecter of this realm.", 5f);
        addNewPair(initialTalk_1, "Welcome to the Mirage dimension.", 2.5f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Astra" && !isTalking) {
            isTalking = true;
            UI_Subtitle_Script.changeTextValue(initialTalk_1, 0);
        }
    }

    void addNewPair(List<KeyValuePair<string, float>> talk, string text, float time) {
        talk.Add(new KeyValuePair<string, float>(text, time));
    }
}
