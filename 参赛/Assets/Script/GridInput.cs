using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridInput : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField inputField;

    public void OnButtonClick()
    {
        // 将焦点设置到文本框上
        inputField.ActivateInputField();

        // 注册一个监听器，监听键盘输入
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string newValue)
    {
        // 在这里可以对输入的数字进行处理
        Debug.Log("输入的数字为：" + newValue);

        // 可以在这里将输入的数字显示在文本框中
        inputField.text = newValue;
    }
}
