using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animation;
    private bool canAttack = true;
    private PlayerMove playerMove;

    void Awake(){

        animation = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
    }

    void Update(){

        if (!animation.IsInTransition(0) && animation.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        Input();

    }

    void Input(){

        if (animation.GetInteger("Atk") == 0)
        {
            playerMove.FinishedMovement = false;

            if (!animation.IsInTransition(0) && animation.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && playerMove.FinishedMovement && canAttack)
        {
            playerMove.TargetPosition = transform.position;
            animation.SetInteger("Atk", 6);
        }

    }

}