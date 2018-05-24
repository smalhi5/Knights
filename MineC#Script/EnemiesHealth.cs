using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{

    public float health = 100f;

    public void Damage(float amount)
    {
        health -= amount;
    }
}