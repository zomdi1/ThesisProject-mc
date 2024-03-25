using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class F_DialogueManager : MonoBehaviour
{
    //
    public static F_DialogueManager Instance { get; private set; }
    public bool InDialogue { get; private set; }
    public bool InBuffer { get; private set; }
    public bool dialogueFinsihed = false;
    public float textDelay = 0.1f; //how fast each letter shows up on screen
    //
    private bool isTyping;
    private F_SO_Dialgue currentDialogue;
    private Queue<F_SO_Dialgue.Info> dialogueQueue;
    private string completeText;

    //UI
    public TMP_Text dialogueText;
    public GameObject dialogueBox;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        dialogueQueue = new Queue<F_SO_Dialgue.Info>();
    }

    private void Update()
    {
        if(InDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E)) //change to new input
            {
                DequeueDialogue();
            }
        }
    }

    public void QueueDialogue(F_SO_Dialgue dialogue)
    {
        dialogueFinsihed = false;
        if (InDialogue || InBuffer)
        {
            return;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        InDialogue = true;
        InBuffer = true;
        StartCoroutine(Buffer());
        currentDialogue = dialogue;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach (F_SO_Dialgue.Info line in dialogue.dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }
    public void DequeueDialogue()
    {
        if (isTyping)
        {
            if (InBuffer)
            {
                return;
            }
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        F_SO_Dialgue.Info info = dialogueQueue.Dequeue();
        completeText = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }
    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        InBuffer = true;
        StartCoroutine(Buffer());
        InDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
        dialogueFinsihed = true;
    }
    public IEnumerator Buffer()
    {
        yield return new WaitForSeconds(0.1f);
        InBuffer = false;
    }
    public IEnumerator TypeText(F_SO_Dialgue.Info info)
    {
        isTyping = true;
        foreach (char c in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += c;
        }
        isTyping = false;
    }
}
