using System;
using UnityEngine;

public class StatsHolder : MonoBehaviour {
    public bool isPlayer;

    public float maxHealth;

    [SerializeField]
    private float _health;
    public float Health {
        get {
            return _health;
        }
        set {
            _health = value;
            if(_health <= 0) {
                OnZeroHealth();
            }
        }
    }

    public float damage; // TODO: does nothing right now

    public float speed;

    // Events/Delegates
    public Action OnZeroHealth = () => { };
}
