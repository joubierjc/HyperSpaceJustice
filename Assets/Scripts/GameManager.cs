using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    [HideInInspector]
    public int enemiesCounter;

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
            waitEnemiesDestruction = new WaitForSeconds(1);
            StartCoroutine(SpawnWaves());
        }
    }

    IEnumerator SpawnWaves() {
        // On attend avant de commencer à spawn les
        yield return new WaitForSeconds(waitBeforeStart);
        while (true) {
            for (int i = 0; i < waves[currentIndex].numberOfEnnemies; i++) {
                Instantiate(
                    waves[currentIndex].enemies[Random.Range(0, waves[currentIndex].enemies.Length)],
                    spawners[Random.Range(0, spawners.Length)].transform.position,
                    Quaternion.identity
                );
                yield return new WaitForSeconds(waves[currentIndex].waitBetweenSpawn);
            }
            // Avant de spawn une autre wave on attend que tous les ennemis soient détruits.
            yield return new WaitWhile(() => enemiesCounter > 0);
            // On attend avant de spawn une nouvelle vague.
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
