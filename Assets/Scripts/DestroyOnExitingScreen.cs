using UnityEngine;

public class DestroyOnExitingScreen : MonoBehaviour {
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
