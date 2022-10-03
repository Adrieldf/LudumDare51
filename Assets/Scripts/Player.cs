using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Health = 3.0f;
    [SerializeField]
    private Collider2D attackRange;
    [SerializeField]
    private GameObject attackTargetIndicator;

    private float invencibilityTimeLeft = 0f;
    private GameObject targetToAttack;

    void Start()
    {

    }

    void Update()
    {
        if (targetToAttack == null)
        {
            attackTargetIndicator.SetActive(false);
        }
        else
        {
            Vector3 pos = targetToAttack.transform.position;
            Vector3 viewPortPos = Camera.main.WorldToViewportPoint(pos);
            viewPortPos.y += 5;
            attackTargetIndicator.transform.position = viewPortPos;
        }


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
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject nearObject = null;
        float nearObjectDistance = 0f;
        foreach (ContactPoint2D contact in collision.contacts)
        {
            float curDistance = Vector3.Distance(contact.otherCollider.transform.position, transform.position);

            if (!nearObject || curDistance < nearObjectDistance)
            {
                nearObjectDistance = curDistance;
                nearObject = contact.otherCollider.gameObject;
            }

        }
        targetToAttack = nearObject;
    }

    public GameObject GetTargetToAttack()
    {
        return targetToAttack;
    }
}
