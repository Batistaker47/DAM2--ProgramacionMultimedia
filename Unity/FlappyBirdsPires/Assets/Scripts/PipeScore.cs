using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScore : MonoBehaviour
{
    public AudioClip audioClipPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.enabled = true;
            AudioManager.instance.PlayAudio(audioClipPoint, "PointFlappy");
            ScoreManager.instance.UpdateScore();
        }
    }
}
