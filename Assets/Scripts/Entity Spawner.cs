using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EntitySpawner : MonoBehaviour
{
    
    public GameObject entity;
    public bool isOnScreen = false;

    public void SetIsOnScreen(bool TorF){
        isOnScreen = TorF;
    }

    public void Start()
    {
        SpawnEntities();
    }

    public void SpawnEntities(){
          
            Instantiate(entity, transform.position, Quaternion.identity);
            Debug.Log("Spawned a " + entity.tag);
    }
}
