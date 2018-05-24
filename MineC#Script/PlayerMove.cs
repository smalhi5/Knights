using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Animator animation;
    private CharacterController charController;
    private CollisionFlags collisionFlags = CollisionFlags.None;

    private float movementSpeed = 10f;
    private bool canMove;
    private bool finished_Movement = true;

    private Vector3 target_Position = Vector3.zero;
    private Vector3 player_Move = Vector3.zero;
    private float player_ToPointDistance;

    void Awake()
    {
        animation = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CheckIfFinishedMovement();
    }

    void CheckIfFinishedMovement()
    {
        if (!finished_Movement)
        {
            if (!animation.IsInTransition(0) && !animation.GetCurrentAnimatorStateInfo(0).IsName("Stand") && animation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finished_Movement = true;
            }
        }
        else
        {
            MoveThePlayer();
            player_Move.y = height * Time.deltaTime;
            collisionFlags = charController.Move(player_Move);
        }
    }

    void MoveThePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider is TerrainCollider)
                {

                    player_ToPointDistance = Vector3.Distance(transform.position, hit.point);

                    if (player_ToPointDistance >= 1.0f)
                    {
                        canMove = true;
                        target_Pos = hit.point;
                    }

                }
            }
        }

        if (canMove)
        {
            animation.SetFloat("Walk", 1.0f);
            Vector3 target_Temp = new Vector3(target_Pos.x, transform.position.y, target_Pos.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target_Temp - transform.position), 15.0f * Time.deltaTime);
            player_Move = transform.forward * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target_Pos) <= 0.1f)
            {
                canMove = false;
            }

        }
        else
        {
            player_Move.Set(0f, 0f, 0f);
            animation.SetFloat("Walk", 0f);
        }
    }

    public bool FinishedMovement
    {
        get
        {
            return finished_Movement;
        }
        set
        {
            finished_Movement = value;
        }
    }

    public Vector3 TargetPosition
    {
        get
        {
            return target_Pos;
        }
        set
        {
            target_Pos = value;
        }
    }
}