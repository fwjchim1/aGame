using System.Collections.Generic;
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
    

    public void Start()
    {
        HideGameOver();
    }


    public void Setup(int enemiesDefeated, int subarusCollected, int score){
        gameObject.SetActive(true); //turns on whenever Setup() is called
        this.SubarusCollected.text = $"Subarus Collected " + subarusCollected; //adds current subarus collected to game over screen
        this.EnemiesDefeated.text = $"Enemies Defeated: " + enemiesDefeated; //adds current enemies defeated to game over screen
        this.Score.text = $"Score: " + score; //adds current score to game over screen
        Time.timeScale = 0f; //pause the game
    }

    public void HideGameOver(){
        Time.timeScale = 1f; //unpause game
        
        
        GameObject[] arrayOfAllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        //FindGameObjectsWithTag() returns an array of all instances of game objects with the tag in the parentheses
        //basically gives us a list of all the enemies
        foreach(GameObject go in arrayOfAllEnemies){ //goes through every enemy and destroys them
            Destroy(go);
        }


        EnemySpawner spawnEnemies = enemies.GetComponent<EnemySpawner>();
        spawnEnemies.SpawnEnemies();


        PlayerStats playerStats = playerObject.GetComponent<PlayerStats>(); //getting the PlayerStats script from the player that's assigned to the playerObject variable
        //DO NOT USE GetComponent<>() ALONE IF THE SCRIPT YOU'RE TRYING TO ACCESS ISN'T ALREADY IN THE MAIN GAMEEOBJECT!
        gameObject.SetActive(false); //hide game over screen
        playerStats.resetScore(); //reset total score
        //playerStats.setSubarusCollected(100); (KEEP IT AT 100 FOR NOW BUT LATER WE WILL HAVE TO CREATE A RESET METHOD IN THE PLAYER STATS)
        playerStats.resetEnemiesDefeated(); //resets enemy defeated score
        playerStats.returnToSpawnPoint(); //tp the person back to the spawn point
        
    }


}
