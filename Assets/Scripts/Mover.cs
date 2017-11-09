using UnityEngine;

public class Mover : MonoBehaviour {

    public bool enableRandomSpeed;
    public float minSpeed;

    public float speed;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        if (enableRandomSpeed) {
            speed = Random.Range(minSpeed, speed);
        }
        rb.velocity = transform.forward * speed;
    }
}
