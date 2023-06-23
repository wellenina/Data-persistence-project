using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class UImenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject UsernameInputField;
    private TMP_InputField UsernameInput;

    // Start is called before the first frame update
    void Start()
    {
        UsernameInput = UsernameInputField.GetComponent<TMP_InputField>();
    }

    // ENTER NAME INPUT FIELD
    public void SaveUsername()
    {
        DataManager.Instance.currentUsername = UsernameInput.text;
    }

    // START BUTTON
    public void StartNewGame()
    {
        SaveUsername();
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
        DataManager.Instance.SaveData();

    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }








    // Update is called once per frame
    void Update()
    {
        
    }
}
