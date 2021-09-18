using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject[] zombies;
    public bool isRising = false;
    public bool isFalling = false;

    private int activeZombieIndex = 0;
    private Vector2 startPosition;

    public int riseSpeed = 1;

    private int zombiesSmashed;

    private int livesRemaining;

    private bool gameOver;

    // Start is called before the first frame update
    void Start () {
        gameOver = false;
        zombiesSmashed = 0;
        livesRemaining = 2;
        pickNewZombie ();
    }
    // Update is called once per frame
    void Update () {
         
         if (!gameOver)
         {
             if (isRising) {

            if (zombies[activeZombieIndex].transform.position.y - startPosition.y >= 2f) {
                //Then we need to start bringing it down
                isRising = false;
                isFalling = true;
            } else {
                zombies[activeZombieIndex].transform.Translate (Vector2.up * Time.deltaTime * riseSpeed);
            }

        } else if (isFalling) {
            //all the logic while the zombie is going down goes in here.
            if (zombies[activeZombieIndex].transform.position.y - startPosition.y <= 0f)

            {
                //stop making it fall
                isFalling = false;
                isRising = false;
                livesRemaining--;
                if (livesRemaining == 0) {
                    Debug.Log ("It`s time for game over");
                    gameOver = true;
                }
            } else {
                zombies[activeZombieIndex].transform.Translate (Vector2.down * Time.deltaTime * riseSpeed);
            }

        } else {
            //anything else in happen in here.
            zombies[activeZombieIndex].transform.position = startPosition;
            pickNewZombie ();
        }


         }
      

    }
    private void pickNewZombie () {
        isRising = true;
        isFalling = false;
        activeZombieIndex = UnityEngine.Random.Range (0, zombies.Length); //This is going to generate a number between zero and six.
        startPosition = zombies[activeZombieIndex].transform.position;

    }

    public void KillEnemy () {
        zombiesSmashed++;
        //write the code for killing enemy
        zombies[activeZombieIndex].transform.position = startPosition;
        pickNewZombie ();

        Debug.Log ("zombiesSmashed. ");

    }
}