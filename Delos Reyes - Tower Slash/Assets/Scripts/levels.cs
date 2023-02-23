using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levels : MonoBehaviour
{
    public GameObject diffPanel;
    public void play()
    {
        diffPanel.SetActive(true);
    }
    public void quit()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
    public void back()
    {
      diffPanel.SetActive(false);
    }
    public void easy()
    {
      SceneManager.LoadScene("easy");
    }
    public void medium()
    {
      SceneManager.LoadScene("medium");
    }
    public void hard()
    {
      SceneManager.LoadScene("hard");
    }
}
