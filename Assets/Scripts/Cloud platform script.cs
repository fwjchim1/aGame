using System.Collections.Generic;
using UnityEngine;

public class Cloudplatformscript : MonoBehaviour
{

    public List<Sprite> cloudPlatforms;
    public SpriteRenderer cloudPlatform;
    public bool isHappy = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cloudPlatformAnimations(){

    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isHappy){
            isHappy = false;
            cloudPlatform.sprite = cloudPlatforms[1];
        }
    }

    //Sent when another object leaves a trigger collider attached to this object (2D physics only).
    public void OnCollisionExit2D(Collision2D collision)
    {
        isHappy = true;
        cloudPlatform.sprite = cloudPlatforms[0];
    }


}
