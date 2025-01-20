using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingMode : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private float _rotation = 10f;

    public AudioClip audioClipDead;

    private Rigidbody2D _rb2D;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.velocity = Vector2.up * _speed;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb2D.velocity.y * _rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.enabled = true;
        AudioManager.instance.PlayAudio(audioClipDead, "Flappy Death");
           
        _animator.SetBool("isDead", true);
        GameManager.Instance.GameOver();
    }
}
