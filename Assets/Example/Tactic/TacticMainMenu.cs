using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TacticBook))]
public class TacticMainMenu : MonoBehaviour
{
    private TacticBook mBook = null;

    void Awake() {
        mBook = GetComponent<TacticBook>();

        if (mBook == null) {
            mBook = gameObject.AddComponent<TacticBook>();
        }
    }

    void OnGUI() {
        GUILayoutOption[] options = new GUILayoutOption[] {
            GUILayout.Height(60),
            GUILayout.Width(180)
        };

        if (GUILayout.Button("Add Tactic Paper", options)) {
            mBook.AddPaper(1);
        }
    }
}
