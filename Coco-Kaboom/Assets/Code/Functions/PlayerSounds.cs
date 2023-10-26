using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip hitSound;

    [SerializeField]
    private AudioSource sound;

    private Rigidbody2D player;

    private void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            sound.PlayOneShot(hitSound);
        }
    }

    private void Update()
    {

    }
}
