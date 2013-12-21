using UnityEngine;
using System.Collections;

abstract public class TacticInterface : MonoBehaviour
{
    abstract public void Notify (TacticNotification n);
    abstract public bool IsSuccess();
    abstract public bool IsFail();
}
