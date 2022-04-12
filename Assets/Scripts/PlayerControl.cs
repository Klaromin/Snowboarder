using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb2d;
    Transform x;
    
    [SerializeField, Tooltip("Torque of our player's")] float Torque = 0.3f;
    [SerializeField] float baseSpeed = 13f;
    [SerializeField] float boostSpeed = 18f;
    [SerializeField] float brakeSpeed = 8f;
    [SerializeField] SurfaceEffector2D surfaceEffector2D;
    public bool canMove = true;
    public static bool canRotate = false;
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        x = GetComponent<Transform>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            
            RotatePlayer();
            RespondToBoost();
        }


    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = brakeSpeed;
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (canRotate)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.AddTorque(Torque);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb2d.AddTorque(-Torque);
            }
        }
  

    }

}
