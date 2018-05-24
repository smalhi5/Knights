using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {

    public float healAmount = 20f;
    public float restoreEnergy = 30f;

    void Start(){

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().HealPlayer(healAmount);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerEnergy>().RestoreEnergy(restoreEnergy);
    }
}
