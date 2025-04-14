using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class SubaruTrophy : MonoBehaviour
{

    public Rigidbody2D rb;
    private Vector3 direction;
    public float speed;
    public GameObject pointA;
    public GameObject pointB;
    public Transform currentPoint;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoint == pointA.transform){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -speed);
            Debug.Log("Going down");
        }

        if(currentPoint == pointB.transform){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
            Debug.Log("Going up");
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Subaru Trophy Point A")){
            currentPoint = pointA.transform;
            Debug.Log("Current point = B");
        }

        if(collision.gameObject.CompareTag("Subaru Trophy Point B")){
            currentPoint = pointB.transform;
            Debug.Log("Current point = A");
        }

    }


}
