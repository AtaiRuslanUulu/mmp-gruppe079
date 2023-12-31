using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private AudioSource damageSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //Destroy(gameObject); //destroy enemy when collides with player
            CoinsCounter.instance.DecreaseCoins(damage);
            damageSoundEffect.Play();
        }
    }
}