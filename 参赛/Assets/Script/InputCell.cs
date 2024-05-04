using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCell : MonoBehaviour
{
    // Start is called before the first frame update
    public Text inputText;

    private void Update()
    {
        KeyCode[] keyCodes = { KeyCode.Alpha1, KeyCode.Alpha2,
            KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, 
            KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
        foreach (KeyCode code in keyCodes)
        {
            if (Input.GetKeyDown(code))
            {
                inputText.text = code.ToString().Substring(5);
                break;
            }
        }
    }
    public void OnInputCellClicked()
    {
        Button cell = GridCell.cell;
        if (cell != null)
        {
            Text text = cell.GetComponentInChildren<Text>();
            text.text = inputText.text;
        }
    }

}
