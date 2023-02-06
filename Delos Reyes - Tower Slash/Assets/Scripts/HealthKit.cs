using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
  GameObject player;
  private PlayerMovement pScript;

    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Manager");
      pScript = player.GetComponent<PlayerMovement>();
    }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Border"){
      Destroy(this.gameObject);
    }
    else if(collision.tag == "Player"){
      if(pScript.health < 10){
        pScript.health++;
      }
      Destroy(this.gameObject);
    }
  }
}
