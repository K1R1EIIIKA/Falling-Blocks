using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    private float _movementSpeed;
    private float _rotationSpeed;
    
    private int _rotationCount;
    private Level _level;
    private Random _random = new Random();
    
    private void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<Level>();
        _movementSpeed = _random.Next(2, 6);
        _rotationSpeed = _random.Next(1, 4);
    }

    void Update()
    {
        if (_level.IsPlay)
        {
            Move();
            Rotate();
        }
        else
            Destroy(transform.GameObject());
    }

    private void Move()
    {
        transform.position += new Vector3(0, -1, 0) * _movementSpeed;
    }

    private void Rotate()
    {
        _rotationCount++;
        transform.rotation = Quaternion.Euler(0, 0, _rotationCount * _rotationSpeed / 10);
    }
}
