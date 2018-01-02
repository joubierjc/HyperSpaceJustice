using UnityEngine;

public class DestroyByBoundaries : MonoBehaviour {
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Boundaries")) {
            Destroy(gameObject);
        }
    }
}
