using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;
    [SerializeField] AudioClip snowboardSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            PlayerControl.canRotate = false;
            snowEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(snowboardSfx);
        }
    
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerControl.canRotate = true;
            GetComponent<AudioSource>().Stop();
            snowEffect.Stop();
        }
          
    }
}
