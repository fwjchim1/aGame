using UnityEngine;

public class boolet : MonoBehaviour
{

    public int bulletDamage = 5;
    private Rigidbody2D rb;
    public float speed;
    [SerializeField] private int isRight = 0; //-1 is facing left, 0 is facing straight, 1 is facing right

    public int getBulletDamage(){
        return bulletDamage;
    }

    void Start()
    {
        
        // if(Input.GetKey(KeyCode.A)){ //shooting left when holding A (notice the transform.right*-1)
        //     rb = GetComponent<Rigidbody2D>();
        //     rb.linearVelocity = transform.right*-1 * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
        //     transform.parent = null;
        // }else if(Input.GetKey(KeyCode.D)){ //shooting right when holding D
        //     rb = GetComponent<Rigidbody2D>();
        //     rb.linearVelocity = transform.right * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
        //     transform.parent = null;
        // }else{ //shooting upward by default
        //     rb = GetComponent<Rigidbody2D>();
        //     rb.linearVelocity = transform.up * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
        //     transform.parent = null;
        // }

        
        //((((KEEPING THIS HERE SO I CAN LATER IMPLEMENT AIM VIA MOUSE PLACEMENT))))
        rb = GetComponent<Rigidbody2D>();

        // Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is correct

        // Calculate direction from bullet to mouse
        Vector2 direction = (mousePosition - transform.position).normalized; //use normalize to scale down length to 1. Use normalized to bring range to 1 (so the speed isn't influenced by the player's position)

        // Apply velocity in the direction of the mouse
        rb.linearVelocity = direction * speed;

        // Detach bullet from any parent so it moves freely
        transform.parent = null;
        transform.localScale = new Vector3(0.5081f, 0.5081f, 0.5081f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //if it collides with anything containing a collider, destroy the bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Barrier")){ //destroy when in contect with barrier
            Destroy(gameObject);
        }

        //Destroy(gameObject);
    }


    //when no longer within the camera, destroy the bullet
    //If we make a large rectangle with nothing inside it and surround it around the camera, we could make it so that whenever the bullets hit it, it gets destroyed
    //there would be issues though like how you would detect it. Circle cast (raycast but circle) around the bullet might work in order to detect the large rectangle.
    //make sure to create layers for bulletDestruction layer or something like that and set the rectangle to it
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }


}
