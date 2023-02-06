using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Touch myTouch = Input.GetTouch(0); //stores an array f gestures and touches
        //myTouch.fingerId -track actions of a touch.
        //myTouch.position - position of touch on screen. a vector 2, origin is at bottom right
        //myTouch.deltaPosition - difference between last frame and current frame, important for knowing fleeDirection
        //myTouch.deltaTime - time since update of the touch, same as Time.deltaTime
        //.tapCount = how many taps are made in quick succession and recorded, if multiple fingers used, then it will all register as the same finger 
        // .phase = TouchPhase.(insertphase here) - available phaes: Began, Canceled, Ended Moved Stationary
        // began = 1st frame of the touch, stationary- finger not moving, moved - finger changed positions on screen ended- returned last frame on the touch
        //canceled - device cant handle the input on the screen, touches more than device can support, or large surface touches on screen

        //retrieve array via Touch[] myTouches = Input.touches;
        //- generally good idea to reiterate thru them, can use .Length but more efficient to use touchCount instead
        //for(int i  = 0; i < Input.touchCount; i++){
        // Do something here}

    }
}
