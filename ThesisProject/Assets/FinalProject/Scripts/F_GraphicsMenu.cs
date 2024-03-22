using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class F_GraphicsMenu : MonoBehaviour
{
    GameObject playerObject; //a reference to the player object to gain access to its components
    [SerializeField] TMP_Dropdown resolutionDropDown; //a reference to the player object to gain access to its components
    [SerializeField] Slider mouseSensitivitySlider;//a reference to the player object to gain access to its components
    [SerializeField] TMP_Text sensitivityValueTxt;//a reference to the player object to gain access to its components
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value; //save the value of the sensitivity slider
        sensitivityValueTxt.text = newSensitivity.ToString(); // displays the new value in text form
        playerObject.GetComponent<F_PlayerLook>().mouseSensitivity = newSensitivity; // changes the players sensitivity ingame
    }

    public void ToggleFullScreen()
    {
         Screen.fullScreen = !Screen.fullScreen;
    }
}
