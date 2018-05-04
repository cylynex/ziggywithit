using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int direction;
    public int speed = 2;
    public Camera camera;

    private RaycastHit hit;
    private Vector3 offset;
    private bool gameOver;

    public static int score;
    public Text scoreBoard;

    private Vector3 position;
    private Vector3 newDir;

    private Animator anim;
    private bool started = false;

    void Start() {
        offset = camera.transform.position - transform.position;
        score = 0;
        scoreBoard.text = "0";
        anim = GetComponent<Animator>();
    }

    void Update() {

        if (!gameOver) {

            // Check for input
            CheckInput();

            // Move player along chosen direction
            MovePlayer();

            // Check if player fell off
            Invoke("CheckFall",1f);
        }
    }

    // Get player input
    void CheckInput() {
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            // Go along z axis
            direction = 2;
            if (!started) { StartAnimation(); }
        } else if (Input.GetKeyUp(KeyCode.RightShift)) {
            // Go along x axis
            direction = 1;
            if (!started) { StartAnimation(); }
        } else if (Input.GetKeyUp("u")) {
            Debug.Log("face");
            transform.Rotate(0, 45, 0);
        }
    }


    // Fire up the animation when game starts
    void StartAnimation() {
        started = true;
        anim.SetTrigger("gameStart");
    }

    // Move the player along chosen direction
    void MovePlayer() {

        position = transform.position;

        if (direction == 1) {
            // Z Axis movement - rshift
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } else if (direction == 2) {
            // X Axis movement - lshift
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }


        // Move the camera along with player
        GameObject thisCam = camera.gameObject;
        thisCam.transform.position = transform.position + offset;
    }


    // Check for fall
    void CheckFall() {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f)) {
            // All good.
            Debug.Log("stuff under me");
        } else {
            Debug.Log("fall");
            // Set animation
            anim.SetTrigger("isFalling");

            // Just for cube
            //gameObject.GetComponent<Renderer>().material.color = Color.red;

            gameOver = true;
            Invoke("Lose", 1f);
        }

        /*
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f)) {
            print("It's a hit at: " + hit.distance + " - " + hit.transform.position);
        } else {
            print("no collision");
        }
        */
    }


    private void OnTriggerEnter(Collider other) {
        string collidedWithTag = other.gameObject.tag;
        if (collidedWithTag == "crystal") {
            // Score points
            score += 10;
            scoreBoard.text = score.ToString();
            Destroy(other.gameObject);
        }
    }


    void Lose() {
        SceneManager.LoadScene("Lose");
    }
}
