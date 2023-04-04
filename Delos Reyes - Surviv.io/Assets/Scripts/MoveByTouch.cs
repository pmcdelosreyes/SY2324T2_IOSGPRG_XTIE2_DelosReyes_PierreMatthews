using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< Input.touchCount; i++)
        {
          Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position); //this translates pixel input to world space units
          Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
          //touchPosition.z = 0f;
          //transform.position = touchPosition;
        }
    }
    //NOTES: FOR A SINGLE TOUCH, PLAYER TELEPORTS TO WHERE U TOUCH - put this in update()
    /*if(Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position); //this translates pixel input to world space units
      touchPosition.z = 0f;
      transform.position = touchPosition; //will set camera to same position of touch's z therefore^
    }*/
}
