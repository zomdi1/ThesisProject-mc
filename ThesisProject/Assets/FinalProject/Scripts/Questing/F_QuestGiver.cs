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

    private void Start()
    {
        for (int i = 0;i < quest.goals.Count;i++) {
            quest.goals[i].Init();
        }
    }
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
        rewardText.text = "Reward: " + quest.reward.ToString() + " gold";
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
        quest.isActive = true;
        GameObject.FindWithTag("Player").GetComponent<F_PlayerQuests>().activeQuests.Add(quest);
    }
}
