using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    public int points;

    [NonSerialized] public bool IsPlay = true;

    private TMP_Text _pointsText;
    private TMP_Text _healthText;
    private ButtonClick _buttonClick;

    [SerializeField] private GameObject gameOverCanvas;

    private void Start()
    {
        _buttonClick = GetComponent<ButtonClick>();
        _pointsText = GameObject.Find("PointsText").GetComponent<TMP_Text>();
        _healthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (health <= 0)
            Die();

        if (_buttonClick.IsClick)
        {
            Restart();
            _buttonClick.IsClick = false;
        }
        
        SetPoints();
    }

    private void SetPoints()
    {
        _pointsText.text = points.ToString();
        _healthText.text = "Жизней: " + health;
    }

    private void Die()
    {
        gameOverCanvas.SetActive(true);
        IsPlay = false;
    }

    private void Restart()
    {
        health = maxHealth;
        gameOverCanvas.SetActive(false);
        IsPlay = true;
    }
}
