using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int units = 1;
    public float moveSpeed = 4;


    public int health = 300;
    public int damagePerHit = 100;
    public float attackSpeed = 1f;
    public float power = 100.0f; //damage/second
    public float range = 1f;

    private void Start()
    {
        StartCoroutine(MoveForward());
        StartCoroutine(CheckInRange());
    }

    public void KillSelf()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator MoveForward()
    {
        while (true)
        {
            var trans = transform.position;
            transform.position = new Vector2(trans.x, trans.y - 1);
            Debug.Log("moving");
            yield return new WaitForSeconds(moveSpeed);
        }
    }
    private IEnumerator CheckInRange()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, range, 1 << 8);
        if (hit.collider != null)
        {
            Debug.Log("PlayerHit");
            Attack(hit.collider.gameObject.GetComponent<Gang>());
        }
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine(CheckInRange());
    }
    private void Attack(Gang player)
    {
        //getHitAnim
        player.gameObject.GetComponent<Animator>().SetTrigger("Hit");
        //reduce enemy hp
        player.health -= damagePerHit;
        if (player.health <= 0)
            player.KillSelf();
    }


}
