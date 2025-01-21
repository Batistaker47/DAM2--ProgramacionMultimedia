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
#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb2D.velocity = Vector2.up * _speed;
            _animator.SetTrigger("Flap");
        }
#elif UNITY_ANDROID || UNITY_IOS
       if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
       {
             _rb2D.velocity = Vector2.up * _speed;
            _animator.SetTrigger("Flap");
       }
#endif
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb2D.velocity.y * _rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        _animator.SetTrigger("Die");
        AudioManager.instance.enabled = true;
        AudioManager.instance.PlayAudio(audioClipDead, "Flappy Death");
        Dead();
    }

    public void Dead()
    {
        GameManager.Instance.GameOver();
    }
}
