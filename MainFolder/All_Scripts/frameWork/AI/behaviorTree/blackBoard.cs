using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class blackBoard
{
    public delegate void OnBlackboardValueChange(string key, object value);

    public event OnBlackboardValueChange onChange;

    Dictionary<string, object> blackBoardData = new Dictionary<string, object>();


    public void SetOrAddData(string Key, object value)
    {
        if (blackBoardData.ContainsKey(Key))
        {
            blackBoardData[Key] = value;
        }
        else
        {
            blackBoardData.Add(Key, value);
        }
        onChange?.Invoke(Key, value);
    }
    public bool getBlackBoardData<T>(string key, out T Value)
    {
        Value = default(T);
        if (blackBoardData.ContainsKey(key))
        {
            Value = (T)blackBoardData[key];
            return true;
        }
        return false;
    }
    public void removeBlackBoard(string key)
    {
        blackBoardData.Remove(key);
        onChange?.Invoke(key, null);
    }
    public bool HasKey(string key)
    {
        return blackBoardData.ContainsKey(key);
    }


}

    

