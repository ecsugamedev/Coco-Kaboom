using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject Timer, WinPanel;

    [SerializeField]
    AudioSource sound;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            Timer.GetComponent<Timer>().isTiming = false;
            WinPanel.SetActive(true);
            Time.timeScale = 0.125f;
            sound.Play();
        }
    }
}
