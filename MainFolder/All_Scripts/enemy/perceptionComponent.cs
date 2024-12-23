using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perceptionComponent : MonoBehaviour
{
    [SerializeField] senseComp[] senseComps;
    LinkedList<perception> currentlyPerceviedsStimulis = new LinkedList<perception>(); 

    perception targetStimuli;

    public delegate void OnPerceptionTargetChanged(GameObject target, bool sense);

    public event OnPerceptionTargetChanged targetChanged;
    // Start is called before the first frame update
    void Start()
    {
        foreach (senseComp sense in senseComps)
        {
            sense.onPerpectionUpdated += senseUpdated;
        }
    }

    private void senseUpdated(perception stimulis, bool MovafaghiatAmizBod)
    {
        var nodeFound = currentlyPerceviedsStimulis.Find(stimulis);

       if (MovafaghiatAmizBod)
       {
            if (nodeFound != null)
            {
                currentlyPerceviedsStimulis.AddAfter(nodeFound, stimulis);
            }
            else
            {
                currentlyPerceviedsStimulis.AddLast(stimulis);
            }
       }
        else
        {
            currentlyPerceviedsStimulis.Remove(nodeFound); 
        }

        if( currentlyPerceviedsStimulis.Count != 0 )
        {
            perception hightestStimuli = currentlyPerceviedsStimulis.First.Value;
            if (targetStimuli ==  null || targetStimuli != hightestStimuli)
            {
                targetStimuli = hightestStimuli;
                targetChanged?.Invoke(targetStimuli.gameObject, true);
            }
            else
            {
              if(targetStimuli != null)
                {
                    targetChanged?.Invoke(targetStimuli.gameObject, false);
                    targetStimuli = null;                  
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
