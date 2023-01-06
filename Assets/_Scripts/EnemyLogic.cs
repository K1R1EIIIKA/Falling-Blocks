using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int healthReduce;

    private Level _level;
    private Camera _mainCamera;

    private void Start()
    {
        _level = GameObject.Find("EventSystem").GetComponent<Level>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CheckObject();
        
        if (transform.position.y < 50)
        {
            Destroy(transform.GameObject());
        }
    }

    private void CheckObject()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (hit.collider != null && hit.collider.transform == transform)
            DestroyObject();
    }

    private void DestroyObject()
    {
        Destroy(transform.GameObject());
        _level.health -= healthReduce;
    }
}
