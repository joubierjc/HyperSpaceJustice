using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;

    public Vector3 offset;
	
	void FixedUpdate () {
        if (target == null) {
            return;
        }
        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(desiredPosition, transform.position, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
	}
}
