using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject warningRangePrefab;
    [SerializeField]
    private GameObject warningClosePrefab;

    [SerializeField]
    private float spawnRangeIntervals = 5f;
    [SerializeField]
    private float spawnCloseIntervals = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRangeIntervals, warningRangePrefab));
        StartCoroutine(spawnEnemy(spawnCloseIntervals, warningClosePrefab));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-25, 25), 0, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
