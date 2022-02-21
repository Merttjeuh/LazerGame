using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Wave Config", fileName = "New wave Config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] List<GameObject> enemyPrefabs;
    // containers from waypoint and the movespeed of the path
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }


        //making the private value public
        // we are only calling the first waypoint so the first child (pathPrefab.GetChild(0)) 
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    // now we are getting the waypoints from the child element
    // we made a foreach so it continues the looping every time
           // returns the list from the path
    public List<Transform> GetWayPoints()
    {
        //making a var and initialize with the new var
        List<Transform> waypoints = new List<Transform>();
        // calling the pathprefab and looping all the children and storing them as transforms
        foreach(Transform child in pathPrefab)
        {
            // we are storing the childs in to the waypoints
            waypoints.Add(child);
        }
        return waypoints;
    }


    //making the private float public
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }

}
