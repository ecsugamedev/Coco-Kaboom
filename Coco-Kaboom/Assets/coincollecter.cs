using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollecter : MonoBehaviour
{
    public coincollect cc;
    public AudioClip coinSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cc.coinCount++;
            AudioSource.PlayClipAtPoint(coinSound,transform.position);
        }

        
    }
}
