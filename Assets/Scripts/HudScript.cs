using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HudScript : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootContainer;
    private VisualElement leftContainer;
    private VisualElement crystalContainer;
    private Label questLabel;
    private Label crystalLabel;
    // Start is called before the first frame update
    void Start()
    {
        rootContainer = uiDoc.rootVisualElement;
        leftContainer = rootContainer.Q<VisualElement>("LeftContainer");
        crystalContainer = rootContainer.Q<VisualElement>("CrystalContainer");
        questLabel = rootContainer.Q<Label>("QuestLabel");
        crystalLabel = rootContainer.Q<Label>("CrystalLabel");

        leftContainer.style.visibility = Visibility.Hidden;
        crystalContainer.style.visibility = Visibility.Hidden;
        questLabel.text = "Go to mysterious woman";
        questLabel.style.whiteSpace = WhiteSpace.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clearQuestText() {
        questLabel.text = "";
    }

    public void changeQuestText(string text) {
        questLabel.style.color = Color.white;
        questLabel.text = text;
    }

    public void doneCurrentQuest() {
        questLabel.style.color = Color.green;
        Invoke("clearQuestText", 1);
    }

    public void changeCrystalCounter(int count) {
        crystalLabel.text = ": "+count;
    }

    public void showCrystalContainer() {
        crystalContainer.style.visibility = Visibility.Visible;
    }

    public void showLeftContainer() {
        leftContainer.style.visibility = Visibility.Visible;
    }

    public void changeQuestLabel1() {
        Invoke("invokeFunc1", 1);
    }

    void invokeFunc1() {
        changeQuestText("Come back to Hyperion");
    }
}
