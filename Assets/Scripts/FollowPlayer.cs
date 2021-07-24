using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform playerTransform;

    void FixedUpdate() {
        // Get the camera to follow the object
        transform.position = playerTransform.position + new Vector3(0, 2, -5);
    }
}
