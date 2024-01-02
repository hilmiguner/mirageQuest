using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootContainer;
    private Button playBtn;
    private Button quitBtn;
    // Start is called before the first frame update
    void Start()
    {
        rootContainer = uiDoc.rootVisualElement;
        playBtn = rootContainer.Q<Button>("PlayButton");
        quitBtn = rootContainer.Q<Button>("QuitButton");

        playBtn.clicked += loadDesertScene;
        quitBtn.clicked += exitTheGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadDesertScene() {
        SceneManager.LoadScene("DesertScene");
    }

    void exitTheGame() {
        Application.Quit();
    }
}
