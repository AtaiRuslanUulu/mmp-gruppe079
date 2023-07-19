using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    public GameObject BackToMainMenuButton;
    public GameObject FinishText;
    public GameObject GoToNextLevel;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private  void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.CompareTag("Player"))
        {
            finishSound.Play();
            BackToMainMenuButton.SetActive(true);
            FinishText.SetActive(true);
            GoToNextLevel.SetActive(true);
        }
    }

}
