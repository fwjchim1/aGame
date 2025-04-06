using System.Security.Cryptography;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int hp = 10;
    public int scoreAmount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            PlayerStats playerStats = GetComponent<PlayerStats>();
            Destroy(gameObject);
            playerStats.addScore(scoreAmount); //adds however much scored into score stat in player script
            playerStats.addEnemiesDefeated(); //adds +1 to enemies defeated in player script
        }
    }


    //what the heck do we do here
    //purpose is to make the enemy lose HP and eventually be destroyed in update 
    private void OnCollisionEnter2D(Collision2D collision) //Collision2D collision gets the collider of what the main gameObject collided with
    {
        Debug.Log("Detected Collision");
        if(collision.gameObject.CompareTag("Bullet")){ //runs if enemy collides with an object tagged "enemy"
            boolet bulletDmg = collision.gameObject.GetComponent<boolet>(); //getting variables and functions from the boolet script (it has bullet damage info)
            hp -= bulletDmg.getBulletDamage(); //decrease hp by how much damage the bullets do
            Debug.Log("Damage applied: " + bulletDmg.bulletDamage); //check if the if-statement ran
            Destroy(collision.gameObject); //destroy the boolet prefab once it collides
        }

    }



}
