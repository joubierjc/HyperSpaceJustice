using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundaries") {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
