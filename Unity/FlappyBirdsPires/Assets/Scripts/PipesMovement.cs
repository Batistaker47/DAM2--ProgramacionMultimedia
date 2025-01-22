using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 0.65f;

    // Move the pipes to the left
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
