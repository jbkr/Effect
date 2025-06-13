using System;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    [SerializeField]
    private Player_event player;
    [SerializeField]
    private Enemy_event enemy;

    private void Start()
    {
        player.Attack();
    }
}