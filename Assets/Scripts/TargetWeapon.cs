using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWeapon : MonoBehaviour
{
    public GameObject Target;
    public float Speed = 2.0f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.1f);
    }
}
