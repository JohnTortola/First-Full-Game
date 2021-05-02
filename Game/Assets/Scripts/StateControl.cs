using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class StateControl : ScriptableObject
{
    [TextArea(10, 15)]
    [SerializeField]
    string textMain;

    [SerializeField]
    public StateControl[] nextStates;
    public string getText()
    {
        return textMain;
    }

    public void setText(string text)
    {
        textMain = text;
    }

    public StateControl[] getStates()
    {
        return nextStates;
    }
}
