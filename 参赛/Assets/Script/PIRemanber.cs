using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PIRemanber : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField P;
    public Image One;
    public Image Two;
    public Image Three;
    public Image Four;
    public Image Five;
    public Image Six;
    public Image Seven;
    public Image Eight;
    public Image Nine;
    public Image Ten;

    private List<Image> Time;

    private void Start()
    {
        
        Time = new List<Image>();
        Time.Add(Ten);
        Time.Add(Nine);
        Time.Add(Eight);
        Time.Add(Seven);
        Time.Add(Six);
        Time.Add(Five);
        Time.Add(Four);
        Time.Add(Three);
        Time.Add(Two);
        Time.Add(One);
    }
    public void StartPI()
    {
        P.text = "3.1415926535897932384626433832795 ";
        P.interactable = false;
        StartCoroutine(PI());
    }

    IEnumerator PI()
    {
        for (int i = 0;i < 10;i++)
        {
            Time[i].gameObject.SetActive(true);

            yield return new WaitForSeconds(1);

            Time[i].gameObject.SetActive(false);
        }

        P.interactable = true;
        P. text = "";
    }
}
