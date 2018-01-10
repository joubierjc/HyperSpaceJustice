using UnityEngine;

public class EnemyController : MonoBehaviour {

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
