using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public int index_1;
    public int time_start;

    private void Awake()
    {
        if (!gameObject.CompareTag("End"))
            StartCoroutine(LoadScene());
    }

    public void S()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(time_start);
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);

        yield return new WaitForSeconds(1);
        
        AsyncOperation async = SceneManager.LoadSceneAsync(index_1);
        async.completed += OnLoadScene;
    }

    private void OnLoadScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
