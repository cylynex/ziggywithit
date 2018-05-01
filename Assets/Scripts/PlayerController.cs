using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int direction;


    void Update() {

        // Check for input
        CheckInput();

        // Move player along chosen direction
        MovePlayer();
    }

    // Get player input
    void CheckInput() {
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            Debug.Log("go along z axis");
        } else if (Input.GetKeyUp(KeyCode.RightShift)) {
            Debug.Log("go along x axis");
        }
    }


    // Move the player along chosen direction
    void MovePlayer() {
        Debug.Log("move player");
    }
}
