using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public AudioClip onCheckpointSound;
    private bool isCheckpoint = false;
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.CompareTag("Player"))
        {
            if (!this.isCheckpoint)
            {
                this.isCheckpoint = true;
                AudioSource.PlayClipAtPoint(onCheckpointSound, transform.position);
                collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(transform.position.x, transform.position.y);
                GetComponent<Animator>().enabled = true;
            }
            
        }
   }
    
}
