using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public PlayerManager manager;
    public Text scoreText;
    public Text highScoreText;
    public int score;
    public Rigidbody playerBody;
    public int forwardSpeed = 500, sideForce = 100, winningScore = 2000;
    
    private int getSpeed(int baseSpeed) {
        return (int) Mathf.Round(Time.deltaTime * baseSpeed);
    }

    private void Start() {
        highScoreText.text = Player.highscore.ToString();
    }

    private void FixedUpdate() {
        // If the player has fallen off the path then restart the game
        if (playerBody.position.y < -1) manager.KillPlayer();
        else {
            // Allow the player to move the cube with the A and D key
            playerBody.AddForce(
                Input.GetKey("d") ? getSpeed(sideForce) : Input.GetKey("a") ? -getSpeed(sideForce) : 0, 0, 0, ForceMode.VelocityChange
            );
            
            Vector3 velocity = playerBody.velocity;
            playerBody.velocity = new Vector3(velocity.x, velocity.y, getSpeed(forwardSpeed));
            
            // Increase the score with every fixed update and update the text onscreen accordingly
            score += 50;
            scoreText.text = score.ToString();
            if (score > Player.highscore) {
                Player.highscore = score;
                highScoreText.text = Player.highscore.ToString();
            }
        }
    }
}
