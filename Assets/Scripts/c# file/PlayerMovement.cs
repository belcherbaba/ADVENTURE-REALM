
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField]
    private float moveSpeed = 7f;
    [SerializeField]
    private float jumpForce = 14f;
    private enum MovementState{idle,running,jumping,falling}
    [SerializeField]
    private LayerMask jumpableGround;
    [SerializeField]
    private AudioSource jumpSoundEffect;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;



    
    
     
    private void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;

        
        
    }
     
    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed,rb.velocity.y);

        jump();
        
        
       
        
        Animation();
        
    }

   private void Animation()
   {

     MovementState state;
     if (dirX>0f)
     {
        state = MovementState.running;
        sprite.flipX = false;
     }
     else if (dirX<0f)
     {
        state = MovementState.running;
        sprite.flipX = true;
     }
     else
     {
        state = MovementState.idle;
     }

     if (rb.velocity.y>0.1f  )
     {
        state = MovementState.jumping;
     }
     else if (rb.velocity.y<-.1f)
     {
        state = MovementState.falling;
     }
     anim.SetInteger("state",(int)state);

  }

  private bool IsGrounded()
  {
     return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);

  }

  public void jump()
  {
    if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
           rb.velocity = new Vector2(rb.velocity.x,jumpForce);
           jumpSoundEffect.Play();
        }

  }

 

 }

    
    
    
   

