using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthBar : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] float Health = 100f;
    [SerializeField] float MaxHealth = 100f;

    public delegate void OnHealthChange(float health, float delta, float MaxHealth);
    public delegate void OnTakingDamage(float health, float delta, float MaxHealth, GameObject Instigator);
    public delegate void OnDeath();

    public event OnHealthChange onHealthChange;
    public event OnTakingDamage onTakingDamage;
    public event OnDeath onDeath;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void ChangeHealth(float amount, GameObject Instigator)
    {
        if (amount == 0 || Health == 0)
        {
            return;
        }

        Health += amount;

        if (amount < 0)
        {
            onTakingDamage?.Invoke(Health, amount, MaxHealth, Instigator);
        }

        onHealthChange?.Invoke(Health, amount, MaxHealth);

        if (Health <= 0)
        {
            Health = 0;
            onDeath?.Invoke();
        }

        Debug.Log($"{gameObject.name} TakingDamage: {amount} Health: {Health}");
    }
    void Update()
    {
       if (Health == 0)
        {
            agent.speed = 0f;
        }  
    }

}