using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    private Transform currentPoint; //the point in which we are moving toward (not the enemy's location)




    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerRB = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 point = currentPoint.position - transform.position; //no use yet
        if(currentPoint == pointB.transform){
            playerRB.linearVelocity = new Vector2(speed, playerRB.linearVelocityY); //make enemy go right if their current point is pointB.transformation
        }else{
            playerRB.linearVelocity = new Vector2(-speed, playerRB.linearVelocityY); //make enemy go left if their current point is pointA.transformation
        }

        //if(Vector2.Distance(transform.position, currentPoint.position) < 0.2f && currentPoint == pointB.transform){
        //    currentPoint = pointA.transform; //when the distance between the enemy and the boundnary is less than 0.2, change currentPoint to pointA
        //}
        //if(Vector2.Distance(transform.position, currentPoint.position) < 0.2f && currentPoint == pointA.transform){
        //    currentPoint = pointB.transform; //when the distance between the enemy and the boundnary is less than 0.2, change currentPoint to pointB
        //}






    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy Movement Boundary B")){
            //Debug.Log("Running trigger event");
            if(currentPoint == pointB.transform){
                //Debug.Log("Turned currentPoint to pointA");    
                currentPoint = pointA.transform; //when the distance between the enemy and the boundnary is less than 0.2, change currentPoint to pointA
            }
        }
        
        if(collision.gameObject.CompareTag("Enemy Movement Boundary A")){
            if(currentPoint == pointA.transform){
                //Debug.Log("Turned currentPoint to pointB");
                currentPoint = pointB.transform; //when the distance between the enemy and the boundnary is less than 0.2, change currentPoint to pointB
            }
        
        }
    }



}
