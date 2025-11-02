using UnityEngine;

public class Driver : MonoBehaviour {
    [SerializeField] private float rotationSpeed = 250.0f;
    [SerializeField] private float moveSpeed = 5.0f;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        // Get horizontal input (-1 to 1)
        float horizontalInput = Input.GetAxis("Horizontal");
        // Get vertical input (-1 to 1)
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate around the Z-axis based on horizontal input
        transform.Rotate(0f, 0f, -horizontalInput * rotationSpeed * Time.deltaTime);

        // Translate based on vertical input
        transform.Translate(0f, verticalInput * moveSpeed * Time.deltaTime, 0f);
    }
}
