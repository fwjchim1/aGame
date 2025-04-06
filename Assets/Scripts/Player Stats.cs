using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private int playerHP;
    [SerializeField] private bool alive = true;
    [SerializeField] private int score;
    [SerializeField] private int SubarusCollected = 100;
    [SerializeField] private int EnemiesDefeated = 0;
    public GameOverScreen gameOver;
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

    public void addSubarusCollected(int SubarusCollected){
        this.SubarusCollected += SubarusCollected;
    }

    public int getEnemiesDefeated(){
        return EnemiesDefeated;
    }
    public void resetEnemiesDefeated(){
        EnemiesDefeated = 0;
    }

    public void addEnemiesDefeated(){
        EnemiesDefeated++;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!alive){
            GameOverScreen gameOver = GetComponent<GameOverScreen>();
            gameOver.HideGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            alive = false;
            gameOver.Setup(EnemiesDefeated, SubarusCollected, score);
        }
    }

}
