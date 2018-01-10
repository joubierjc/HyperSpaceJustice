using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    // [HideInInspector]
    public int enemiesCounter;

    public float money;

    public GameObject bossSpawner;
    public GameObject[] spawners;
    public float waitBeforeStart;
    public float waitBetweenWave;
    public Wave[] waves;

    private int currentIndex;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        // Check si on a des waves a spawn.
        if (waves.Length > 0) {
            // On a des vagues, alors on les spawn.
            currentIndex = 0;
            StartCoroutine(SpawnWaves());
        }
    }

    IEnumerator SpawnWaves() {
        // On attend avant de commencer à spawn les waves.
        yield return new WaitForSeconds(waitBeforeStart);
        while (true) {
            var wave = waves[currentIndex];
            for (int i = 0; i < wave.numberOfEnnemies; i++) {
                Instantiate(
                    wave.enemies[Random.Range(0, wave.enemies.Length)],
                    !wave.bossWave ? spawners[Random.Range(0, spawners.Length)].transform.position : bossSpawner.transform.position,
                    Quaternion.identity
                );
                yield return new WaitForSeconds(wave.waitBetweenSpawn);
            }
            // Avant de spawn une autre wave on attend que tous les ennemis soient détruits.
            yield return new WaitWhile(() => enemiesCounter > 0);
            // On attend avant de spawn une nouvelle vague.

            // SHOPPING

            yield return new WaitForSeconds(waitBetweenWave);
            // On incrémente le compteur de la wave.
            currentIndex++;
            // Si on a dépassé le nombre max de vague on reset le compteur.
            if (currentIndex > waves.Length - 1) {
                currentIndex = 0;
            }
        }
    }
}
