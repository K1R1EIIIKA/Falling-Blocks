using System;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Level : MonoBehaviour
{
    public int maxHealth = 5;
    public int health = 5;
    public int points;

    [NonSerialized] public bool IsPlay = true;

    private TMP_Text _pointsText;
    private TMP_Text _healthText;
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

    private void SpawnObjects()
    {
        int objectChance = _random.Next(1, 11);
        
    }
}
