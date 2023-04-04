using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D collider)
    {
      float hp = 0;
	  if (collider.gameObject.tag == "Opponents")
      {
        collider.gameObject.GetComponent<Unit>().curHP--;
		hp = collider.gameObject.GetComponent<Unit>().curHP;

		if (hp <= 0)
        {
           Destroy(collider.gameObject);
		}
        Destroy(this.gameObject, 0.02f);
      }
      else if (collider.gameObject.tag == "Bullet")
      {
        return;
      }
      else Destroy(this.gameObject, 0.02f);
    }
}
