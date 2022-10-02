using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float AttackDamage = 1f;

    [SerializeField]
    private float Health = 1.0f;
    [SerializeField]
    private float runSpeed = 2.0f;

    private Rigidbody2D rb;
    private GameObject Player;
    private float invencibilityTimeLeft = 0f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {

    }

    void Update()
    {
        if (invencibilityTimeLeft > 0f)
            invencibilityTimeLeft -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        rb.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, runSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            TakeDamage(collision.gameObject.GetComponent<Weapon>().AttackDamage);
        }
    }

    private void TakeDamage(float amount)
    {
        if (invencibilityTimeLeft > 0f)
            return;

        Health -= amount;
        invencibilityTimeLeft = 0.5f;
        if (Health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject, 0.5f);
    }

    //IEnumerator ActuallyDie()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    Destroy(this,)
    //}
}
