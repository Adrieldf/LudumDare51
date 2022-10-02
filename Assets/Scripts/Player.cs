using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Health = 3.0f;

    private float invencibilityTimeLeft = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (invencibilityTimeLeft > 0f)
            invencibilityTimeLeft -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (invencibilityTimeLeft <= 0f)
                Destroy(collision.gameObject);

            TakeDamage(collision.gameObject.GetComponent<Enemy>().AttackDamage);
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

}
