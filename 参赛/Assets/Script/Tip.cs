using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    public Image TipI;
    public Text TipText;
    public string TipT;
    private bool IsTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsTouch)
        {
            TipText.text = TipT;
            TipI.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E) && IsTouch)
        {
            TipI.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            IsTouch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouch = false;
    }
}
