using System;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [NonSerialized] public bool IsClick;

    public void Click()
    {
        IsClick = true;
    }
}
