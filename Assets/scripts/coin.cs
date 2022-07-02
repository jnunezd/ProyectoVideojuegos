using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.SumarPuntos(valor);
            // collision.GetComponent<GameManager>().SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
    
}
