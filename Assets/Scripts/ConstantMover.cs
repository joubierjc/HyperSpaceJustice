using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMover : MonoBehaviour {
    public Vector3 direction;
    public float speed;

    private void Start() {
        direction.Normalize();
        direction = new Vector3(direction.x, direction.y, 0f);
    }

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
