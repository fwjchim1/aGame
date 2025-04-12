using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAudios : MonoBehaviour
{

    public AudioSource source; //where the audo is going to be played from
    public List<AudioClip> clip; //the audioclip itself
    public GameObject p;
    void Start()
    {
        PlayerMovement player = p.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement player = p.GetComponent<PlayerMovement>();
        if(player.IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            source.PlayOneShot(clip[0]);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            source.PlayOneShot(clip[1]);
        }    
    }
}
