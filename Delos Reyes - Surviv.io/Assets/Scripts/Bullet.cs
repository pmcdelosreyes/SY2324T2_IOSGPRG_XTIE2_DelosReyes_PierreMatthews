using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ //for gun class so it shoots out and hits player ded

  void OnCollisionEnter2D(Collision2D collider)
    {
      float hp = 0;

	  if (collider.gameObject.tag == "Opponents")
      {
        collider.gameObject.GetComponent<Unit>().curHP--;
		hp = collider.gameObject.GetComponent<Unit>().curHP;
	    //Debug.Log(collider.gameObject.name + " HP left: " + hp);

		if (hp <= 0)
        {
           Destroy(collider.gameObject); //delete the unit
		}
        Destroy(this.gameObject, 0.02f);
      }
      else if (collider.gameObject.tag == "Bullet")
      {
        return; //phase thru
      }
      else Destroy(this.gameObject, 0.02f);
    }
}
