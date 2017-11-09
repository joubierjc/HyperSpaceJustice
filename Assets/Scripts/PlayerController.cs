using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public Boundary boundary;

    public float speed;
    public float tilt;
    [Range(0,10)]
    public float smoothSpeed;

    public float fireRate;
    public GameObject shot;
    public Transform shotSpawn;

    public KeyCode shotKey;

    private Rigidbody rb;
    private float nextFire;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        nextFire = fireRate;
    }

    private void Update() {
        nextFire += Time.deltaTime;
        if (Input.GetKey(shotKey) && nextFire > fireRate) {
            nextFire = 0;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
        }
    }

    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            rb.position.y,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0.0f, 0.0f, moveHorizontal * -tilt), smoothSpeed * Time.deltaTime);
    }
}