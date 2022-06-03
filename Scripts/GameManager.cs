using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text healthText, scoreText;
    int score = 0;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        healthText.text = "HEALTH: " + PlayerController.health.ToString();
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void UpdateLives(int count)
    {
        PlayerController.health -= count;
        healthText.text = "HEALTH: " + PlayerController.health.ToString();
    }

    public void UpdateScores(int _score)
    {
        score += _score;
        scoreText.text = "SCORE: " + score.ToString();
    }
}
