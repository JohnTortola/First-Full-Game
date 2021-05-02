using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "State")]
public class StateControl : ScriptableObject
{
    [SerializeField]
    [TextArea(10, 15)]
    string textMain;


    [SerializeField]
    [TextArea(3, 5)]
    string[] btnTextAux;

    [SerializeField]
    StateControl[] nextStates;

    
    public string getText()
    { 
        return textMain;
    }

    public string[] getBtnText()
    {
        string[] btnText = new string[nextStates.Length];

        for(int i = 0; i < nextStates.Length; i++)
        {
            btnText[i] = btnTextAux[i];
        }
        return btnText; 
    }

    public StateControl[] getStates()
    {
        return nextStates;
    }

}
