using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI SubarusCollected;
    public TextMeshProUGUI EnemiesDefeated;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI WinOrLossDecision;

    public Button restartButton; //it's in the button component of the button UI in the hierarchy (we get to choose which method it runs. in this case, HideGameOver)
    public GameObject playerObject; //will assign the player into this gameObject so we can get the playerStats script and its values inside it
    public GameObject enemies;
    public GameObject[] arrayOfAllEnemies;
    public GameObject[] arrayOfAllSubaruTrophies;
    public GameObject[] arrayOfAllEntitySpawners;


    public void Awake()
    {
        //FindGameObjectsWithTag returns an array of all the objects with the tag
        arrayOfAllEntitySpawners = GameObject.FindGameObjectsWithTag("Enemy Spawner");
    }


    public void Start()
    {
        HideGameOver();

    }

    //Activate the game over screen
    public void Setup(int enemiesDefeated, int subarusCollected, int score){
        gameObject.SetActive(true); //turns on whenever Setup() is called
        this.SubarusCollected.text = $"Subarus Collected " + subarusCollected; //adds current subarus collected to game over screen
        this.EnemiesDefeated.text = $"Enemies Defeated: " + enemiesDefeated; //adds current enemies defeated to game over screen
        this.Score.text = $"Score: " + score; //adds current score to game over screen
        arrayOfAllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        arrayOfAllSubaruTrophies = GameObject.FindGameObjectsWithTag("Subaru Trophy");
        Debug.Log(arrayOfAllEnemies);
        Time.timeScale = 0f; //pause the game
    }


    //hide game over screen
    public void HideGameOver(){
        gameObject.SetActive(false); //get rid of game over screen
    }

    //Remove all enemies, reset stats, and unfreeze game
    public void RestartGame(){
        HideGameOver();
        
        

        //FindGameObjectsWithTag() returns an array of all instances of game objects with the tag in the parentheses
        //basically gives us a list of all the enemies
        foreach(GameObject go in arrayOfAllEnemies){ //goes through every enemy and destroys them
            Destroy(go);
            Debug.Log("Destroyed an enemy");
        }

        foreach(GameObject go in arrayOfAllSubaruTrophies){ //goes through every enemy and destroys them
            Destroy(go);
            Debug.Log("Destroyed an enemy");
        }

        //respawn the entities
        //finds each game object tagged with "Enemy Spawner"
        //the game objects with "Enemy Spawner" will spawn on only one enemy spawner if we don't iterate through them all
        foreach(GameObject go in arrayOfAllEntitySpawners){
            EntitySpawner respawnEntities = go.GetComponent<EntitySpawner>();
            respawnEntities.SpawnEntities();
            Debug.Log("Spawned an enemy");
        }


        PlayerStats playerStats = playerObject.GetComponent<PlayerStats>(); //getting the PlayerStats script from the player that's assigned to the playerObject variable
        //DO NOT USE GetComponent<>() ALONE IF THE SCRIPT YOU'RE TRYING TO ACCESS ISN'T ALREADY IN THE MAIN GAMEEOBJECT!
        playerStats.resetAllStats();
        playerStats.returnToSpawnPoint(); //tp the person back to the spawn point
        playerStats.isAlive(true);

        Time.timeScale = 1f; //unpause game

    }


    //spawn the enemy from the Enemy Spawner script
    public void SpawnTheEnemy(){
        EntitySpawner spawnEnemies = enemies.GetComponent<EntitySpawner>();
        spawnEnemies.SpawnEntities();
    }


}
