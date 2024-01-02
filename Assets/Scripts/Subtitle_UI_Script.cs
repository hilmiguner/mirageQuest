using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class Subtitle_UI_Script : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootContainer;
    private Label subtitleLabel;
    public ElfTalkScript etc;
    public PhoenixMovement pm;
    public CharacterMovement cm;
    public TakeObject to;
    public PhoenixAudio pa;
    public HudScript hudsc;
    public Inventory inventory;

    public GameObject pfp1;

    private Color black = Color.black;
    private Color transparentColor = new Color(0,0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        rootContainer = uiDoc.rootVisualElement;
        subtitleLabel = rootContainer.Q<Label>("Subtitle");
        subtitleLabel.style.backgroundColor = transparentColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public async void changeTextValue(List<KeyValuePair<string, float>> talkList, int index) {
        if(index == 0) {
            hudsc.doneCurrentQuest();
        }
        if(index == 12) {
            hudsc.doneCurrentQuest();
        }
        if(index != 0 && index != 14) {
            cm.isFrozen = true;
        }
        subtitleLabel.style.backgroundColor = black;
        foreach (KeyValuePair<string, float> pair in talkList) 
        {
            subtitleLabel.text = pair.Key;
            etc.audioSource.clip = etc.audioClips[index];
            etc.audioSource.Play();
            index++;
            await Task.Delay((int)Math.Round(pair.Value*1000));
        }
        if(index == 2) {
            pm.canPhoenixMove = true;
            pm.target = pfp1.transform;
            pa.playScreamSound();
        }
        if(index == 12) {
            cm.isFrozen = false;
            to.gameObject.tag = "GreenCrystal";
            hudsc.changeQuestText("Find all the jade crystals");
            hudsc.showCrystalContainer();
            pm.canPhoenixMove = true;
        }
        if(index == 14) {
            cm.isFrozen = false;
            inventory.hasWand = true;
            hudsc.changeQuestText("Go to black fog to wake up.");
            hudsc.showLeftContainer();
            pm.canPhoenixMove = true;
        }
        subtitleLabel.style.backgroundColor = transparentColor;
        subtitleLabel.text = "";
        etc.isTalking = false;
    }

    void resetSubtitleLabel() {
        subtitleLabel.text = "";
    }
}
