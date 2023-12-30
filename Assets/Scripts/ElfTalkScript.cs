using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfTalkScript : MonoBehaviour
{
    public bool isTalking = false;
    public bool isMistralStopped = false;
    private bool isFirstTalkDone = false;
 
    public Subtitle_UI_Script UI_Subtitle_Script;

    private List<KeyValuePair<string, float>> initialTalk_1 = new List<KeyValuePair<string, float>>();
    private List<KeyValuePair<string, float>> afterMistralTalk_1 = new List<KeyValuePair<string, float>>();

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        addNewPair(initialTalk_1, "Hello my child, my name is Hyperion and I am the protecter of this realm.", 5f);
        addNewPair(initialTalk_1, "Welcome to the Mirage dimension.", 2.5f);   

        addNewPair(afterMistralTalk_1, "This is my assistant Mistral.", 2f);  
        addNewPair(afterMistralTalk_1, "Don't be afraid, he is not here to hurt you. He is here to protect you from the black fog.", 5.5f);         
        addNewPair(afterMistralTalk_1, "That black fog is the only thing keeping you from leaving this realm.", 4f);
        addNewPair(afterMistralTalk_1, "You can not cross the fog, not yet. First you need the tool cut through the fog.", 5f);
        addNewPair(afterMistralTalk_1, "I can help you build this tool.", 2f);
        addNewPair(afterMistralTalk_1, "It's called The Crystal Wand.", 2f);
        addNewPair(afterMistralTalk_1, "You need six jade crystals to create this wand.", 3f);
        addNewPair(afterMistralTalk_1, "As you can see one of the crystals is behind me. You can start by picking it up.", 5f);
        addNewPair(afterMistralTalk_1, "When you find the six crystals, come back to me. I'll give you the wand.", 4f);
        addNewPair(afterMistralTalk_1, "If you have trouble the finding the crystals, look up in the sky and look for Mistral. He will fly over the areas where the crystals are found.", 8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Astra" && !isTalking && !isFirstTalkDone) {
            isTalking = true;
            UI_Subtitle_Script.changeTextValue(initialTalk_1, 0);
            isFirstTalkDone = true;
        }
    }

    void addNewPair(List<KeyValuePair<string, float>> talk, string text, float time) {
        talk.Add(new KeyValuePair<string, float>(text, time));
    }

    public void startSecondTalk() {
        UI_Subtitle_Script.changeTextValue(afterMistralTalk_1, 2);
    }
}
