using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;
    [SerializeField]
    private bool _stopSpawning;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector2 posToSpawn = new Vector2(Random.Range(-3.25f, 3.25f), 2.4f);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        while(_stopSpawning == false)
        {
            float _time = Random.Range(5.0f, 9.0f);
            Vector2 posToSpawn = new Vector2(Random.Range(-3.25f, 3.25f), 2.4f);
            GameObject newTS = Instantiate(_tripleShotPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_time);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
