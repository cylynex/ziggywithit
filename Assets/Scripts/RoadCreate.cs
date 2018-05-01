using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreate : MonoBehaviour {

    public GameObject roadCubePrefab;
    Vector3 startPosition = new Vector3(0, 0, 0);
    Vector3 currentPosition = new Vector3(0, 0, 0);

    void Start() {
        InvokeRepeating("AddRoad", 1f, 1f);
        currentPosition = startPosition;
    }


    void AddRoad() {
        GameObject currentRoad = (GameObject)Instantiate(roadCubePrefab, currentPosition, Quaternion.identity);

        // Decide if there is a crystal here or not.  If so, set it active (since technically its always "there"
        int crystalYN = Random.Range(1, 100);
        if (crystalYN > 50) {
            // Crystal present, set it active.
            Transform crystal = currentRoad.transform.GetChild(0);
            crystal.gameObject.SetActive(true);
        }

        // Determine x or z direction with a random roll to generate next block
        int direction = Random.Range(1, 100);
        Debug.Log("moving " + direction);

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

    }

}
