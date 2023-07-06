using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class SettingsMenu : MonoBehaviour
{
    public void ChangeSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SettingsMenu");
    }
}
