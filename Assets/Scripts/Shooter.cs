using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public int bulletDamage = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Instantiate(bulletPrefab, shootingPoint);
            
        }
    }
}
