using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random; //Random = UnityEngine.Random so we can specify that when we use Random we want to use the Random from UnityEngine.Random and not Unity.Mathematics
using UnityEngine.UI;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class PlayerStats : MonoBehaviour
{

    [Header("Actual stats")]
    [SerializeField] private static int playerHP;
    [SerializeField] private bool alive = true;
    [SerializeField] private static int score = 0;
    [SerializeField] private static int SubarusCollected = 0;
    [SerializeField] private static int EnemiesDefeated = 0;
    public int playerLives = 1;

    [Header("Game win/loss text")]
    public TextMeshProUGUI WinOrLossText;
    public TextMeshProUGUI SubaruButtonText;
    public List<string> SubaruText = new List<string>(){
                                      "You did it! (Click me)",
                                      "Took you long enough. Just kidding! Good Work! (Click me)",
                                      "There you are! I was starting to think you wouldn't make it. (Click me)",
                                      "A familiar face... I'm glad you're here. (Click me)",
                                      "Did you miss me? (Click me)",
                                      "You're back! (Click me)"};
    


    [Header("Misc")]
    private Vector3 spawnPointVector3D;
    public GameObject spawnPoint;
    public GameObject gameOver;


    [Header("Audio Stuff")]
    public List<AudioClip> playerAudioClips;
    public AudioSource playerAudioSource;

    [Header("Scripts")]
    public GameObject playerMovementObject;
    public GameObject EntitySpawnerPrefab;

    [Header("Stats UI")]
    public TextMeshProUGUI Lives; 




    public void resetAllStats(){
        resetScore();
        resetEnemiesDefeated();
        resetSubarusCollected();
        resetLives();
    }

    public void returnToSpawnPoint(){
        spawnPointVector3D = spawnPoint.transform.position;                                        //get the transform of the spawn point object
        PlayerMovement playerMovementScript = playerMovementObject.GetComponent<PlayerMovement>(); //get PlayerMovement script
        float speedTemp = playerMovementScript.getSpeed();                                         //store original playerMovement speed from speed variable in PlayerMovement script
        playerMovementScript.setSpeed(0);                                                          //set the PlayerMovement speed variable to 0
        transform.position = spawnPointVector3D;                                                   //teleport the player to the transform of the spawn point object
        playerMovementScript.setSpeed(speedTemp);                                                  //set the player's speed back to normal
    }

    public void isAlive(bool T_or_F){
        alive = T_or_F;
    }


    void Start()
    {
        returnToSpawnPoint();
    }
    

    // Update is called once per frame
    void Update()
    {
        Lives.text = $"Subaru Lives: " + playerLives;
    }

    private void OnCollisionEnter2D(Collision2D collision){ //if you touch an enemy you die and trigger the Game Over Screen
        GameOverScreen GameOver = gameOver.GetComponent<GameOverScreen>();
        EntitySpawner EntitySpawner = EntitySpawnerPrefab.GetComponent<EntitySpawner>();
        if(collision.gameObject.CompareTag("Enemy") && alive){
            playerAudioSource.PlayOneShot(playerAudioClips[0]);
            playerLives--;
            if(playerLives == 0 || playerLives < 0){ //I think if i did playerLives <= 0 it'd still stop at 1 and we don't want it to stop at 1
                alive = false;
                GameOver.Setup(EnemiesDefeated, SubarusCollected, score); //Game Over screen active
                SubaruButtonText.text = "It was a valiant effort! Click on me to restart!";
            }else{
                returnToSpawnPoint();
            }
        }

        if(collision.gameObject.CompareTag("Subaru Trophy")){
            SubarusCollected++;
            score += 25;
            playerAudioSource.PlayOneShot(playerAudioClips[1]);
            Destroy(collision.gameObject);
            EntitySpawner.SetIsOnScreen(false); //if it's no longer on screen we can instantiate the prefab again with the entity spawner.
        }
        
        if(collision.gameObject.CompareTag("Apple")){
            Interactable interactable = collision.gameObject.GetComponent<Interactable>(); //get the Interactable script from the object tagged with apple
            playerLives += interactable.giveLife; //give x amount of player lives depending on the object with the interactable script and how much it offers
            Destroy(collision.gameObject); //destroy the apple
            EntitySpawner.SetIsOnScreen(false); //if it's no longer on screen we can instantiate the prefab again with the entity spawner..
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Win Point")){
            GameOverScreen GameOver = gameOver.GetComponent<GameOverScreen>();
            GameOver.Setup(EnemiesDefeated, SubarusCollected, score);
            WinOrLossText.text = "GAME WIN!";
            SubaruButtonText.text = SubaruText[Random.Range(0, SubaruText.Count)];
        }
    }






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

    public void resetLives(){
        playerLives = 1;
    }
}
