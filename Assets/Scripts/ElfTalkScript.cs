using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfTalkScript : MonoBehaviour
{
    public bool isTalking = false;
    public bool isTalkLeft = true;
 
    public Subtitle_UI_Script UI_Subtitle_Script;

    public int[] allTalks = {1};
    private List<KeyValuePair<string, float>> initialTalk_1 = new List<KeyValuePair<string, float>>();

    // Start is called before the first frame update
    void Start()
    {
        addNewPair(initialTalk_1, "Test script talk", 2);
        addNewPair(initialTalk_1, "ANOTHER TALK", 5);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Astra" && !isTalking && isTalkLeft) {
            isTalking = true;
            UI_Subtitle_Script.changeTextValue(initialTalk_1, 1);
        }
    }

    void addNewPair(List<KeyValuePair<string, float>> talk, string text, float time) {
        talk.Add(new KeyValuePair<string, float>(text, time));
    }
}
