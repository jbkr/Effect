using System;
using UnityEngine;

public class Enemy_event : MonoBehaviour
{
    [SerializeField]
    private Player_event player;

    private void Start()
    {
        player.OnAttack += RespondToAttack;
    }

    private void RespondToAttack()
    {
        Debug.Log("Enemy takes damage!");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.Attack();
    }
}