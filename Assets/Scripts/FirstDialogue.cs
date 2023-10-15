using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstDialogue : MonoBehaviour
{
    /*
    public string Lines;
    public TextMeshProUGUI DialogueText;

    private int Index;
    private float TextSpeed;

    // Start is called before the first frame update
    void Start()
    {
        TextSpeed = 0.1f;
        DialogueText.text = string.Empty;

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if ()
        {
            if (DialogueText == Lines[Index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = Lines[Index];
            }
        }
    }

    public void StartDialogue()
    {
        Index = 0;

        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        foreach(var Letter in Lines[Index].ToCharArray())
        {
            DialogueText.text += Letter;

            yield return new WaitForSeconds(TextSpeed);
        }
    }

    public void NextLine()
    {
        if (Index < Lines.Length - 1)
        {
            Index++;
            DialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    */
}
