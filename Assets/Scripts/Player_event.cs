using System;
using UnityEngine;

public class Player_event : MonoBehaviour
{
    public event Action OnAttack;

    public void Attack()
    {
        Debug.Log("Player attacks!");
        OnAttack?.Invoke();
    }
}