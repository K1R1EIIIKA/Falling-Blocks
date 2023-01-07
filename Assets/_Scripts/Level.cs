using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Level : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    public int points;
    public float spawnRate = 0.5f;

    [NonSerialized] public bool IsPlay = true;

    private TMP_Text _pointsText;
    private TMP_Text _healthText;
    private TMP_Text _loseText;
    private ButtonClick _buttonClick;
    private Random _random = new Random();

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
        _pointsText.text = "Очков: " + points;
        _healthText.text = "Жизней: " + health;
    }

    private void Die()
    {
        gameOverCanvas.SetActive(true);
        _loseText = GameObject.Find("LoseText").GetComponent<TMP_Text>();
        _loseText.text = "Вы проиграли\n Очков набрано: " + points;
        IsPlay = false;
    }

    private void Restart()
    {
        health = maxHealth;
        points = 0;
        
        gameOverCanvas.SetActive(false);
        IsPlay = true;
    }
}
