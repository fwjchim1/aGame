using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;

    public void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies(){
        Instantiate(enemy, transform.position, Quaternion.identity);
        Debug.Log("Spawned an enemy");
    }
}
