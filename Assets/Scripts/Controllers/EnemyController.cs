using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private StatsHolder stats;

    private void Start () {
        stats = GetComponent<StatsHolder>();
        stats.OnZeroHealth = OnDeath;
	}

	private void Update () {
        // TODO:
        // A nice way to implements AI Behaviour
        // like this
        // public Pattern[] patterns;
        // private PatternManager patMan;
        // Start
        //      patMan = new PatternManager(this, patterns);
        // Update() {
        //      patMan.Act();
	}

    private void OnTriggerEnter(Collider other) {
        var bullet = other.GetComponent<BulletController>();
        if (bullet) {
            if (bullet.isFromPlayer) {
                stats.Health -= bullet.damage;
            }
        }
    }

    private void OnDeath() {
        Destroy(gameObject);
    }
}
