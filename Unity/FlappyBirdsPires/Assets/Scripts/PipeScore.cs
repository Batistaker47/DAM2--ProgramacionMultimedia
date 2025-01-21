using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScore : MonoBehaviour
{
    public AudioClip pointSound; // Renamed for clarity

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Enable AudioManager and play the sound
            AudioManager.instance.enabled = true;
            AudioManager.instance.PlayAudio(pointSound, "PointFlappy");
            ScoreManager.instance.UpdateScore();
        }
    }
}
