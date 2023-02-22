using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int playerHealth = 3;
    public float playerSpeed = 6.5f;
    public float jumpForce = 8f;
    string texto = "Hello World";
    public SpriteRenderer spriteRenderer;
    private Rigidbody2D rBody;
    private GroundSensor sensor; 
    float horizontal;
    public Animator anim;
    public Coin coin;
    public Flag flag;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        sensor= GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        coin = GameObject.Find("Coin").GetComponent<Coin>();

        playerHealth = 10;
        Debug.Log(texto);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //transform.position += new Vector3(horizontal, 0) * playerSpeed * Time.deltaTime; 

        if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if(horizontal > 0)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);

        }

        if(Input.GetButtonDown("Jump") && sensor.isGrounded)
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate() 
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CollisionCoin")
        {
            Coin coin = collision.gameObject.GetComponent<Coin>(); 
            coin.Pick();
        
        }

         if (collision.gameObject.tag == "FlagRaising")
        {
            Flag flag = collision.gameObject.GetComponent<Flag>(); 
            flag.Pick();
        
        }
    
    }

    
}
