using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class behoviorTree : MonoBehaviour
{
    BTnode root;
    blackBoard blackBoard = new blackBoard();

    public blackBoard BlackBoard
    {
        get { return blackBoard; }
    }
     
    // Start is called before the first frame update
    void Start()
    {
        ConstructTree(out root);
    }
    
    protected abstract void ConstructTree(out BTnode rootNode);    
   

    // Update is called once per frame
    void Update()
    {
        root.updateNode();
    }
}
