using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_sc : MonoBehaviour
{
    // UI_sc UI;
    // Spawner_sc Spawner;
    [SerializeField] bool isGameOver = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
            SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
