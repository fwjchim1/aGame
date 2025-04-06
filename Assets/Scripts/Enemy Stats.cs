using System.Security.Cryptography;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int hp = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            Destroy(gameObject);
        }
    }


    //what the heck do we do here
    //purpose is to make the enemy lose HP and eventually be destroyed in update 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Detected Collision");
        if(collision.gameObject.CompareTag("Bullet")){
            boolet bulletDmg = collision.gameObject.GetComponent<boolet>();
            hp -= bulletDmg.getBulletDamage();
            Debug.Log("Damage applied: " + bulletDmg.bulletDamage);
            Destroy(collision.gameObject);
        }

    }



}
