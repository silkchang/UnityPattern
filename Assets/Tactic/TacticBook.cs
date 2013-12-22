using UnityEngine;
using System.Collections;

public class TacticBook : TacticDecorator<TacticPaper>
{
    public event System.Action OnErrorMessage;

    void Awake ()
    {
        TacticTemplate.Initial ();
    }

    public void AddPaper (int paperId)
    {
        if (!TacticTemplate.IsExistPaper(paperId)) {
            CallErrorMessage ("AddPaper : Paper not Exist");
            return;
        }

        string name = string.Format ("Paper_{0}", paperId);
        if (gameObject.transform.FindChild (name) != null) {
            CallErrorMessage ("AddPaper : Duplicate Paper");
            return;
        }

        GameObject go = new GameObject (name);
        TacticPaper paper = go.AddComponent<TacticPaper> ();
        paper.Id = paperId;

        go.transform.parent = gameObject.transform;
    }

    private void CallErrorMessage (string message)
    {
        Debug.Log (message);
        if (OnErrorMessage != null) {
            OnErrorMessage.Invoke ();
        }
    }
}
