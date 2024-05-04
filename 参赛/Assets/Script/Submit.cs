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
        if (txt00.text == "·¡" && txt01.text == "Æâ" && txt02.text == "Â½"
            && txt10.text == "¾Á" && txt21.text == "Èþ")
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
        if (txt00.text == "·¡Ê°" && txt01.text == "ËÁ" && txt02.text == "Ê°"
            && txt10.text == "Ò¼°Ù" && txt21.text == "·¡")
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
        if (txt00.text == "·¡" && txt01.text == "Èþ" && txt02.text == "Èþ"
            && txt10.text == "ËÁ" && txt21.text == "Â½" && txt6.text == "ËÁ")
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
