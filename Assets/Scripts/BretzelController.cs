using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BretzelController : MonoBehaviour
{
    public static BretzelController instance;

    [SerializeField] private Image _bretzelImage;
    [SerializeField, Range(0.1f,5f)] private float _bretzelDrainSpeed;
    [SerializeField] private float _maxbretzelAmount;

    private float _currentbretzelAmount;

    private void Awake()
    {
        if (instance == null){
            instance = this;
        }
    }

    private void Start()
    {
        _currentbretzelAmount = _maxbretzelAmount;
        UpdateUI();
    }

    private void Update()
    {
        _currentbretzelAmount-= Time.deltaTime * _bretzelDrainSpeed;
        UpdateUI();
    }

    private void UpdateUI(){
        _bretzelImage.fillAmount = (_currentbretzelAmount/_maxbretzelAmount);
    }
}
