using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour {

    public float energy = 10f;
    private Image energyImg;

    void Awake()
    {
        energyImg = GameObject.Find("Energy Icon").GetComponent<Image>();
    }

    public void takeEnergy( float amount )
    {
        energy -= amount;
        energyImg.fillAmount = energy / 100;
    }
}
