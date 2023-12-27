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

    public async void changeTextValue(List<KeyValuePair<string, float>> talkList, int talkID) {
        subtitleLabel.style.backgroundColor = black;
        foreach (KeyValuePair<string, float> pair in talkList) 
        {
            subtitleLabel.text = pair.Key;
            await Task.Delay((int)Math.Round(pair.Value*1000));
        }
        subtitleLabel.style.backgroundColor = transparentColor;
        subtitleLabel.text = "";
        etc.allTalks = Array.FindAll(etc.allTalks, val => val != talkID);
        etc.isTalking = false;
        if(etc.allTalks.Length == 0) {
            etc.isTalkLeft = false;
        }
    }

    void resetSubtitleLabel() {
        subtitleLabel.text = "";
    }
}
