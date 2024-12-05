using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_sc : MonoBehaviour
{
    GameManager_sc GM;
    [SerializeField] TextMeshProUGUI gameOverTMP;
    [SerializeField] TextMeshProUGUI RestartTMP;

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] Image livesImage;
    [SerializeField] Sprite[] livesSprites;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager_sc>();

        if (GM == null)
            Debug.LogError("GameManager is NULL");

        StartGame();
    }

    void Update()
    {
    }

    public void UpdateScore(int score)
    {
        scoreTMP.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        livesImage.sprite = livesSprites[lives];

        if (lives == 0)
            EndGame();
    }

    void StartGame()
    {
        scoreTMP.text = "Score: 0";
        livesImage.sprite = livesSprites[3];

        gameOverTMP.gameObject.SetActive(false);
        RestartTMP.gameObject.SetActive(false);
    }

    void EndGame()
    {
        gameOverTMP.gameObject.SetActive(true);
        RestartTMP.gameObject.SetActive(true);

        if (GM != null)
            GM.GameOver();
    }
}
