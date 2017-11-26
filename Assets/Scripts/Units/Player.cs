using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {
    public Boundary boundary;

    public Transform shotTransform;

    public Weapon weapon;
    public GameObject bullet;

    private float _health;
    public float health {
        get {
            return _health;
        }
        set {
            _health = value;
            OnHealthChanged();
        }
    }
    public float speed;
    public float tilt;
    [Range(0,10)]
    public float smoothSpeed;
    
    public KeyCode shotKey;

    private Rigidbody rb;
    private float nextFire;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        weapon.attachedTo = tag;
    }
    
    private void Update() {
        nextFire += Time.deltaTime;
        if (nextFire > weapon.GetFireRate()) {
            weapon.Fire(bullet, shotTransform, Input.GetKey(shotKey), ResetNextFire);
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

    private void ResetNextFire() {
        nextFire = 0;
    }

    private void OnHealthChanged() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundaries") {
            return;
        }

        if (other.tag == "Shot") {
            var shot = other.gameObject.GetComponent<Shot>();
            if(shot.firedBy == tag) {
                return;
            }
            health -= shot.damage;
            Destroy(other.gameObject);
            return;
        }
        
    }
}