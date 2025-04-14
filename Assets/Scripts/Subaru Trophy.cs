using System.Collections.Generic;
using System.Linq;
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

    [Header("How many trophies")]
    public GameObject[] TrophiesLeft = GameObject.FindGameObjectsWithTag("Subaru Trophy"); //give an array of all subaru trophies
    public static int SubaruTrophyCount; //how many trophies are there


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
        SubaruTrophyCount = TrophiesLeft.Count(); //get # of subaru trophies
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
