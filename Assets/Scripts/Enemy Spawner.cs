using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;

    public void Start()
    {
        
    }

    public void SpawnEnemies(){
        Instantiate(enemy);
        Debug.Log("Spawned an enemy");
    }
}
