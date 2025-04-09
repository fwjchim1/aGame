using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private static int playerHP;
    [SerializeField] private bool alive = true;
    [SerializeField] private static int score = 0;
    [SerializeField] private static int SubarusCollected = 100;
    [SerializeField] private static int EnemiesDefeated = 0;
    public Vector2 spawnPoint;
    public GameObject gameOver;
    private Rigidbody2D rb; //do we even neend this?

    public int getScore(){
        return score;
    }
    public void resetScore(){
        score = 0;
    }
    public void addScore(int scoreAmount){
        score += scoreAmount;
    }

    public int getSubarusCollected(){
        return SubarusCollected;
    }
    public void resetSubarusCollected(){
        SubarusCollected = 0;
    }

    public void addSubarusCollected(int subarus){
        SubarusCollected += subarus;
    }

    public int getEnemiesDefeated(){
        return EnemiesDefeated;
    }
    public void resetEnemiesDefeated(){
        EnemiesDefeated = 0;
    }

    public void addEnemiesDefeated(){
        EnemiesDefeated += 1;
    }

    public void returnToSpawnPoint(){
        spawnPoint = new Vector2(0,3);
        transform.position = spawnPoint;
    }

    public void isAlive(bool T_or_F){
        alive = T_or_F;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision){ //if you touch an enemy you die and trigger the Game Over Screen
        if(collision.gameObject.CompareTag("Enemy") && alive){
            alive = false;
            GameOverScreen GameOver = gameOver.GetComponent<GameOverScreen>();
            GameOver.Setup(EnemiesDefeated, SubarusCollected, score);
        }
    }





}
