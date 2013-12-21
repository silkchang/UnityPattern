using UnityEngine;
using System.Collections;

abstract public class TacticProgressInterface : TacticInterface
{
    protected TacticNotificationKind mKind = TacticNotificationKind.NONE;

    override public void Notify (TacticNotification n)
    {
        if (n.Kind == mKind) {
            Accept(n);
        }
    }

    abstract protected void Accept(TacticNotification n);
}
