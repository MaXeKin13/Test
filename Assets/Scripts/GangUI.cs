using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class GangUI : MonoBehaviour
{
    public Gang gang;
    private bool inField;
    public Transform spawnPos;
    private Vector2 initialPos;
    private void Start()
    {
        initialPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        inField = true;
        spawnPos = collision.transform;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inField = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0)&& inField)
        {
            if (GameManager.Instance.money -gang.price >= 0)
            {
                GameManager.Instance.SubtractMoney(gang.price);

                Instantiate(gang, spawnPos.position, Quaternion.identity);
                
                
                spawnPos.gameObject.SetActive(false);
            }
            inField = false;
            transform.position = initialPos;
        }
    }
}
