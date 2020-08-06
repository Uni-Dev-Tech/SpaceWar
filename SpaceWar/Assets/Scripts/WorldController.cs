using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject[] asteroids;
    public Transform[] spawnPoints;
    private int randomIndexAsteroids;
    private int randomIndexPoint;
    [SerializeField]
    static public float timeRange = 1f;

    private void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    IEnumerator SpawnSystem()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeRange);
            randomIndexPoint = Random.Range(0, 6);
            randomIndexAsteroids = Random.Range(0, 5);
            Instantiate(asteroids[randomIndexAsteroids], spawnPoints[randomIndexPoint].position, Quaternion.identity);
        }
    }
}
