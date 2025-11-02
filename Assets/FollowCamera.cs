using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField] private Transform driverTransform;

    void Start() {
        // Find the Driver in the scene if not assigned
        if (driverTransform == null) {
            Driver driver = FindFirstObjectByType<Driver>();
            if (driver != null) {
                driverTransform = driver.transform;
            }
        }
    }

    // LateUpdate is called after all Update methods, ensuring smooth camera follow
    void LateUpdate() {
        if (driverTransform != null) {
            // Match the camera position to the driver's position
            // Keep the camera's Z position unchanged (for 2D camera depth)
            transform.position = new Vector3(driverTransform.position.x,
                                            driverTransform.position.y,
                                            transform.position.z);
        }
    }
}
