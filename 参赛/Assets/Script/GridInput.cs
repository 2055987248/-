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
        // ���������õ��ı�����
        inputField.ActivateInputField();

        // ע��һ����������������������
        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(string newValue)
    {
        // ��������Զ���������ֽ��д���
        Debug.Log("���������Ϊ��" + newValue);

        // ���������ｫ�����������ʾ���ı�����
        inputField.text = newValue;
    }
}
