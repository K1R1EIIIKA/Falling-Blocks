using UnityEngine;
using Random = System.Random;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject pomegranatePrefab;
    public GameObject peachPrefab;
    public GameObject axePrefab;

    private Random _random = new Random();
    private int _objectChance;
    private int _randomPositionX;
    private Level _level;

    private void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<Level>();
        InvokeRepeating(nameof(Spawn), _level.spawnRate, _level.spawnRate);
    }
    
    private void Spawn()
    {
        if (!_level.IsPlay)
            return;

        _objectChance = _random.Next(1, 11);
        _randomPositionX = _random.Next(75, 1001);

        switch (_objectChance)
        {
            case 1: case 2: case 3: case 4: case 5:
            {
                Instantiate(pomegranatePrefab, new Vector3(_randomPositionX, 2060, -0.1f), Quaternion.identity);
                break;
            }
            case 6: case 7:
            {
                Instantiate(peachPrefab, new Vector3(_randomPositionX, 2060, -0.1f), Quaternion.identity);
                break;
            }
            case 8: case 9: case 10:
            {
                Instantiate(axePrefab, new Vector3(_randomPositionX, 2060, -0.1f), Quaternion.identity);
                break;
            }
        }
    }
}
