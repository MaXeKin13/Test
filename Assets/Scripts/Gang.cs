using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gang : MonoBehaviour
{
    public string name;
    public string itemType;

    public GameObject bullet;
    public int availableLevel;
    public int Units;
    [SerializeField] private int currencyCreation;
    [SerializeField] private int timeToCreate;
    [SerializeField] private int range;
    public int health;
    public int price;
    [SerializeField] private int deliveryTime;
    [SerializeField] private int damagePerHit;
    [SerializeField] private float attackSpeed;
    private int Power;



    private Enemy enemyInRange;

    private void Start()
    {
        Debug.Log(GameManager.Instance);
        
        StartCoroutine(CheckInRange());
    }

    private void Update()
    {
        
    }
    //check if enemy in range
   
    private IEnumerator CheckInRange()
    {
     
        int layerMask = 1 << 7;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, range, 1 << 7);
        if (hit.collider != null)
        {
            Debug.Log("Hit");
            Attack(hit.collider.gameObject.GetComponent<Enemy>());
        }
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine(CheckInRange());
    }
    private void Attack(Enemy enemy)
    {
        var bull = Instantiate(bullet, transform.position, Quaternion.identity);
        bull.transform.DOMove(enemy.transform.position, 0.5f);
        Destroy(bull, 0.5f);
        Debug.Log("GangHit");
        enemy.gameObject.GetComponent<Animator>().SetTrigger("Hit");
        //reduce enemy hp
        enemy.health -= damagePerHit;
        if (enemy.health <= 0)
            enemy.KillSelf();
    }

    public void KillSelf()
    {
        gameObject.SetActive(false);
    }

    //shoot visual

    //Currency Creation
    


}
