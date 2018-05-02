using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreate : MonoBehaviour {

    public GameObject roadCubePrefab;
    public float createRoadSpeed = 0.5f;

    // Camera moved to player controller
    // public Camera camera;
    // private Vector3 offset;

    private bool gameStarted = false;

    Vector3 startPosition = new Vector3(0, 0, 0);
    Vector3 currentPosition = new Vector3(0, 0, 0);
    Vector3 lastPosition = new Vector3(0, 0, 0); 

    void Start() {
        
        currentPosition = startPosition;
        // Camera moved to player controller
        // offset = camera.transform.position - startPosition;
    }

    void Update() {
        if (gameStarted == false) {
            if (Input.GetKeyUp("g")) {
                InvokeRepeating("AddRoad", 1f, createRoadSpeed);
                gameStarted = true;
            }
        }
    }


    void AddRoad() {

        // Create the new block
        GameObject currentRoad = (GameObject)Instantiate(roadCubePrefab, currentPosition, Quaternion.identity);

        // Decide if there is a crystal here or not.  If so, set it active (since technically its always "there"
        int crystalYN = Random.Range(1, 100);
        if (crystalYN > 70) {
            // Crystal present, set it active.
            Transform crystal = currentRoad.transform.GetChild(0);
            crystal.gameObject.SetActive(true);
        }

        // Preserve the prior position for camera movement
        lastPosition = currentPosition;

        // Determine x or z direction with a random roll to generate next block
        int direction = Random.Range(1, 100);

        // Setup the next position
        if (direction <= 50) {
            // Go X
            float moveX = currentPosition.x + 1;
            currentPosition = new Vector3(moveX, currentPosition.y, currentPosition.z);
        } else {
            // Go Z+
            float moveZ = currentPosition.z + 1;
            currentPosition = new Vector3(currentPosition.x, currentPosition.y, moveZ);
        }

        // Move the camera - moved to player controller
        /* GameObject thisCam = camera.gameObject;
        thisCam.transform.position = currentRoad.transform.position + offset;
        */

        // Setup the block to be destroyed behind the player
        Destroy(currentRoad, 10f);

    }


}
