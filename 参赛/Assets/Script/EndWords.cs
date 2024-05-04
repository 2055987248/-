using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWords : MonoBehaviour
{
    public Text txt;
    public string Endtxt;
    public float txtSpeed;
    public GameObject txtTip;

    private List<string> textList = new List<string>();
    private bool isOver;
    private void Awake()
    {
        textList.Add(Endtxt);
    }

    void Start()
    {
        isOver = false;
        StartCoroutine(SetTextUI());
    }

    private void Update()
    {
        if (isOver && Input.GetKeyDown(KeyCode.Escape))
        { 
            Application.Quit();
           
        }
    }
    // Update is called once per frame

    IEnumerator SetTextUI()
    {
        yield return new WaitForSeconds(1);
        txt.text = "";
        int word = 0;
        while ( word < textList[0].Length)
        {
            txt.text +=  textList[0][word];
            yield return new WaitForSeconds(txtSpeed);
            word++;
        }
        isOver = true;
        txtTip.SetActive(true);
    }
}
