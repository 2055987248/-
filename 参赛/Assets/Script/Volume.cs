using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Menubg;
    public AudioSource MenuClick;
    public Slider Menubgslider;
    public Slider MenuClickSlider;

    private void Update()
    {
        Menubg.volume = Menubgslider.value;
        MenuClick.volume = MenuClickSlider.value;
    }
}
