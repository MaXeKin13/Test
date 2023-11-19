using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public List<Enemy> enemies;
    public Transform spawnPoint;


    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        //only spawn on one tile
        Instantiate(enemy.gameObject, spawnPoint.position, Quaternion.identity);
    }

    


}
