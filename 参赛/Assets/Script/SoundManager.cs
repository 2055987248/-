using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip WindowOut;
    public static AudioSource audioSrc;
    public AudioSource BookClick;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        WindowOut = Resources.Load<AudioClip>("WindowOut");
    }

    // Update is called once per frame



    public static void PlayWindowOut()
    {
        audioSrc.PlayOneShot(WindowOut);
    }

    public void ClickTO()
    {
        BookClick.Play();
    }
}
