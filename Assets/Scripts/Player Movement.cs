using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer player;
    [Header("Movement Variables")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [Range(0,1)] //gives us a slider that lets us choose the friction
    [SerializeField] private float GroundDrag = 0.9f;
    private float horizontal; //will be either -1(left), 0(not moving), or 1(right)
    private Rigidbody2D rb;
    public BoxCollider2D groundCheck; //will use to check if on ground
    public LayerMask GroundMask; //the ground itself we will use for detection
    public List<Sprite> animations;

    public bool grounded;
    float xInput;
    float yInput;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //tells us we want the current value of the input axis "horizontal"
        //Input.GetAxis(H/V) lets us get controls like WASD for movement
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        
        Vector2 direction = new Vector2(xInput, yInput).normalized; //normalizing makes it so that going diagonal doesn't make it go any faster than horizontally
        //rb.linearVelocity = direction * speed; //idk what to put here just test it yourself

        //if we move in x direction, change only the x direction (don't change y)
        if(Mathf.Abs(xInput) > 0){ //i think this adds a bit of "speeding up before full speed" too
            rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);
            float facing = Mathf.Sign(xInput);
            transform.localScale = new Vector3(facing, 1, 1);
        }else{
            rb.linearVelocity = new Vector2(xInput, rb.linearVelocity.y);
        }

        if(Input.GetKey(KeyCode.Space) && grounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }

    }


    private void FixedUpdate()
    {
        checkGround();
        if(grounded && xInput == 0){ //if there's any x input, no decay calculated for the frame.
           rb.linearVelocityY *= GroundDrag; 
        }
           
    }

    private void checkGround()
    {
        //checks if I'm on the ground
        //groundCheck.bounds.min is bottom left corner of collider
        //groundCheck.bounds.max is top right corner of collider. together, they form a rectangular area.
        //Physics2D.OverlapAreaAll() checks all colliders inside the defined area between min and max
        //and returns an array of colliders that overlap with the area
        //GroundMask basically checks if a collider is touching the ground
        //the .length > 0 means if there's something inside the array of colliders.
        //If there is something inside, they are likely grounded and will be marked as so.
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, GroundMask).Length > 0;
    }

}