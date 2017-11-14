using System;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    public Boundary boundary;

    public Transform shotTransform;

    public Weapon weapon;
    public GameObject bullet;

    public float speed;
    public float tilt;
    [Range(0,10)]
    public float smoothSpeed;
    
    public KeyCode shotKey;

    private Rigidbody rb;
    private float nextFire;

    #region Singleton
    public static PlayerController instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }
    static PlayerController _instance;

    void Awake() {
        _instance = this;
    }
    #endregion

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        nextFire += Time.deltaTime;
        if (nextFire > weapon.GetFireRate()) {
            weapon.Fire();
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

    public void ResetNextFire() {
        nextFire = 0;
    }
}