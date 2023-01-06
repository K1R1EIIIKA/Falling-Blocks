using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;
    [SerializeField] private float rotationSpeed = 2;
    
    private int _rotationCount;
    private Level _level;


    private void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<Level>();
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
        
        if (transform.position.y < 50)
        {
            Destroy(transform.GameObject());
            _level.health--;
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
