using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float speed;
    public float JumpForce;


    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    
    private float Horizontal;
    private bool Grounded;

    private float LastShoot;

    private int Health = 5;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        Animator.SetBool("running", Horizontal != 0.0f);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1, 1, 1);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1, 1, 1);


        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject Bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health--;
        if (Health == 0) Destroy(gameObject);
        
    }

    


}
