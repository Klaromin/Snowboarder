using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] float reloadTime = 0.4f;
    [SerializeField] AudioClip crashSfx;
    CircleCollider2D playerHead;  //We created a variable for our player's head.(The specific circle collider2d that we already created.)
    bool isCrushed = false;

    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>(); // Here we used get component to reach ther certain collider that i mentioned up.
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>(); //Here ve created another collider that we can detect the playerhead touch another object.

        if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(otherCollider))//
        {
            FindObjectOfType<PlayerControl>().DisableControls();
           
            if (!isCrushed)
            {
                isCrushed = true;
                GetComponent<AudioSource>().PlayOneShot(crashSfx);
                hitEffect.Play();
                
            }

            Invoke("ReloadScene", reloadTime);
        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerControl.canRotate = true;
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


}
