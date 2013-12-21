using UnityEngine;
using System.Collections;

public class TacticBook : TacticDecorator<TacticPaper>
{
    void Awake ()
    {
        TacticTemplate.Initial();
    }

    public void AddPaper(int paperId) {
        string name = string.Format("Paper_{0}", paperId);
        GameObject go = new GameObject(name);
        TacticPaper paper = go.AddComponent<TacticPaper>();
        paper.Id = paperId;

        go.transform.parent = gameObject.transform;
    }
}
