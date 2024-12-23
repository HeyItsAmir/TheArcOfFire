using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class compositor : BTnode
{
    LinkedList<BTnode> Children = new LinkedList<BTnode>();
    LinkedListNode<BTnode> CurrentChildern = null;

    public void addChildern(BTnode NewChildern)
    {
        Children.AddLast(NewChildern);
    }

    protected override nodeResult Execute()
    {
        if (Children.Count == 0)
        {
            return nodeResult.mofaghiatAmijz;
        }
        CurrentChildern = Children.First;
        return nodeResult.darHalAnjam;
    }


    protected BTnode GetCurrentChild() 
    {
        return CurrentChildern.Value;
    }

    protected bool Next()
    {
        if(CurrentChildern == Children.Last)
        {
            CurrentChildern = CurrentChildern.Next;
            return true;
        }
        return false;
    }
    protected override void End()
    {
        CurrentChildern = null;
    }


}
