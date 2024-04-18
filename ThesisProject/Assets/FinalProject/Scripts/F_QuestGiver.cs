using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class F_QuestGiver : MonoBehaviour, IInteractable
{
    public F_Quest quest;
    [SerializeField] GameObject questWindow;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] TMP_Text rewardText;

    public void Interact()
    {
        OpenQuestWindow();
    }

    private void OpenQuestWindow()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description;
        rewardText.text = "Reward: " + quest.goldReward.ToString() + " gold";
    }
    public  void CloseQuestWindow()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerInput>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        questWindow.SetActive(false);

    }
    public void AcceptQuest()
    {

    }
}
