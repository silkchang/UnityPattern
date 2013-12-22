using UnityEngine;
using System.Collections;
using System.Data;

public class TacticPaper : TacticDecorator<TacticProgressInterface>
{
    public int Id = 0;

    void Start() {
        AddProgress();
    }

    override public void Notify (TacticNotification n)
    {
        base.Notify(n);

        if (IsSuccess()) {

        }
    }

    private void AddProgress() {
        DataView v = TacticTemplate.Conditions(Id);
        foreach (DataRowView r in v) {
            Debug.Log(r["Title"]);
        }
    }
}
