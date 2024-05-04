using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    public Image p;

    public void QuitP()
    {
        p.gameObject.SetActive(false);
    }
}
