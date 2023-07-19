using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RacingGameManagerScript : MonoBehaviour
{
    public static RacingGameManagerScript instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] GameObject BackToMainMenuButton;
    [SerializeField] GameObject FinishText;

    void Start()
    {
        BackToMainMenuButton.SetActive(false);
        FinishText.SetActive(false);
    }

        private void Awake()
    {
        if (instance == null){
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelMenu");
    }
}
