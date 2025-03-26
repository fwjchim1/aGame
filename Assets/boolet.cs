using UnityEngine;

public class boolet : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed; //speed of bullet on X axis (right as horiznotal. This will make a straight line)
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
