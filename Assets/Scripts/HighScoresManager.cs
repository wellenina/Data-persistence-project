using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoresManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.Instance != null)
        {
            for (int i = 0; i < scoreTexts.Length; i++)
            {
                scoreTexts[i].text = DataManager.Instance.highScores[i].ToString();
            }
        }
    }

    public void goBack()
    {
        SceneManager.LoadScene(0);
    }
}
