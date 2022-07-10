using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int valor = 1;
    public GameManager manager;

    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.SumarPuntos(valor);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(this.gameObject);
        }
    }
    
}
