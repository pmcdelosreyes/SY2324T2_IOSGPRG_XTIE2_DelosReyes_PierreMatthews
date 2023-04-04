using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
  public GameObject goverPanel;
    void Update()
    {
        if (GameObject.Find("player") == null)
        {
          goverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
      Debug.Log("Game Exited");
      Application.Quit();
    }
}
