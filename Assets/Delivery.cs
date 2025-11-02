using UnityEngine;

public class Delivery : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision ahoy");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Package")) {
            Debug.Log("Package collected.");
        } else if (other.CompareTag("Customer")) {
            Debug.Log("package delivered");
        } else {
            Debug.Log("Trigger passed.");
        }
    }
}
