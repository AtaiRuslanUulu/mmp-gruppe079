using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;
    public TMP_Text coinText;
    public int currentCoins = 0;


    [SerializeField] private AudioSource collectionSoundEffect;
    public int value;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            collectionSoundEffect.Play();
            Destroy(gameObject);
            CoinsCounter.instance.IncreaseCoins(value);
        }
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }
}
