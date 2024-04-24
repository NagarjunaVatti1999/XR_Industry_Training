using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager Instance {get; private set;}
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private int score = 0;
    [SerializeField] public float maxtime = 0;

    [Header("Game Over Condition")]
    [SerializeField] private GameObject[] Interactors;
    [SerializeField] private Canvas gameOver;
    [SerializeField] AudioClip gameOverClip;

    private bool isPlayerReady = false;
    private void Start() {
        gameOver.gameObject.SetActive(false);
    }
    private void Update() {
        if(isPlayerReady)StartTimer();
    }

    private void StartTimer()
    {
        if(maxtime > 0)
        {
            maxtime -= Time.deltaTime;
        }
        else if(maxtime <0){    //gameOver
            maxtime = 0;
            GameOver();
        }
        int minutes = Mathf.FloorToInt(maxtime/60);
        int seconds = Mathf.FloorToInt(maxtime%60);
        timeText.text = string.Format("Time Left : {0:00}:{1:00}",minutes,seconds);
    }

    private void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        foreach(GameObject go in Interactors)
        {
            go.SetActive(false);
        }
        AvatarAudio.Instance.PlayAudioMessage(gameOverClip);
    }
    public void RestartGame(int scene)
    {
        SceneChanger.Instance.ChangeScene(scene);
    }
    private void Awake() {
        Instance = this;
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score : "+score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void SetIsPlayerReady(bool flag)
    {
        isPlayerReady = flag;
    }
}
