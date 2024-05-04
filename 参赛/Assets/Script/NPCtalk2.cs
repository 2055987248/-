using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCtalk2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogBox;
    public TextAsset dialogText;
    public Text Npctext;
    public float textSpeed;
    public Image Playerimage;
    public Image NPC1image;
    public GameObject Out;
    public GameObject In;
    public Animator animator;
    public int index_1;

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
        if (index == textList.Count)
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
            if (ima_index == 2)
            {
                Out.SetActive(true);
                In.SetActive(true);
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

        AsyncOperation async = SceneManager.LoadSceneAsync(index_1);
        async.completed += OnLoadScene;
    }

    private void OnLoadScene(AsyncOperation obj)
    {
        animator.SetBool("FadeIn", false);
        animator.SetBool("FadeOut", true);
    }
}
