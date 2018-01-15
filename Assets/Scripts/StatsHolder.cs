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

    public float damage;
    public float speed;

    [Header("Money dropped if paired with an EnemyController")]
    public float money;

    public int level;
    [SerializeField]
    private float _experience;
    public float Experience {
        get {
            return _experience;
        }
        set {
            _experience = value;
            OnExperienceChanged();
        }
    }

    // Events/Delegates
    public Action OnZeroHealth = () => { };
    public Action OnExperienceChanged = () => { };
}