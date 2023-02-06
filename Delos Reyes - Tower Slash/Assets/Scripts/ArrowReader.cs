using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowReader : MonoBehaviour
{
  public Swipe swipeControls;
  public PlayerMovement pScript;
  public ScoreManager score;

  public string arrow;
  private string pSwipe;

  void Start()
  {
    swipeControls = GameObject.FindGameObjectWithTag("Manager").GetComponent<Swipe>();
    //arrow = Random.Range(0,arrows.Length); //assign a random arrow direction to enemy
    pScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayerMovement>();
    score = GameObject.Find("points").GetComponent<ScoreManager>();
  }

    // Update is called once per frame
    private void Update()
    {
      pSwipe = null;  //reset

      //checks if player has activated any of these swipes  and logs it in
      CheckSwipe();

      Match();
    }

    void CheckSwipe()
    {
      if(swipeControls.SwipeLeft) pSwipe = "left";
      else if(swipeControls.SwipeRight) pSwipe = "right";
      else if(swipeControls.SwipeUp) pSwipe = "up";
      else if(swipeControls.SwipeDown)  pSwipe = "down";

      //Debug.Log(pSwipe);
    }

    void Match()
    {
      if(!pScript.shield && !pScript.powersurge && !pScript.freeze){
        if(pSwipe == arrow){
          IncreaseScore();
        }
      }
      else if(pScript.shield){
        pSwipe = arrow; //regardless of swipe, its equal to the assigned arrow becos temp immunity
        IncreaseScore();
        pScript.shieldCnt = 0; //reset it
        pScript.icons[0].SetActive(false);
        pScript.shield = false; //turn it off
      }
      else if(pScript.powersurge && !pScript.freeze && !pScript.shield){
        pSwipe = arrow;
        IncreaseScore();
        pScript.surgeCnt--; //decrease use

        if(pScript.surgeCnt < 1) {
          pScript.speed = pScript.iniSpeed;
          pScript.icons[1].SetActive(false);
          pScript.powersurge = false;
        }
      }
      else if(pScript.freeze && !pScript.powersurge && !pScript.shield){
        pScript.speed *= 0.07f; // slow down player?

        if(pSwipe == arrow){
          IncreaseScore();
        }
        pScript.freezeCnt--;

        if(pScript.freezeCnt < 1){
          pScript.speed = pScript.iniSpeed;
          pScript.icons[2].SetActive(false);
          pScript.freeze = false;
        }
      }
    }

    void IncreaseScore()
    { //increase player score and combo then delete this object
      score.score += 50;
      pScript.combo++;
      Destroy(this.gameObject);
    }

}
