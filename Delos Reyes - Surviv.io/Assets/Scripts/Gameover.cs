using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
  public GameObject goverPanel;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player") == null)
        {
          //Debug.Log("gameover and score panel activated");
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
