using UnityEngine;

public class ResetByBoundaries : MonoBehaviour {

    private Vector3 startingPosition;

	private void Start () {
        startingPosition = transform.position;
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Boundaries")) {
            transform.position = startingPosition; 
        }
    }

}
