using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAudios : MonoBehaviour
{

    public AudioSource source; //where the audo is going to be played from
    public List<AudioClip> clip; //the audioclip itself
    public GameObject p;
    public GameObject shooterScript;
    public Shooter shooter;


    void Start()
    {
        shooter = shooterScript.GetComponent<Shooter>();   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement player = p.GetComponent<PlayerMovement>();
        if(player.IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            source.PlayOneShot(clip[0]);
        }


        //this is not working
        //it's supposed to play the bullet shooting sound effect whenever you left click and not on cooldown
        //but it never plays no matter what
        //4/13/2025
        //if(Input.GetKeyDown(KeyCode.Mouse0) && shooter.getOnCooldown()){
        //    Debug.Log("Playing shooting sound");
        //    source.PlayOneShot(clip[1]);
        //}    
    }





}
