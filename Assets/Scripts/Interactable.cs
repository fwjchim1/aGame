using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Collider2D playerCollider;
    public GameObject apple;
    public bool inInteractableArea = false;

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
            Instantiate(apple, new Vector3 (transform.position.x, transform.position.y,0), Quaternion.identity);
            Debug.Log("Instantiated an apple");
    }


}
