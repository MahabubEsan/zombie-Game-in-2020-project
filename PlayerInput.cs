using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        //Constantly for input here
        if (Input.GetMouseButtonDown (0)) {
            //we will raycast here
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition); // we have reted our way
            RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

            //Check if raycast hit something.        
            if (hit.collider != null) {
                //If it hit something, tell me if it hit an enemy.
                if (hit.collider.tag == "Enemy") 
                {
                    //this is where we kill enemy.
                    gameObject.GetComponent<GameManager> ().KillEnemy ();
                }
            }
        }

    }
}