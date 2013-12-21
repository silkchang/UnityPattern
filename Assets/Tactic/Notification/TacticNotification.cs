using UnityEngine;
using System.Collections;
using System.Reflection;

public enum TacticNotificationKind {
    NONE = 0,
    TIMER,
}

public class TacticNotification
{
    private TacticNotificationKind mKind = TacticNotificationKind.NONE;

    public TacticNotificationKind Kind {
        get {
            return mKind;
        }
    }

    public TacticNotification (TacticNotificationKind kind)
    {
        mKind = kind;
    }
}
