using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipBgManager : MonoBehaviour
{
    public GameObject Tipbg;


    public void SetTipbgTrue()
    {
        Tipbg.SetActive(true);
    }

    public void SetTipbgFalse()
    {
        Tipbg.SetActive(false);
    }
}
