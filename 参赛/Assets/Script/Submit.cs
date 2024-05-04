using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Submit : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField txt00;
    public InputField txt01;
    public InputField txt02;
    public InputField txt10;
    public InputField txt21;
    public InputField txt6;
    public Animator animator;
    public int index;

    public void ClickSubmit1()
    {
        if (txt00.text == "��" && txt01.text == "��" && txt02.text == "½"
            && txt10.text == "��" && txt21.text == "��")
        {
            StartCoroutine(LoadScene());
        }
        else
        {
            txt00.text = "";
            txt01.text = "";
            txt02.text = "";
            txt10.text = "";
            txt21.text = "";
        }
    }

    public void ClickSubmit2()
    {
        if (txt00.text == "��ʰ" && txt01.text == "��" && txt02.text == "ʰ"
            && txt10.text == "Ҽ��" && txt21.text == "��")
        {
            StartCoroutine(LoadScene());
        }
        else
        {
            txt00.text = "";
            txt01.text = "";
            txt02.text = "";
            txt10.text = "";
            txt21.text = "";
        }
    }

    public void ClickSubmit3()
    {
        if (txt00.text.Length >=22 && txt00.text[..22] == "3.14159265358979323846")
        {
            StartCoroutine(LoadScene());
        }
        else
        {
            txt00.text = "";
        }
    }

    public void ClickSubmit4()
    {
        if (txt00.text == "��" && txt01.text == "��" && txt02.text == "��"
            && txt10.text == "��" && txt21.text == "½" && txt6.text == "��")
        {
            StartCoroutine(LoadScene());
        }
        else
        {
            txt00.text = "";
            txt01.text = "";
            txt02.text = "";
            txt10.text = "";
            txt21.text = "";
            txt6.text = "";
        }
    }

    IEnumerator LoadScene()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadScene;
    }

    private void OnLoadScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
