using UnityEngine;
using System.Collections;

public class TacticPaper : TacticDecorator<TacticProgressInterface>
{
    public int Id = 0;
    override public void Notify (TacticNotification n)
    {
        base.Notify(n);

        if (IsSuccess()) {

        }
    }
}
