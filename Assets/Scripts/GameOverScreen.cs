using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public TextMeshProUGUI SubarusCollected;
    public TextMeshProUGUI EnemiesDefeated;
    public TextMeshProUGUI Score;

    public Button restartButton;
    public Transform playerLocation;

    public void Start()
    {
        HideGameOver();
    }


    public void Setup(int enemiesDefeated, int subarusCollected, int score){
        gameObject.SetActive(true); //turns on whenever Setup() is called
        this.SubarusCollected.text = $"Subarus Collected " + subarusCollected;
        this.EnemiesDefeated.text = $"Enemies Defeated: " + enemiesDefeated;
        this.Score.text = $"Score: " + score;
        Time.timeScale = 0f;
    }

    public void HideGameOver(){
        PlayerStats playerStats = GetComponent<PlayerStats>();
        gameObject.SetActive(false);
        playerStats.resetScore();
        //playerStats.setSubarusCollected(100); (KEEP IT AT 100 FOR NOW BUT LATER WE WILL HAVE TO CREATE A RESET METHOD IN THE PLAYER STATS)
        playerStats.resetEnemiesDefeated();
        playerLocation.transform.position = new Vector2(0, -3);
        Time.timeScale = 1f;
    }


}
