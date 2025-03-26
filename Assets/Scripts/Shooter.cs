using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Instantiate(bulletPrefab, shootingPoint);
            
        }
    }
}
