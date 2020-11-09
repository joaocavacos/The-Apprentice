using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{
    [SerializeField] private float currentMana;

    public Slider manaSlider;

    void Awake()
    {
        currentMana = manaSlider.value;
    }

    public float CurrentMana
    {
        get => currentMana;
        set
        {
            if (value > manaSlider.maxValue) currentMana = manaSlider.maxValue;
            if (value < manaSlider.maxValue) currentMana = value;
            else if (value <= manaSlider.minValue) value = 0;
        }
    }

    public void UseAbility(float manaUsage)
    {
        currentMana -= manaUsage;
    }
}
