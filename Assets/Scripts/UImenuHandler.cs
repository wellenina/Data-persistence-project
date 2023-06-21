using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class UImenuHandler : MonoBehaviour
{






    // START BUTTON
    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    // HIGH SCORES BUTTON
    public void OpenHighScores()
    {
        SceneManager.LoadScene(2);
    }

    // EXIT BUTTON
    public void Exit()
    {
        //MainManager.Instance.SaveColor(); 

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
