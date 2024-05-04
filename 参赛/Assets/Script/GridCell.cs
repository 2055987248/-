using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    // Start is called before the first frame update
    public Text inputText;

    private bool isSelected;
    public static Button cell;

    public void OnButtonClick()
    {
        cell = GetComponent<Button>();
    }
    public void OnGridCellSelected()
    {
        isSelected = true;
    }

    public void SetNumber(string num)
    {
        if (isSelected)
        {
            inputText.text = num;
            isSelected = false;
        }
    }

}
