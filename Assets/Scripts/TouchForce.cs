using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchForce : MonoBehaviour
{
    public Vector3 fp;   //First touch position
    public Vector3 lp;   //Last touch position
    public Vector3 Change;  //change between initial and final touch

    public Shoot shoot;
    public Slider force;
    public Bow bow;
    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
                if((Change.x!=0 || Change.y!=0)&& bow.MousePos.y<8 && bow.MousePos.x <1)
                {
                    shoot.shoot_press();  //calling shoot function
                }
            }
            Change = lp - fp;
            if(/*Change.x<0 && Change.y<0 && */bow.MousePos.x<1)
            {
                /*if (Mathf.Abs(Change.x) > 1)
                {*/
                    if(((Change.x)*10)<2000)
                    {
                        shoot.LaunchForce = (float)(Mathf.Abs(Change.x) *10);
                        force.value = shoot.LaunchForce;
                    }
                //}
            }
        }
    }
}