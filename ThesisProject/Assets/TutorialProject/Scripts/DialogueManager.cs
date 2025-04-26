using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    private bool inDialogue;
    private bool isTyping;
    private Queue<SO_Dialogue.Info> dialogueQueue;
    private string completeText;
    [SerializeField] private float textDelay;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;
    private int dialogueIndex = 0;
    private int nbrOfDialgues;

    private IEnumerator TypeText(SO_Dialogue.Info info)
    {
        isTyping = true;
        foreach (char word in info.dialogue.ToCharArray())
        {
            yield return new WaitForSeconds(textDelay);
            dialogueText.text += word;
        }
        isTyping = false;
    }

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        dialogueQueue = new Queue<SO_Dialogue.Info>();
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;

        if (nbrOfDialgues - 1 > dialogueIndex)
        {
            dialogueIndex++;
        }
        else
        {
            dialogueIndex = 0;
        }
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    private void OnInteract()
    {
        if (inDialogue)
        {
            DequeueDialogue();
        }
    }

    public void QueueDialogue(SO_Dialogue[] dialogues)
    {
        nbrOfDialgues = dialogues.Length;

        if (inDialogue)
        {
            return;
        }
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        inDialogue = true;
        dialogueBox.SetActive(true);
        dialogueQueue.Clear();
        foreach (SO_Dialogue.Info line in dialogues[dialogueIndex].dialogueInfo)
        {
            dialogueQueue.Enqueue(line);
        }
        DequeueDialogue();
    }

    private void DequeueDialogue()
    {
        if (isTyping)
        {
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
        SO_Dialogue.Info info = dialogueQueue.Dequeue();
        completeText = info.dialogue;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }
}
