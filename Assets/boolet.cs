using UnityEngine;

public class boolet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    [SerializeField] private int isRight = 0; //-1 is facing left, 0 is facing straight, 1 is facing right

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if(Input.GetKey(KeyCode.A)){ //shooting left when holding A (notice the transform.right*-1)
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.right*-1 * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
            transform.parent = null;
        }else if(Input.GetKey(KeyCode.D)){ //shooting right when holding D
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.right * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
            transform.parent = null;
        }else{ //shooting upward by default
            rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = transform.up * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
            transform.parent = null;
        }

        
        //((((KEEPING THIS HERE SO I CAN LATER IMPLEMENT AIM VIA MOUSE PLACEMENT))))
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert screen mouse position to game mouse position
        //rb.linearVelocity = mousePosition * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
        //transform.parent gets the parent of the object
        //transform.parent = null; //using transform.parent and setting it to null, we make the bullet belong to no parent (originally belonged to player which was the original parent)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
