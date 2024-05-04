using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeLevel: MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Levelbg;
    public AudioSource LevelClick;
    public AudioSource LevelTalk;
    public Slider Menubgslider;
    public Slider MenuClickSlider;

    private void Update()
    {
        Levelbg.volume = Menubgslider.value;
        LevelClick.volume = MenuClickSlider.value;
        LevelTalk.volume = MenuClickSlider.value;
    }
}
