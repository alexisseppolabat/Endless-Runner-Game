using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
    public Animator gameOverAnimator;
    public GameObject gameOverPanel;
    public PlayerMovement movement;
    public Text scoreText;
    public Text highScoreText;
    public Text gameOverHighScoreText;
    public Text gameOverScore;
    public PlayerMovement playerMovement;
    
    private bool gameInPlay = true;

    public void KillPlayer() {
        if (gameInPlay) {
            gameInPlay = false;
            // Stop the player from being able to move when they die
            movement.enabled = false;

            scoreText.enabled = false;
            highScoreText.enabled = false;
            gameOverHighScoreText.text = Player.highscore.ToString();
            gameOverScore.text = playerMovement.score.ToString();

            gameOverPanel.SetActive(true);
            gameOverAnimator.enabled = true;
            gameOverAnimator.Play("GameOver");
        }
    }

    // public void WonGame() {
    //     if (gameInPlay) {
    //         gameInPlay = false;
    //         // Stop the player from being able to move when they win
    //         movement.enabled = false;
    //
    //         winnerPanel.SetActive(true);
    //         winnerAnimator.enabled = true;
    //         winnerAnimator.Play("Win");
    //     }
    // }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
