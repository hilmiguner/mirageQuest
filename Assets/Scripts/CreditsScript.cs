using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CreditsScript : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootContainer;
    private Label midText;
    // Start is called before the first frame update
    void Start()
    {
        rootContainer = uiDoc.rootVisualElement;
        midText = rootContainer.Q<Label>("MidText");
        Invoke("changeText", 3);
        Invoke("changeScene", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeText() {
        midText.text = "Thanks for playing the game !\n\nHilmi Güner\nSümeyra Eymen Beyribey\nAleyna Kocabey";
    }

    void changeScene() {
        SceneManager.LoadScene("MainMenu");
    }
}
