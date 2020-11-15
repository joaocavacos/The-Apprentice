using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] float currentMana;
    [SerializeField] float maxMana;

    public Slider manaSlider;

    void Start()
    {
        manaSlider.value = currentMana;
        manaSlider.maxValue = maxMana;
        currentMana = maxMana;
    }

    public float CurrentMana
    {
        get => currentMana;
        set
        {
            if (value > maxMana) currentMana = maxMana;
            if (value < maxMana) currentMana = value;
            else if (value <= 0) value = 0;
        }
    }
    

    public void UseAbility(float manaUsage)
    {
        currentMana -= manaUsage;
    }
}
