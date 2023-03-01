using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public void play()
    {
      SceneManager.LoadScene("playground");
    }
    public void quit()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
