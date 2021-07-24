using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour {
    public Spawner spawner;
    public PlayerManager manager;

    public void OnCollisionEnter(Collision collision) {
        // Play the game over animation when the player collides with an obstacle
        if (collision.collider.CompareTag("Obstacle")) manager.KillPlayer();
    }

    private void OnTriggerEnter(Collider triggerCollider) {
        // The moment the player reaches the end of the path, move them
        // back to their spawn point and respawn the obstacles
        if (triggerCollider.CompareTag("Spawn Trigger")) spawner.UpdateWorld();
    }
}
