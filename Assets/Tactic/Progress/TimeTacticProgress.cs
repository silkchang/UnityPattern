using UnityEngine;
using System.Collections;

public class TimeTacticProgress : TacticProgressInterface
{
    public int Count = 0;
    private int mAmount = 0;

    void Awake ()
    {
        mKind = TacticNotificationKind.TIMER;
    }

    override protected void Accept (TacticNotification n)
    {
        if (IsFail ()) {
            return;
        }

        mAmount ++;

        Debug.Log("TimeTacticProgress Amount :" + mAmount.ToString());
    }

    override public bool IsSuccess ()
    {
        return mAmount <= Count;
    }

    override public bool IsFail ()
    {
        return mAmount > Count;
    }
}
