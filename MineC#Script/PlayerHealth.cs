using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float playerHealth = 100f;
    private Animator animation;

    void Awake()
    {
        animation = GetComponent<Animator>();
    }

    public void TakeDamage(float damage){

        playerHealth -= damage;

        if (health <= 0f)
        {
            animation.SetBool("Death", true);

            if (!animation.IsInTransition(0) && animation.GetCurrentAnimatorStateInfo(0).IsName("Death") && animation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0)
            {
                Destroy(gameObject, 2f);
            }
        }
    }

    public void HealPlayer(float heal) {

        health += heal;

        if (health > 100f)
        {
            health = 100f;
        }
    }
}