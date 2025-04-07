using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI SubarusCollected;
    public TextMeshProUGUI EnemiesDefeated;
    public TextMeshProUGUI Score;

    public Button restartButton;
    public GameObject playerObject; //will assign the player into this gameObject so we can get the playerStats script and its values inside it

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
        PlayerStats playerStats = playerObject.GetComponent<PlayerStats>(); //getting the PlayerStats script from the player that's assigned to the playerObject variable
        //DO NOT USE GetComponent<>() ALONE IF THE SCRIPT YOU'RE TRYING TO ACCESS ISN'T ALREADY IN THE MAIN GAMEEOBJECT!
        gameObject.SetActive(false);
        playerStats.resetScore();
        //playerStats.setSubarusCollected(100); (KEEP IT AT 100 FOR NOW BUT LATER WE WILL HAVE TO CREATE A RESET METHOD IN THE PLAYER STATS)
        playerStats.resetEnemiesDefeated();
        playerStats.returnToSpawnPoint(); //tp the person back to the spawn point
        
    }


}
