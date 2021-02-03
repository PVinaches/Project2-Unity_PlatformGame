using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image imageFill;

    // Set the initial health to the maximum
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        imageFill.color = gradient.Evaluate(1f);
    }

    // Update the health bar while loosing/gaining it
    public void SetHealth(float health)
    {
        slider.value = health;

        imageFill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
