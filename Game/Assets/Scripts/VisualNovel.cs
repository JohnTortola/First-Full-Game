using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualNovel : MonoBehaviour
{
    [SerializeField]
    StateControl stateFirst;
    StateControl[] states;

    [SerializeField]
    GameObject canvas;

    StateControl state;
    public TextInfo textInfo;

    [SerializeField]
    Button buttonOne;
    [SerializeField]
    Button buttonTwo;
    [SerializeField]
    Button buttonThree;
    public bool update;

    [SerializeField]
    bool forceStart;

    public void TextUpdate(bool isGameOn)
    {
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
        if (forceStart || isGameOn == false)
        {
            state = stateFirst;
            states = state.getStates();
        }
        else
        {
            states = state.getStates();

            if (states.Length > 1) //se tiver escolhas
            {
                string[] btnText = state.getBtnText();
                switch (states.Length)
                {
                    case 2:
                        buttonOne.gameObject.SetActive(true);
                        buttonOne.GetComponentInChildren<TextMeshProUGUI>().text = btnText[0];
                        buttonOne.onClick.AddListener(StateLoadOne);

                        buttonTwo.gameObject.SetActive(true);
                        buttonTwo.GetComponentInChildren<TextMeshProUGUI>().text = btnText[1];
                        buttonTwo.onClick.AddListener(StateLoadTwo);

                        buttonThree.gameObject.SetActive(false);
                        
                        break;
                    case 3:
                        buttonOne.gameObject.SetActive(true);
                        buttonOne.GetComponentInChildren<TextMeshProUGUI>().text = btnText[0];
                        buttonOne.onClick.AddListener(StateLoadOne);

                        buttonTwo.gameObject.SetActive(true);
                        buttonTwo.GetComponentInChildren<TextMeshProUGUI>().text = btnText[1];
                        buttonTwo.onClick.AddListener(StateLoadTwo);

                        buttonThree.gameObject.SetActive(true);
                        buttonThree.GetComponentInChildren<TextMeshProUGUI>().text = btnText[2];
                        buttonThree.onClick.AddListener(StateLoadThree);
                        break;
                    default:
                        break;
                }
            }
            else if(states.Length == 1)
            {
                buttonOne.gameObject.SetActive(false);
                buttonTwo.gameObject.SetActive(false);
                buttonThree.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    state = states[0];
                }
            }

        }
        textInfo.textMain.text = state.getText();
        textInfo.text = textInfo.textMain.text;
        textInfo.textMain.fontSize = textInfo.textMainSize;
        textInfo.textMain.font = textInfo.textMainFont;
        textInfo.textMain.alignment = textInfo.textMainAlignment;
    }

    void StateLoadOne()
    {
        state = states[0];
    }
    void StateLoadTwo()
    {
        state = states[1];
    }
    void StateLoadThree()
    {
        state = states[2];
    }


    void Start()
    {
        state = stateFirst;
    }

    void Update()
    {
        forceStart = false;
        update = false;
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
