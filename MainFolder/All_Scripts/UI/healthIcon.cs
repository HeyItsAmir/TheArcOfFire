using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthIcon : MonoBehaviour
{
    [SerializeField] Slider HealthSlider;

    private Transform Owner;
     
    public void Init (Transform owner)
    {
        Owner = owner;
    }

    public void setHealthSliderValue (float health, float delta, float MaxHealth)
    {
        HealthSlider.value = health/MaxHealth;
    }
    public void Update ()
    {
       Vector3 OwnerScreenPoint = Camera.main.WorldToScreenPoint (Owner.position);
        transform.position = OwnerScreenPoint; 
    }

    internal void onOwnerIsDead()
    {
        Destroy(gameObject);
    }
}
