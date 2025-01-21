using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingMode : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _rotation = 10f;

    private bool isDead = false;

    public AudioClip audioClipDead;

    private Rigidbody2D _rb2D;

    void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the game is over
        if (isDead)
        {
            return;
        }

#if UNITY_STANDALONE || UNITY_EDITOR
        // Check for spacebar press on desktop
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlapWings();
        }
#elif UNITY_ANDROID || UNITY_IOS
        // Check for touch input on mobile
        if (Input.touchCount > 0 ) 
        {
            FlapWings(); 
        }
#endif
    }

    // Apply rotation based on vertical velocity
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb2D.velocity.y * _rotation);
    }

    /// <summary>
    /// Makes the bird flap its wings and move upwards.
    /// </summary>
    private void FlapWings()
    {
        _rb2D.velocity = Vector2.up * _speed;
        _animator.SetTrigger("Flap");
    }

    // Handle collision with obstacles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        _animator.SetTrigger("Die");
        AudioManager.instance.enabled = true;
        AudioManager.instance.PlayAudio(audioClipDead, "Flappy Death");
        Dead();
    }

    // Trigger game over event
    public void Dead()
    {
        GameManager.Instance.GameOver();
    }
}
