using UnityEngine;

public class Delivery : MonoBehaviour {
    [SerializeField] private Color32 carWithPackageColor = new Color32(1, 1, 1, 255);
    [SerializeField] private Color32 carNoPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] private float destroyDelay = 1.0f;
    private bool hasPackage = false;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = carNoPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collision ahoy");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Package") && !hasPackage) {
            Debug.Log("Package collected.");
            hasPackage = true;
            spriteRenderer.color = carWithPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } else if (other.CompareTag("Customer") && hasPackage) {
            Debug.Log("package delivered");
            hasPackage = false;
            spriteRenderer.color = carNoPackageColor;
        }
    }
}
