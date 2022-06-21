using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOver : MonoBehaviour
{
    bool gameOver = false;
    public GameObject gameOverScreen;
    public TextMeshProUGUI secondsText;

    void Start()
    {
        gameOverScreen.SetActive(false);
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                gameOverScreen.SetActive(false);
                gameOver = false;
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
