using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour {

    #region
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    #endregion
    public TextMeshProUGUI ScoreText;
    public int Level;
    public int LvlInterval;
    public int Score;
    public GameObject GameOverPanel;
    public TextMeshProUGUI GameOverScoreText;
    public bool IsGameOver { get; private set; }
    public int Drunkness;
    public bool IsDrunk;

    private float _timer;

    private void Start()
    {
        _timer = LvlInterval;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        if (!IsGameOver)
        {
            Score++;
            ScoreText.text = Score.ToString();
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            
                if (_timer <= 0)
                {
                    Level++;
                    _timer = LvlInterval;
                }
            }
        }
    }

    public void ShakeCamera()
    {
        Camera.main.transform.DOShakePosition(1,0.1f);
        Camera.main.transform.DOShakeRotation(1,0.1f);
    }

    public void GameOver()
    {
        GameOverScoreText.text = "Your score is " + Score.ToString();
        GameOverPanel.SetActive(true);
        IsGameOver = true;
    }
}