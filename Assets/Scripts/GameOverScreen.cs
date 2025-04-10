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

    public Button restartButton; //it's in the button component of the button UI in the hierarchy (we get to choose which method it runs. in this case, HideGameOver)
    public GameObject playerObject; //will assign the player into this gameObject so we can get the playerStats script and its values inside it
    public GameObject enemies;
    public GameObject[] arrayOfAllEnemies;
    public GameObject[] arrayOfAllEnemySpawners;


    public void Awake()
    {
        arrayOfAllEnemySpawners = GameObject.FindGameObjectsWithTag("Enemy Spawner");
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
        Debug.Log(arrayOfAllEnemies);
        Time.timeScale = 0f; //pause the game
    }


    //hide game over screen
    public void HideGameOver(){
        gameObject.SetActive(false);
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

        //respawn the enemies
        //finds each game object tagged with "Enemy Spawner"
        //the game objects with "Enemy Spawner" will spawn on only one enemy spawner if we don't iterate through them all
        foreach(GameObject go in arrayOfAllEnemySpawners){
            EnemySpawner respawnEnemies = go.GetComponent<EnemySpawner>();
            respawnEnemies.SpawnEnemies();
            Debug.Log("Spawned an enemy");
        }


        PlayerStats playerStats = playerObject.GetComponent<PlayerStats>(); //getting the PlayerStats script from the player that's assigned to the playerObject variable
        //DO NOT USE GetComponent<>() ALONE IF THE SCRIPT YOU'RE TRYING TO ACCESS ISN'T ALREADY IN THE MAIN GAMEEOBJECT!
        playerStats.resetScore(); //reset total score
        //playerStats.setSubarusCollected(100); (KEEP IT AT 100 FOR NOW BUT LATER WE WILL HAVE TO CREATE A RESET METHOD IN THE PLAYER STATS)
        playerStats.resetEnemiesDefeated(); //resets enemy defeated score
        playerStats.returnToSpawnPoint(); //tp the person back to the spawn point
        playerStats.isAlive(true);

        Time.timeScale = 1f; //unpause game

    }


    //spawn the enemy from the Enemy Spawner script
    public void SpawnTheEnemy(){
        EnemySpawner spawnEnemies = enemies.GetComponent<EnemySpawner>();
        spawnEnemies.SpawnEnemies();
    }


}
