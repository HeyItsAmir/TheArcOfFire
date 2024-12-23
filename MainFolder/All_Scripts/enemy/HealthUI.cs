using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] healthIcon healthIconToSpawn;
    [SerializeField] Transform healthBarAtttachPoint;
    [SerializeField] HealthBar healthBar;
    private void Start()
    {
        InGame ingame = FindObjectOfType<InGame>(); 
        healthIcon newHealthIcon = Instantiate(healthIconToSpawn, ingame.transform);
        newHealthIcon.Init(healthBarAtttachPoint);
        healthBar.onHealthChange += newHealthIcon.setHealthSliderValue;
        healthBar.onDeath += newHealthIcon.onOwnerIsDead;
    }
}
