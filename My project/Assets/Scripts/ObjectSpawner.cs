using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject[] trianglePrefabs;
    public int spawnDistance;
    public int distanceBetweenTriangles;
    private Vector3 spawnObstaclePosition;


    private void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if (distanceToHorizon < spawnDistance)
        {
            spawnTriangle();
        }
    }

    private void spawnTriangle()
    {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + distanceBetweenTriangles);
        Instantiate(trianglePrefabs[Random.Range(0, trianglePrefabs.Length)], spawnObstaclePosition, Quaternion.identity);
    }
}
