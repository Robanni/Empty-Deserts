
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuBehavior : MonoBehaviour
{
    private UnityEngine.UIElements.Button _startButton;
    void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var mainWin = root.Q<VisualElement>("MenuButtons");

        _startButton = root.Q<UnityEngine.UIElements.Button>("StartButton");

        _startButton.clicked += () =>
        {
            SceneManager.LoadScene("SampleScene"); 
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
