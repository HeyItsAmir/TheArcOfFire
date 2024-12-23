using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perception : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        senseComp.RegisterStimulis(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        senseComp.UnRegisterStimulis(this);

    }

}
