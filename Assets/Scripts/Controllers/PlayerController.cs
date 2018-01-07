using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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

        // Firing
        if(weapsys.CanFire()) {
            weapsys.Fire();
        }
    }

    private void OnTriggerEnter(Collider other) {
        var bullet = other.GetComponent<BulletController>();
        if(bullet) {
            if (!bullet.isFromPlayer) {
                stats.Health -= bullet.damage;
            }
        }
    }

    private void OnDeath() {
        Destroy(gameObject);
    }
}
