using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadTime = 0.2f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip finishSound;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(finishSound);
            Invoke("ReloadScene", reloadTime);
            FindObjectOfType<PlayerControl>().DisableControls();
           
        }
       
    }

    
    
    void ReloadScene()
    {   
        SceneManager.LoadScene(0);
    }


    
}
