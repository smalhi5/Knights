﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public Image fillWaitImage_1;
    public Image fillWaitImage_2;
    public Image fillWaitImage_3;
    public Image fillWaitImage_4;
    public Image fillWaitImage_5;
    public Image fillWaitImage_6;

    private int[] fadeImages = new int[] { 0, 0, 0, 0, 0, 0 };
    private Animator anim;
    private bool canAttack = true;
    private PlayerMove playerMove;
    private PlayerEnergy playerEnergy;

    public float groundImpactSkillCost = 5f;
    public float kickSkillCost = 5f;
    public float tornadoSkillCost = 10f;
    public float fireShieldSkillCost = 15f;
    public float healSkillCost = 10f;
    public float lightlingSkillCost = 20f;

    void Awake(){

        anim = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerEnergy = GetComponent<PlayerEnergy>();
    }

    void Update(){

        if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        CheckToFade();
        CheckInput();

    }

    void CheckInput(){

        if (anim.GetInteger("Atk") == 0)
        {
            playerMove.FinishedMovement = false;

            if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
            {
                playerMove.FinishedMovement = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && playerEnergy.energy >= groundImpactSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[0] != 1 && canAttack)
            {
                fadeImages[0] = 1;
                anim.SetInteger("Atk", 1);
                playerEnergy.takeEnergy(groundImpactSkillCost);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && playerEnergy.energy > kickSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[1] != 1 && canAttack)
            {
                fadeImages[1] = 1;
                anim.SetInteger("Atk", 2);
                playerEnergy.takeEnergy(kickSkillCost);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && playerEnergy.energy >= tornadoSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[2] != 1 && canAttack)
            {
                fadeImages[2] = 1;
                anim.SetInteger("Atk", 3);
                playerEnergy.takeEnergy(tornadoSkillCost);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && playerEnergy.energy > fireShieldSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[3] != 1 && canAttack)
            {
                fadeImages[3] = 1;
                anim.SetInteger("Atk", 4);
                playerEnergy.takeEnergy(fireShieldSkillCost);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && playerEnergy.energy > healSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[4] != 1 && canAttack)
            {
                fadeImages[4] = 1;
                anim.SetInteger("Atk", 5);
                playerEnergy.takeEnergy(healSkillCost);
            }
        }
        else if (Input.GetMouseButtonDown(1) && playerEnergy.energy >= lightlingSkillCost)
        {
            playerMove.TargetPosition = transform.position;

            if (playerMove.FinishedMovement && fadeImages[5] != 1 && canAttack)
            {
                fadeImages[5] = 1;
                anim.SetInteger("Atk", 6);
                playerEnergy.takeEnergy(lightlingSkillCost);
            }
        }
        else
        {
            anim.SetInteger("Atk", 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 targetPos = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPos - transform.position), 15f * Time.deltaTime);

        }

    }

    void CheckToFade(){

        if (fadeImages[0] == 1)
        {
            if (FadeAndWait(fillWaitImage_1, 1.0f))
            {
                fadeImages[0] = 0;
            }
        }

        if (fadeImages[1] == 1)
        {
            if (FadeAndWait(fillWaitImage_2, 0.7f))
            {
                fadeImages[1] = 0;
            }
        }

        if (fadeImages[2] == 1)
        {
            if (FadeAndWait(fillWaitImage_3, 0.1f))
            {
                fadeImages[2] = 0;
            }
        }

        if (fadeImages[3] == 1)
        {
            if (FadeAndWait(fillWaitImage_4, 0.2f))
            {
                fadeImages[3] = 0;
            }
        }

        if (fadeImages[4] == 1)
        {
            if (FadeAndWait(fillWaitImage_5, 0.3f))
            {
                fadeImages[4] = 0;
            }
        }

        if (fadeImages[5] == 1)
        {
            if (FadeAndWait(fillWaitImage_6, 0.08f))
            {
                fadeImages[5] = 0;
            }
        }

    }

    bool FadeAndWait(Image fadeImg, float fadeTime){

        bool faded = false;

        if (fadeImg == null)
        {
            return faded;
        }

        if (!fadeImg.gameObject.activeInHierarchy)
        {
            fadeImg.gameObject.SetActive(true);
            fadeImg.fillAmount = 1f;
        }

        fadeImg.fillAmount -= fadeTime * Time.deltaTime;

        if (fadeImg.fillAmount <= 0.0f)
        {
            fadeImg.gameObject.SetActive(false);
            faded = true;
        }

        return faded;
    }

}
