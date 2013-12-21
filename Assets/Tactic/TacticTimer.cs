using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TacticBook))]
public class TacticTimer : MonoBehaviour
{
    private TacticBook mBook = null;

    void Awake ()
    {
        mBook = GetComponent<TacticBook> ();
    }

    void Start ()
    {
        StartCoroutine (Notification (1));
    }

    IEnumerator Notification (int second)
    {
        yield return new WaitForSeconds (second);
        mBook.Notify(new TimeTacticNotification ());
        StartCoroutine (Notification (second));
    }
}
