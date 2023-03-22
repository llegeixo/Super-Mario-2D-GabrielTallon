using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
   private PlayerController controller;
   public bool isGrounded;

   SFXManager sfxManager;
   SoundManager soundManager;
   MenuManager menuManager;
   GameManager gameManager;
   
   void Awake()
   {
      controller = GetComponentInParent<PlayerController>();
      sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
      soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
      menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   
   }
   void OnTriggerEnter2D(Collider2D other) 
   {
        if(other.gameObject.layer == 3)
        {
          isGrounded = true;
          controller.anim.SetBool("IsJumping", false);
        }
        else if (other.gameObject.layer == 6)
        {
            Debug.Log("Goomba muerto");

            sfxManager.GoombaDeath();

            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
        }

        if(other.gameObject.tag == "DeadZone")
        {
               Debug.Log("Estoy muerto");

               soundManager.StopBGM();
               sfxManager.MarioDeath();
               //SceneManager.LoadScene(2); 
               gameManager.GameOver();
        }
        
   }

     void OnTriggerStay2D(Collider2D other) 
   {
        if(other.gameObject.layer == 3)
        {
          isGrounded = true;
          controller.anim.SetBool("IsJumping", false);
        }
        
   }

    void OnTriggerExit2D(Collider2D other) 
   {
        if(other.gameObject.layer == 3)
        {
          isGrounded = false;
           controller.anim.SetBool("IsJumping", true);
        }
        
   }
}
