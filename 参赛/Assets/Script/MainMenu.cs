using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject op;


    // Start is called before the first frame update
    private void Start()
    {
    }
    public void PlayeGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public void GameOpion()
    {
        op.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitOp()
    {
        op.SetActive(false);
    }
}
