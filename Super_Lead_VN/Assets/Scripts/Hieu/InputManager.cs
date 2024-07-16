using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public InputField inputField;
    public Text displayText;

    public void OnSendButtonClick()
    {
        string inputText = inputField.text;
    }
}
