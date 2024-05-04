using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource adu;
    // Start is called before the first frame update
    public void ClickPlay()
    {
        adu.Play();
    }
}
