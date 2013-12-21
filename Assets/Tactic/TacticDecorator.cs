using UnityEngine;
using System.Collections;

public class TacticDecorator<T> : TacticInterface where T : TacticInterface
{
    override public void Notify (TacticNotification n)
    {
        foreach (T p in GetComponentsInChildren<T>()) {
            p.Notify (n);
        }
    }

    override public bool IsSuccess ()
    {
        foreach (T p in GetComponentsInChildren<T>()) {
            if (!p.IsSuccess ()) {
                return false;
            }
        }

        return true;
    }

    override public bool IsFail ()
    {
        foreach (T p in GetComponentsInChildren<T>()) {
            if (p.IsFail ()) {
                return true;
            }
        }
        
        return false;
    }
}
