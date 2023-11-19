using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level;
    public int waves;

    public int lanes;

    public int money;

    public float initialTimer;
    public float spawnTimer;
    public float waveTimer;

    [Space]
    public TextMeshProUGUI moneyUI;

    public EnemyManager enemyManager;


    public PlayerManager playerManager;

    public static GameManager Instance;

    public bool gameStart;

    private int currentWave = 0;
    private float mainTimer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        StartCoroutine(InitialSpawnTimer());
        StartCoroutine(WaveTimer());
    }

    private void Update()
    {
        mainTimer += Time.deltaTime; 
    }

    //manage Money
    public void SubtractMoney(int ammount)
    {
        money -= ammount;
        moneyUI.text = money.ToString();
    }

    private void EndWave()
    {
        //end level
        if(currentWave > waves)
        { EndLevel(); }
        else
            NextWave();
    }
    private void NextWave()
    {
        mainTimer = 0f;
        if(currentWave <= waves)
            InitialSpawnTimer();
        else
            EndLevel();
    }
    private void EndLevel()
    {

    }
    private IEnumerator InitialSpawnTimer()
    {
        float timer = 0f;
        while (timer<initialTimer)
        {

            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("initialSpawnOver");
        enemyManager.SpawnEnemy();
        StartCoroutine(SpawnTimer());

    }
    private IEnumerator SpawnTimer()
    {
        float timer = 0f;

        
        while (timer<spawnTimer)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        enemyManager.SpawnEnemy();
        StartCoroutine (SpawnTimer());
    }
    private IEnumerator WaveTimer()
    {
        float timer = 0f;
        while (timer < waveTimer)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        currentWave++;
        Debug.Log("wave over");
        EndWave();
    }

}
