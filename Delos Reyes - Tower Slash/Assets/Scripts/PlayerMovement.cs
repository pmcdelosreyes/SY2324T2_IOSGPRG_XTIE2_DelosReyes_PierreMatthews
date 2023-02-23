using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header ("Obstacles")]
    GameObject[] obstacles;
    GameObject nearest = null;
    GameObject nArrowF = null;
    GameObject nArrowNF = null;
    private float distToEnemy;
    private int boundary = 5;

    public Swipe swipeControls;

    [Header ("Player")]
    public float iniSpeed = 3f;
    public float speed;
    public Transform player;

    public float health = 3;
    private Text hpTxt;
    public GameObject hpText;

    public int combo;

    [Header ("Power Ups")]
    public GameObject[] icons;
    public bool shield = false;
    public bool powersurge = false;
    public bool freeze = false;

    public float shieldCnt = 0;
    public float surgeCnt = 0;
    public float freezeCnt = 0;

    [Header ("Difficulty Feats")]
    public bool medium; //check if this the medium difficulty
    public bool hard; //check if this is the hard difficulty

    public float[] scoreMults = {1f, 1.5f, 2f};
    public float scoreMult;

    // Start is called before the first frame update
    void Start()
    {
        swipeControls = GetComponent<Swipe>();
        hpTxt = hpText.GetComponent<Text>();
        speed = iniSpeed;

        if(medium){
          scoreMult = scoreMults[1];
        }
        else if(hard)
        {
          scoreMult = scoreMults[2];
        }
        else scoreMult = scoreMults[0]; //for easy
    }

    // Update is called once per frame
    void Update()
    {
        hpTxt.text = "x 0" + health;

        if(swipeControls.Tap){
          Dash();
        }

        Nearby();
        Powerups();
    }
    void Dash()
    {
      speed *= 2; //speed up!
    }

    void Nearby()
    { //see if enemy is nearby, then activate their arrow reader too.
      obstacles = GameObject.FindGameObjectsWithTag("Enemy");

      foreach (GameObject o in obstacles){
        float distToEnemy = Vector2.Distance(transform.GetChild(1).position, o.transform.position);
        if (distToEnemy < boundary)
        {
          nearest = o;
          nArrowNF = nearest.transform.GetChild(1).GetChild(0).gameObject; //get their arrows
          nArrowF = nearest.transform.GetChild(1).GetChild(1).gameObject;
          speed *= 0.6f; //slow down player

          nearest.GetComponent<ArrowReader>().enabled = true;
          nArrowNF.SetActive(false); //hide the unfocus
          nArrowF.SetActive(true); //turn on zoom so player can see better
        }
      }
      speed = iniSpeed;
    }

    void Powerups()
    { //numbers here are the ones that check
      if(combo % 27 == 0 && combo != 0)
      { //shields are one time use
        shield = true; //turn shield on off
        shieldCnt++;
        icons[0].SetActive(true);
      }
      else if (combo % 59 == 0 && combo != 0 && !freeze)
      {
        powersurge = true;
        surgeCnt = 15;
        speed *= 5;
        icons[1].SetActive(true);
      }
      else if (combo  %  17 == 0 && combo != 0 && !powersurge)
      {
        freeze = true;
        freezeCnt = 10;
        icons[2].SetActive(true);
      }
    }
}
