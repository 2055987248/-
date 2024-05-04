using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    public Image TextUI;//接收对话框UI
    public TextAsset text;//接收文本框
    public Text Box_tex;//接收对话内容
    public static bool isGetBook;
    public float textSpeed;

    private bool isEnter;
    private bool textFinshed;
    private int index;
    private List<string> textList = new List<string>();
    private bool isTyping;

    private void Awake()
    {
        GetTextFile(text);
    }

    private void OnEnable()
    {
        textFinshed = false;
        index = 0;
        StartCoroutine(SetTextUI());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isEnter && index == textList.Count )
        {
            SoundManager.PlayWindowOut();
            gameObject.SetActive(false);
            isGetBook = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) && isEnter )
        {
            TextUI.gameObject.SetActive(true);
            if (textFinshed)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinshed)
            {
                isTyping = false;
            }
            SoundManager.PlayWindowOut();
        }
    }

    void GetTextFile(TextAsset File)
    {
        textList.Clear();

        var Linetext = File.text.Split('\t');
        foreach (var Line in Linetext)
        {
            textList.Add(Line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinshed = false;
        Box_tex.text = "";
        //if (textList[index].Trim() == "???" || textList[index].Trim() == "张久")
        //{
        //    index++;
        //}

        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            Box_tex.text +=  textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }

        Box_tex.text = textList[index];

        isTyping = true;
        textFinshed = true;
        index++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextUI.gameObject.SetActive(false);
        isEnter = false;
    }
}
