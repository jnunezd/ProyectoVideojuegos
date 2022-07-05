using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JohnMovement John = collision.GetComponent<JohnMovement>();
        GruntScript Grunt = collision.GetComponent<GruntScript>();

        if (John != null)
        {
            John.Hit();
            DestroyBullet();
        }
        if (Grunt != null)
        {
            Grunt.Hit();
            DestroyBullet();
        }
        
    }

}
