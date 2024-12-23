using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitSense : senseComp
{

    [SerializeField] float HitMemory = 2;

    [SerializeField] HealthBar healthBar;

    Dictionary<perception, Coroutine> hitRecord = new Dictionary<perception, Coroutine>();

    protected override bool IsStimulisSensable(perception stimulis)
    {
        return hitRecord.ContainsKey(stimulis);
    }

    // Start is called before the first frame update
    void Start()
    {
        healthBar.onTakingDamage += tookDamage;
    }

    private void tookDamage(float health, float delta, float MaxHealth, GameObject Instigator)
    {
        perception stimuli = Instigator.GetComponent<perception>();
        if (stimuli != null)
        {
            Coroutine newForgeting = StartCoroutine(forgetStimuli(stimuli));
            if(hitRecord.TryGetValue(stimuli, out Coroutine onGoingCoroutine)) 
            {
                StopCoroutine(onGoingCoroutine);
                hitRecord[stimuli] = newForgeting;
            }
            else
            {
                hitRecord.Add(stimuli, newForgeting);
            }
        }
    }

    IEnumerator forgetStimuli(perception stimulis)
    {
        yield return new WaitForSeconds(HitMemory);
        hitRecord.Remove(stimulis);
    }

}
