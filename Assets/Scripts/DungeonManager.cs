using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {

    public GameObject floorCubePrefab;

    Vector3 startPosition = new Vector3(0, 0, 0);
    Vector3 currentPosition = new Vector3(0, 0, 0);
    private float currentYPosition = 0;

    public int dungeonWidth = 12;
    public int dungeonHeight = 12;

    void Start() {
        currentPosition = startPosition;
        BuildDungeonLevel(0);
        BuildDungeonLevel(1);
    }

    void Update() {
        
    }


    // Build the Dungeon
    void BuildDungeonLevel(float yLevel) {

        // always reset to origin for new construction
        currentPosition = startPosition;

        // Z placeholder
        float currentZ = 0;
        currentYPosition = yLevel;
        currentPosition = new Vector3(0, currentYPosition, 0);

        // Start with a row of width
        for (int i = 0; i < dungeonWidth; i++) {

            // Now do the Z and actually build the floor
            for (int z = 0; z < dungeonHeight; z++) {
                if (currentYPosition > 0) {
                    int wallHere = Random.Range(1, 50);
                    if (wallHere > 25) {
                        MakeWallHere();
                    }
                } else {
                    MakeWallHere();
                }

                float nextZ = currentPosition.z + 1;
                currentPosition = new Vector3(currentPosition.x, currentYPosition, nextZ);
            }

            // Advance the row
            float nextX = currentPosition.x + 1;
            currentPosition = new Vector3(nextX, currentYPosition, 0);

        }

    }


    // Outer Walls
    void BuildDungeonWalls() {
        currentPosition = startPosition;
        currentYPosition = currentPosition.y + 1;
        currentPosition = new Vector3(currentPosition.x, currentYPosition, currentPosition.z);

        // Build the top and bottom walls
        for (int i = 0; i < dungeonWidth; i++) {
                
            // First row
            if (currentPosition.z == 0) {
                MakeWallHere();
            }

            // Non edge rows
            else if (currentPosition.z < dungeonWidth) {
                if (i == 0 || i == dungeonWidth) {
                    MakeWallHere();
                }
            }
        }

    }


    void MakeWallHere() {
        Instantiate(floorCubePrefab, currentPosition, Quaternion.identity);
    }

    /*
    void AddRoad() {

        // Create the new block
        GameObject currentRoad = (GameObject)Instantiate(roadCubePrefab, currentPosition, Quaternion.identity);

        // Decide if there is a crystal here or not.  If so, set it active (since technically its always "there"
        int crystalYN = Random.Range(1, 100);
        if (crystalYN > 50) {
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
    /*    
    Destroy(currentRoad, 10f);

    }
*/


}
