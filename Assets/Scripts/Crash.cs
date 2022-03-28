using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    CircleCollider2D playerHead;  //We created a variable for our player's head.(The specific circle collider2d that we already created.)

    void Start()
    {
        
        playerHead = GetComponent<CircleCollider2D>(); // Here we used get component to reach ther certain collider that i mentioned up.
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>(); //Here ve created another collider that we can detect the playerhead touch another object.
        if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(otherCollider))//
        {
           Debug.Log("BUMP!!!");
        }
        
    }
}
