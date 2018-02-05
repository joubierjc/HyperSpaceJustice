using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Border border;

    public float maxHealth;
    public float health;
    public float damage;
    public float speed;

    private StatsHolder stats;
    private WeaponSystem weapsys;

	private void Start () {
        stats = GetComponent<StatsHolder>();
        stats.OnZeroHealth = OnDeath;

        weapsys = GetComponent<WeaponSystem>();
	}

	private void Update () {
        // TODO Input manager or smth
        // Movements
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * stats.speed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * stats.speed;
        transform.Translate(new Vector3(horizontal, vertical), Space.World);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, border.xMin, border.xMax),
            Mathf.Clamp(transform.position.y, border.yMin, border.yMax),
            0f
        );

        // Firing
        if (weapsys.CanFire()) {
            weapsys.Fire();
        }
    }

    private void OnTriggerEnter(Collider other) {
        var bullet = other.GetComponent<BulletController>();
        if(bullet) {
            if (!bullet.isFromPlayer) {
                stats.Health -= bullet.damage;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnDeath() {
        Destroy(gameObject);
    }
}
