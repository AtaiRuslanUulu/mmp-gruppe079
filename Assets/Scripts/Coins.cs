using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioSource collectionSoundEffect;
    public int value;


    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            CoinsCounter.instance.IncreaseCoins(value);
            collectionSoundEffect.Play();
        }
    }
}
