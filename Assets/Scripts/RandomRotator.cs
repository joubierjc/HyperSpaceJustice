using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;

    private Vector3 randomRotation;

    private void Start() {
        randomRotation = Random.insideUnitSphere * tumble;
    }

    private void Update() {
        transform.Rotate(randomRotation * Time.deltaTime);
    }
}
