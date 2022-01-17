using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{   
    [Header("Speed variables")]
    [Tooltip("Variables to represent this car's speed properties (speed, maxSpeed, turnSpeed, acceleration")]
    public float speed = 0.0f;
    public float maxSpeed = 422.8f;
    public float turnSpeed = 2.0f;
    public float acceleration = 0.8f;

    [Header("Wheel")]
    [Tooltip("This car's wheel")]
    public GameObject wheel;

    [Header("Audio")]
    [Tooltip("The sounds this car has access to")]
    public AudioSource fastSound;
    public AudioSource slowSound;
    public AudioSource idleSound;
    public AudioSource currentSound = null;
    

    // Update is called once per frame
    void Update()
    {
        // Idle check
        if (this.speed < 5.0f){
            SoundPlayer(idleSound);
        }

        // Conditionals to handle controls
        if (Input.GetKey("w")){
            this.speed += acceleration;
            if (this.speed > 150.0f){
                SoundPlayer(fastSound);               
            }
            else{
                SoundPlayer(slowSound);
            }
            // Passive wheen turn correction
            wheel.GetComponent<WheelHandler>().TurnCorrection();
            
        }
        if (Input.GetKey("a")){
            transform.Rotate(0.0f, 0.0f, -this.turnSpeed* Time.deltaTime, Space.Self);
            this.speed -= acceleration/3;
            wheel.GetComponent<WheelHandler>().TurnLeft();
        }
        if (Input.GetKey("d")){
            transform.Rotate(0.0f, 0.0f, this.turnSpeed* Time.deltaTime, Space.Self);
            this.speed -= acceleration/3;
            wheel.GetComponent<WheelHandler>().TurnRight();
        }
         if (Input.GetKey("s")){
            this.speed -= acceleration;           
        }
        
        // Speed decay
        if(speed > 0 && speed < maxSpeed){
            transform.Translate(new Vector3(-1.0f, 0, 0) * speed * Time.deltaTime);
            this.speed -= acceleration/3;
        }
    }

    // Trigger function for each sound
    private void SoundPlayer(AudioSource sound){
        if (sound != this.currentSound){
            sound.PlayDelayed(0);
            this.currentSound.Stop();
            this.currentSound = sound;
        }
    }
    





    




}
