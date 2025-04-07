using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;

    public void Start()
    {
        Instantiate(enemy);
    }

    public void SpawnEnemies(){
        Instantiate(enemy);
    }
}
