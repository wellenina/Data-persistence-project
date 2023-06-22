using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text BestScoreText;
    public GameObject GameOverText;
    public Text NewHighScoreText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    private AudioSource mainAudio;
    [SerializeField] private AudioClip brickSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip buttonSound;

    
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score: {DataManager.Instance.bestScoreUsername} {DataManager.Instance.highScores[DataManager.Instance.highScores.Length-1]}";
        ScoreText.text = $"{DataManager.Instance.currentUsername}'s Score: {m_Points}";

        mainAudio = GetComponent<AudioSource>();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = UnityEngine.Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{DataManager.Instance.currentUsername}'s Score: {m_Points}";
        mainAudio.PlayOneShot(brickSound, 1.0f);
    }

    public void GameOver()
    {
        mainAudio.PlayOneShot(gameOverSound, 1.0f);
        m_GameOver = true;
        CheckScore();
        GameOverText.SetActive(true);
    }

    void CheckScore()
    {
        if (m_Points > DataManager.Instance.highScores[DataManager.Instance.highScores.Length-1])
        {
            // NEW HIGH SCORE!
            NewHighScoreText.gameObject.SetActive(true);
            DataManager.Instance.bestScoreUsername = DataManager.Instance.currentUsername;
        }
        if (m_Points > DataManager.Instance.highScores[0])
        {
            DataManager.Instance.highScores[0] = m_Points;
            Array.Sort(DataManager.Instance.highScores);
        }
    }

    public void goBackToMenu()
    {
        mainAudio.PlayOneShot(buttonSound, 1.0f);
        SceneManager.LoadScene(0);
    }
}
