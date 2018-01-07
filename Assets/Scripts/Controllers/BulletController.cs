using UnityEngine;

public class BulletController : MonoBehaviour {
    public bool isFromPlayer;
    public Vector3 direction;
    public float damage;
    public float speed;

    private void Start() {
        direction.Normalize();
        direction = new Vector3(direction.x, direction.y, 0f);
    }

    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
