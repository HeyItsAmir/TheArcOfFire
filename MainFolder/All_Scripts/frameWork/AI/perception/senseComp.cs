using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static senseComp;

public abstract class senseComp : MonoBehaviour
{
    static List<perception> registerStimulis = new List<perception>();
    List<perception> PercivableStimulis = new List<perception> ();

    [SerializeField] float forgetTime = 7f;

    public delegate void OnPerpectionUpdated(perception stimulis, bool MovafaghiatAmizBod);

    public event OnPerpectionUpdated onPerpectionUpdated;

    Dictionary<perception, Coroutine> coroutines = new Dictionary<perception, Coroutine>();
    static public void RegisterStimulis(perception stimulis)
    {
        if (registerStimulis.Contains(stimulis))
        
            return;

            registerStimulis.Add(stimulis);
        
    }
    static public void UnRegisterStimulis(perception stimulis)
    {
        registerStimulis.Remove(stimulis);
    }

    protected abstract bool IsStimulisSensable(perception stimulis);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var stimulis in registerStimulis)
        {
            if (IsStimulisSensable(stimulis))
            {
                if(!PercivableStimulis.Contains(stimulis))
                {
                    PercivableStimulis.Add(stimulis);
                    if (coroutines.TryGetValue(stimulis, out Coroutine routine))
                    {
                        StopCoroutine(routine);
                        coroutines.Remove(stimulis);
                    }

                    else
                    {
                        onPerpectionUpdated.Invoke(stimulis,true);
                    }

                }
            }
            else
            {
                if (PercivableStimulis.Contains (stimulis))
                {
                    PercivableStimulis.Remove (stimulis);
                    coroutines.Add(stimulis, StartCoroutine(forgetStimulis(stimulis)));
                }
            }
        }
    }

    IEnumerator forgetStimulis(perception stimulis)
    {
        yield return new WaitForSeconds(forgetTime);
        coroutines.Remove(stimulis);
        onPerpectionUpdated.Invoke(stimulis, true);
    }

     protected virtual void draawDebog()
    {

    }
    private void OnDrawGizmos()
    {
        draawDebog();
    }
}
