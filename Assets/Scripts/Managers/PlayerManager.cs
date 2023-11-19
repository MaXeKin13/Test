using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   public List<Gang> activePlayers;

    public GameObject Gang;
    public Transform spawnPos;

    public static PlayerManager Instance;


   
   private void Start()
    {
        if(Instance == null)
            Instance = this;
    }
    public void SpawnNewGang()
    {
        Instantiate(Gang, spawnPos.position, Quaternion.identity);
    }

   
}
