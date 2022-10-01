using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private float runSpeed = 2.0f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        rb.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, runSpeed * Time.deltaTime);
    }

}
