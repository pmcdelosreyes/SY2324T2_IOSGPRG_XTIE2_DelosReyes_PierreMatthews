using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  GameObject player;
  private PlayerMovement pScript;

  public bool isBoss = false;
  public float scoreQuota;
  public float pScore;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Manager");
      pScript = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
      if(isBoss){
        pScore = GameObject.Find("points").GetComponent<ScoreManager>().score;
        BossQuota();
      }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Border"){
        //this is where the combo breaks becos smth else destroyed the enemy
        pScript.combo = 0;
        Destroy(this.gameObject);
      }
      else if(collision.tag == "Player"){
        //Debug.Log("hit the player!");
        pScript.health--;

        if(pScript.health < 1){
          Destroy(pScript.transform.GetChild(1).gameObject); //destroy sprite
        }
      }
    }

    void BossQuota()
    {
      if(pScore >= scoreQuota){
        Destroy(this.gameObject);
      }
    }
}
