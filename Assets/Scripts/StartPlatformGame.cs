using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatformGame : MonoBehaviour
{
    public void StartNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("odyssey_platform");
    }
}
