using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> activeAudios;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            // DontDestroyOnLoad(gameObject); // Uncomment to persist across scenes
            activeAudios = new List<GameObject>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Plays an audio clip.
    /// </summary>
    /// <param name="clip">The audio clip to play.</param>
    /// <param name="objectName">The name of the game object.</param>
    /// <param name="volume">The volume of the audio clip (0-1).</param>
    /// <param name="isLoop">Whether the audio clip should loop.</param>
    /// <returns>The AudioSource component.</returns>
    public AudioSource PlayAudio(AudioClip clip, string objectName, float volume = 1, bool isLoop = false)
    {
        // Create a new GameObject and add an AudioSource component.
        GameObject audioObject = new GameObject(objectName);
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();

        // Set the AudioSource properties.
        audioSourceComponent.clip = clip;
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();

        if (!isLoop)
        {
            activeAudios.Add(audioObject);
            // Start a coroutine to check when the audio has finished playing.
            StartCoroutine(CheckAudio(audioSourceComponent));
        }

        return audioSourceComponent;
    }

    /// <summary>
    /// Coroutine to check when an audio clip has finished playing.
    /// </summary>
    /// <param name="audioSource">The AudioSource component.</param>
    private IEnumerator CheckAudio(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(0.2f);
        }

        // Remove the audio object from the active audios list and destroy it.
        activeAudios.Remove(audioSource.gameObject);
        Destroy(audioSource.gameObject);
    }
}
