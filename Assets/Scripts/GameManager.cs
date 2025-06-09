using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameTimeLimit = 360f;
    private float timer = 0f;


    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float remaining = Mathf.Max(gameTimeLimit - timer, 0);
        int minutes = Mathf.FloorToInt(remaining / 60);
        int seconds = Mathf.FloorToInt(remaining % 60);

        if (timer >= gameTimeLimit)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameEnd");
    }
}
