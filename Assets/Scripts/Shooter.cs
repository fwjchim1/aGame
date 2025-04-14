using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("Sound stuff")]
    public AudioSource shootSFXSource;
    public List<AudioClip> shootSFXClip;

    [Header("Bullet variables")]
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public int bulletDamage = 5;
    public bool onCooldown = false;
    public float cooldownDuration;

    public bool getOnCooldown(){
        return onCooldown;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && !onCooldown){ //if left click and not on cooldown
            shootSFXSource.PlayOneShot(shootSFXClip[0]);
            StartCoroutine(Shoot());                         //run the shoot coroutine
        }
        

    }

    IEnumerator Shoot(){
        Instantiate(bulletPrefab, shootingPoint); //shoot the bullet
        onCooldown = true;                        //put it on cooldown
        yield return new WaitForSeconds(cooldownDuration);   //now wait 0.15 seconds
        onCooldown = false;                       //take it off cooldown (can shoot again now)
    }



}
