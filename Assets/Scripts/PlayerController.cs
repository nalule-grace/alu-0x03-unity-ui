using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public variable to control speed, can be modeified in the inspector
    public float speed = 1000f;
    private Rigidbody Player;
    private int score = 0;
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // move player upward with the "w" key
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Player.AddForce(0,0, speed);
        }

        // move player backwards with the "s" key
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Player.AddForce(0,0, -speed);
        }

        // move player to the right with the "d" key
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Player.AddForce(speed, 0, 0);
        }

        // move player to left with "a" key
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Player.AddForce(-speed, 0, 0);
        }

        if (health == 0)
        {
            Debug.Log($"Gme Over!");
            SceneManager.LoadScene("maze");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log($"You win!");
        }
    }

}