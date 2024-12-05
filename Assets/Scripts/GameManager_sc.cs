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
        // UI = GameObject.Find("Canvas").GetComponent<UI_sc>();
        // Spawner = GameObject.Find("Spawner").GetComponent<Spawner_sc>();

        // if (UI == null)
        //     Debug.LogError("UI is NULL");
        // if (Spawner == null)
        //     Debug.LogError("Spawner is NULL");
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
