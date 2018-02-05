using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxHealth;
    public float health;
    public float damage;
    public float speed;

    private StatsHolder stats;

    private void Start () {
        stats = GetComponent<StatsHolder>();
        stats.OnZeroHealth = OnDeath;

        GameManager.instance.enemiesCounter++;
	}

    private void OnTriggerEnter(Collider other) {
        var bullet = other.GetComponent<BulletController>();
        if (bullet) {
            if (bullet.isFromPlayer) {
                stats.Health -= bullet.damage;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnDeath() {
        GameManager.instance.money += stats.money;
        Destroy(gameObject);
    }

    private void OnDestroy() {
        GameManager.instance.enemiesCounter--;
    }
}
