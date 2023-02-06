using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch,  swipeDelta;

    private void Update(){
      tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

      #region Standalone Inputs
      if(Input.GetMouseButtonDown(0)){
        tap = true;
        isDragging = true;
        startTouch = Input.mousePosition;
      }
      else if (Input.GetMouseButtonUp(1)){ //releasing button on mouse
        isDragging = false;
        Reset();
      }
      #endregion

      #region Mobile Inputs
      if(Input.touches.Length > 0){
        if(Input.touches[0].phase == TouchPhase.Began){
          tap = true;
          isDragging = true;
          startTouch = Input.touches[0].position;
        }
        else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
          isDragging = false;
          Reset();
        }
      }
      #endregion

      //Calculate distance while finger is down
      swipeDelta = Vector2.zero;
      /*if(startTouch != Vector2.zero){ //if not at zero 2 then means we started somewhere
        //this wont work if player somehow gets pixel perfect
      }*/

      if(isDragging){
          if(Input.touches.Length > 0){
            swipeDelta = Input.touches[0].position - startTouch;
          }
          else if(Input.GetMouseButton(0)){
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
          }
      }
      //did we cross the deadzone
      if(swipeDelta.magnitude > 5){
          // which direction are we swiping
          float x = swipeDelta.x;
          float y = swipeDelta.y;

          if(Mathf.Abs(x) > Mathf.Abs(y)){
            //left right
            if(x < 0){
              swipeLeft = true;
              //Debug.Log("swipe left");
            }
            else{
              swipeRight = true;
              //Debug.Log("swipe right");
            }
          }
          else{
            //up down
            if(y < 0){
              swipeDown = true;
              //Debug.Log("swipe up");
            }
            else{
              swipeUp = true;
              //Debug.Log("swipe down");
            }
          }
      }

    }

    private void Reset(){
      startTouch = swipeDelta = Vector2.zero;
      isDragging = false;
    }

    public bool Tap {get {return tap;}}
    public Vector2 SwipeDelta {get {return swipeDelta;} }
    public bool SwipeLeft {get {return swipeLeft;} }
    public bool SwipeRight {get {return swipeRight;} }
    public bool SwipeUp {get {return swipeUp;} }
    public bool SwipeDown {get {return swipeDown;} }


}
