using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f; // Speed at which the ground moves
    [SerializeField] private float _width = 6f; // Maximum width of the ground

    private SpriteRenderer _spriteRenderer; // Reference to the SpriteRenderer component

    private Vector2 _startSize; // Store the initial size of the ground

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component

        // Store the initial size of the ground
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the width of the ground over time
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _speed * Time.deltaTime, _spriteRenderer.size.y);

        // Reset the ground width if it exceeds the maximum width
        if (_spriteRenderer.size.x > _width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
