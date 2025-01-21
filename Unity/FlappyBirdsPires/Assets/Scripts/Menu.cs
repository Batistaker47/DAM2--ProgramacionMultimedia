using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /// <summary>
    /// Loads the next scene in the build order.
    /// </summary>
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Loads the credits scene.
    /// </summary>
    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}