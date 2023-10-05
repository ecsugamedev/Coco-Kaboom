using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    GameObject player;

    [SerializeField]
    GameObject HUD, WinPanel;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            HUD.GetComponent<HUD>().isTiming = false;
            WinPanel.SetActive(true);
            Time.timeScale = 0.125f;
        }
    }
}
