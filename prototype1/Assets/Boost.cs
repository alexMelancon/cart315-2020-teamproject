﻿/*****************

How to shoot bullets
by Bracer Jack on YouTube

https://www.youtube.com/watch?v=FD9HZB0Jn1w

******************/


// *** Important to know: in the comments of the code, the word ''bullet'' is meant to represent the sphere that is emitted bu the player. In the scenario of my third prototype, the bullets where the smoke balls. 
// In short, a bullet = a projected sphere.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    // Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    // Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    // Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // If right mouse click is pushed
        if (Input.GetMouseButton(1))
        {
            // The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            // Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            // Retrieve the Rigidbody component from the instantiated Bullet and control it. 
            // Important that the things you want to fire upon with the bullets to possess a RigidBody also.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            // Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

            // Basic Clean Up, set the Bullets to self destruct after 1.5 Seconds. Can be bigger number if used as a projectile and not a boost.
            Destroy(Temporary_Bullet_Handler, 1.5f);
        }
    }
}