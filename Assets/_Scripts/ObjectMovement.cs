using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;
    [SerializeField] private float rotationSpeed = 2;
    
    private int _rotationCount;
    private Level _level;
    private Random _random = new Random();
    
    private void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<Level>();
        movementSpeed = _random.Next(1, 4);
    }

    void Update()
    {
        if (_level.IsPlay)
        {
            Move();
            Rotate();
        }
        else
        {
            Destroy(transform.GameObject());
        }
    }

    private void Move()
    {
        transform.position += new Vector3(0, -1, 0) * movementSpeed;
    }

    private void Rotate()
    {
        _rotationCount++;
        transform.rotation = Quaternion.Euler(0, 0, _rotationCount * rotationSpeed / 10);
    }
}
