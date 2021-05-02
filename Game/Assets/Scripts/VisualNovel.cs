using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualNovel : MonoBehaviour
{
    [SerializeField]
    StateControl stateFirst;

    StateControl state;
    public TextInfo textInfo;

    public bool update;
    [SerializeField]
    bool updateText;
    [SerializeField]
    bool forceStart;

    public void TextUpdate(bool isGameOn)
    {
        if (forceStart || isGameOn == false)
        {
            state = stateFirst;
            StateControl[] states = state.getStates();
        }
        else
        {
            StateControl[] states = state.getStates();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = states[0];
            }else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = states[1];
            }
        }
        
        if (updateText)
        {
            state.setText(textInfo.text);
        }
        textInfo.textMain.text = state.getText();
        textInfo.text = textInfo.textMain.text;
        textInfo.textMain.fontSize = textInfo.textMainSize;
        textInfo.textMain.font = textInfo.textMainFont;
        textInfo.textMain.alignment = textInfo.textMainAlignment;
    }


    void Start()
    {
        forceStart = false;
        state = stateFirst;
        TextUpdate(true);
    }

    void Update()
    {
        TextUpdate(true);
    }
}

[System.Serializable]
public struct TextInfo
{
    public Text textMain;
    [TextArea(10,15)]
    public string text;
    public int textMainSize;
    public Font textMainFont;
    public TextAnchor textMainAlignment;
}
