using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Collider2D playerCollider;
    public GameObject Item;
    public bool inInteractableArea = false;
    public float objectSpawnDisplacement;
    public int giveLife; //choose how much life you want to give
    public int interactCounter = 0;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inInteractableArea){
            if(Input.GetKeyDown(KeyCode.E)){
                Interact();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            inInteractableArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        inInteractableArea = false;        
    }

    public void Interact(){
        if(interactCounter < 1){
            Instantiate(Item, new Vector3 (transform.position.x + objectSpawnDisplacement, transform.position.y), Quaternion.identity);
            Debug.Log("Instantiated an apple");
            interactCounter++;
        }else{
            Debug.Log("Subaru couldn't find anything else in the tree.");
        }
    }


}
