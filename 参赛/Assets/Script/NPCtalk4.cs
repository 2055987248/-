using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCtalk4 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox;
    public TextAsset dialogText;
    public Text Npctext;
    public float textSpeed;
    public Image Playerimage;
    public Image NPC1image;
    public GameObject Out1;
    public GameObject Out2;
    public GameObject In1;
    public GameObject In2;
    public GameObject gb;
    public int index_2;
    public Animator animator;

    private bool IsPlayerTouchNPC;
    private List<string> textList = new List<string>();
    private int index;
    private bool textFinshed;
    private bool isTyping;
    private int ima_index;
    private void Awake()
    {
        GetTextFile(dialogText);
    }

    private void OnEnable()
    {
        textFinshed = false;
        index = 0;
        ima_index = 0;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (index == textList.Count && gb.CompareTag("NPC4"))
        {
            StartCoroutine(LoadScene());
            this.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerTouchNPC && index == textList.Count)
        {
            SoundManager.PlayWindowOut();
            gameObject.SetActive(false);
            Playerimage.gameObject.SetActive(false);
            NPC1image.gameObject.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerTouchNPC)
        {
            if (ima_index == 3 && gb.CompareTag("NPC4") )
            {
                Out1.SetActive(true);
                In1.SetActive(true);
            }
            if (ima_index == 6 && gb.CompareTag("NPC4"))
            {
                Out2.SetActive(true);
                In2.SetActive(true);
            }
            dialogBox.SetActive(true);
            if (ima_index % 2 ==0)
            {
                Playerimage.gameObject.SetActive(true);
            }
            else if (ima_index % 2 == 1)
            {
                NPC1image.gameObject.SetActive(true);
            }
            if (textFinshed)
            {
                StartCoroutine(SetTextUI());
                Playerimage.gameObject.SetActive(false);
                NPC1image.gameObject.SetActive(false);
            }
            else if (!textFinshed)
            {
                isTyping = false;
            }
            SoundManager.PlayWindowOut();
        }

    }

    void GetTextFile(TextAsset File)
    {
        textList.Clear();

        var Linetext = File.text.Split('\t');
        foreach (var Line in Linetext)
        {
            textList.Add(Line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinshed = false;
        Npctext.text = "";

        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            Npctext.text +=  textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }

        Npctext.text = textList[index];

        isTyping = true;
        textFinshed = true;
        index++;
        ima_index++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsPlayerTouchNPC = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        IsPlayerTouchNPC = false;
        dialogBox.SetActive(false);
    }

    IEnumerator LoadScene()
    {
        animator.SetBool("FadeIn", true);
        animator.SetBool("FadeOut", false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index_2);
        async.completed += OnLoadScene;
    }

    private void OnLoadScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
