using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayToScene1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text t00;
    public Text t02;
    public Text t11;
    public Text t20;
    public Text t22;
    public GameObject Overtip; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t00.text == "8" && t02.text == "6" && t11.text == "5"
            && t20.text == "4" && t22.text == "2")
        {
            Overtip.SetActive(true);
            this.enabled = false;
        }
    }

    public void OnClickOver()
    {
        SceneManager.LoadScene(1);
    }
}
