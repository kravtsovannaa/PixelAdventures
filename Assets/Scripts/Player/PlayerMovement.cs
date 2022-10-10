using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private AudioSource jumpSoundEffect;

    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private float direction;

    private enum MovementState { idle, running, jumping, falling }


    //= Awake is called when the script is first loaded, or when an object it is attached to is instantiated.
    private void Awake()
    {
        //? Debug.Log("HelloWorld"); //used to print messages in console
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        direction = 0f;
        //add method for player spawn
    }

    //= Called once per frame
    void Update()
    {
        //? Movement logic
        direction = Input.GetAxisRaw("Horizontal"); //value (1 to -1) //try GetAxis for slight slide
        player.velocity = new Vector2(movementSpeed * direction, player.velocity.y);

        //? Jump logic (tweak at rigidbody: mass, gravity)
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;

        //running/idle animation
        if(direction > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(direction < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        //jumping/falling animation
        if(player.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private void SpawnAnimation()
    {
        //play spawning animation & sound
    }
}
