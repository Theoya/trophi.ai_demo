using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelHandler : MonoBehaviour
{
    [Header("Variables to Handle the Wheel Movement")]
    [Tooltip("Text element to represent speed")]
    public GameObject speedText = null;
    public float turnSpeed = 0.5f;
    public float turnTracker = 0.0f;
    public float turnDecay = 0.05f;
    public float turnMax = 3.0f;
    public float turnMin = -3.0f;

    [Header("This Wheel's Car")]
    [Tooltip("The car this element belongs to")]
    public GameObject car = null;

    // Update is called once per frame
    void Update()
    {
        this.speedText.GetComponent<Text>().text = ((int)(car.GetComponent<CarHandler>().speed/1.5)).ToString();
    }

    //Functions to handle the wheel movement. left, right and return to center.
    public void TurnLeft(){
        if (this.turnTracker > this.turnMin){
            transform.Rotate(-this.turnSpeed, 0.0f, 0.0f, Space.Self);
            this.turnTracker-=this.turnSpeed;
        }

    }

    public void TurnRight(){
        if (this.turnTracker < this.turnMax){
            transform.Rotate(this.turnSpeed, 0.0f, 0.0f, Space.Self);
            this.turnTracker+=this.turnSpeed;
        }
    }

    public void TurnCorrection(){
        if (this.turnTracker > 0){
            transform.Rotate(-this.turnDecay, 0.0f, 0.0f, Space.Self);
            this.turnTracker-=this.turnDecay;
            
        }
        else if(this.turnTracker < 0){
            transform.Rotate(this.turnDecay, 0.0f, 0.0f, Space.Self);
            this.turnTracker+=this.turnDecay;
        }

    }

}
