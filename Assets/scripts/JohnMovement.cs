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
    private int originalHealth = 3;
    private int Health = 3;

    private bool controlsEnabled = true;
    private bool isDead = false;

    private Collider2D playerCollider;
    public GameObject[] ChilfObjs;
    public float shockForce;

    public GameObject[] hearts;
    public GameManager manager;

    public GameObject fallDetector;

    public AudioClip JohnHit;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        playerCollider = GetComponent<Collider2D>();
        controlsEnabled = true;

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

        
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire") && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
        if (controlsEnabled)
        {
            
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Animator.SetTrigger("John_Shoot");
        Vector3 direction;

        if (transform.localScale.x == 1) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject Bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        AudioSource.PlayClipAtPoint(JohnHit, transform.position);
        Health--;
        if (this.Health < 1)
        {
            hearts[0].gameObject.SetActive(false);
            this.Die();
        } else if (this.Health < 2)
        {
            hearts[1].gameObject.SetActive(false);

        } else if (this.Health < 3)
        {
            hearts[2].gameObject.SetActive(false);

        }
        
    }

    public void Die()
    {
        isDead = true;
        Animator.SetBool("dead", isDead);
        controlsEnabled = false;
        playerCollider.enabled = false;

        foreach (GameObject child in ChilfObjs)
        {
            child.SetActive(false);
        }
        Rigidbody2D.gravityScale = 0.5f;
        Rigidbody2D.AddForce(transform.up * shockForce, ForceMode2D.Impulse);
        waiter(5.5f);
        this.PlayerRespawn();
    }

    public void PlayerRespawn()
    {
        waiter(1.5f);
        isDead = false;
        Animator.SetBool("dead", isDead);
        playerCollider.enabled = true;
        foreach (GameObject child in ChilfObjs)
        {
            child.SetActive(true);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }


        Rigidbody2D.gravityScale = 1.3f;
        waiter(0.1f);
        controlsEnabled = true;
        Health = originalHealth;
        GetComponent<PlayerRespawn>().respawn();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("caida f");
        if (collision.CompareTag("DetectorCaida"))
        {
            Debug.Log("caida");
            this.Die();
        }
    }

    IEnumerator waiter(float time)
    {
        yield return new WaitForSeconds(time);
    }

    


}
