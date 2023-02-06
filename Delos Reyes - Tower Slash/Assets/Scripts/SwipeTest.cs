using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
  public Swipe swipeControls;
  public Transform player;

  public float speed = 3f;
  private Vector2 desirePos;

    // Update is called once per frame
    private void Update()
    {
        if(swipeControls.SwipeLeft){
          desirePos += Vector2.left;
        }
        if(swipeControls.SwipeRight){
          desirePos += Vector2.right;
        }
        if(swipeControls.SwipeUp){
          desirePos += Vector2.up;
        }
        if(swipeControls.SwipeDown){
          desirePos += Vector2.down;
        }

        player.transform.position= Vector2.MoveTowards(player.transform.position, desirePos, speed* Time.deltaTime); //really big steps here for some reason

        if(swipeControls.Tap){
          Debug.Log ("Tap!");
        }
    }
}
