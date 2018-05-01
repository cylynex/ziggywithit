using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int direction;
    public int speed = 2;
    public Camera camera;

    private RaycastHit hit;
    private Vector3 offset;
    public bool gameOver;

    void Start() {
        offset = camera.transform.position - transform.position;
    }

    void Update() {

        if (!gameOver) {

            // Check for input
            CheckInput();

            // Move player along chosen direction
            MovePlayer();

            // Check if player fell off
            CheckFall();
        }
    }

    // Get player input
    void CheckInput() {
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            // Go along z axis
            direction = 2;
        } else if (Input.GetKeyUp(KeyCode.RightShift)) {
            // Go along x axis
            direction = 1;
        }
    }


    // Move the player along chosen direction
    void MovePlayer() {
        if (direction == 1) {
            // Z Axis movement
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } else if (direction == 2) {
            // X Axis movement
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Move the camera along with player
        GameObject thisCam = camera.gameObject;
        thisCam.transform.position = transform.position + offset;
    }


    // Check for fall
    void CheckFall() {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f)) {
            Debug.Log("something under me");
        } else {
            Debug.Log("FALL");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameOver = true;
        }

        /*
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f)) {
            print("It's a hit at: " + hit.distance + " - " + hit.transform.position);
        } else {
            print("no collision");
        }
        */
    }
}
