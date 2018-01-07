using UnityEngine;

public class ConstantMover : MonoBehaviour {
    public Vector3 direction;

    private StatsHolder stats;

    private void Start() {
        stats = GetComponent<StatsHolder>();
        direction.Normalize();
        direction = new Vector3(direction.x, direction.y, 0f);
    }

    private void Update() {
        transform.Translate(direction * stats.speed * Time.deltaTime, Space.World);
    }
}
