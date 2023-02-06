using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
  public GameObject goverPanel;
  public GameObject scorePanel;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
          Debug.Log("gameover and score panel activated");
          goverPanel.SetActive(true);
          scorePanel.SetActive(false);
        }
    }

    public void Restart()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Back()
    {
      SceneManager.LoadScene("mainmenu");
    }

    public void Quit()
    {
      Debug.Log("Game Exited");
      Application.Quit();
    }
}
