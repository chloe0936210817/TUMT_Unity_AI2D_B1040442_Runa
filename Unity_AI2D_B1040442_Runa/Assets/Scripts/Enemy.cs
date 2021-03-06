﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20;

    public Transform checkPoint;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "主角")
        {
            Track(collision.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "主角" && collision.transform.position.y<transform.position.y+1) 
        {
            collision.gameObject.GetComponent<Protagonist>().Damage(damage);
        }
    }

    //隨機移動
    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0));
        r2d.AddForce(transform.right * speed);

        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);

        if(hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    //追蹤
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
