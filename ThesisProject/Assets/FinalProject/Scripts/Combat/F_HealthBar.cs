using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F_HealthBar : MonoBehaviour
{
    private Camera Camera;
    private Image healthBarImage;
    public Gradient ColorGradient;

    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        Camera = Camera.main;
        Debug.Log(Camera.main);
    }

    private void Update()
    {
        transform.LookAt(Camera.transform, Vector3.up);
    }
    public void UpdateHealthBar(float healthLeft)
    {
        Debug.Log(healthLeft);  
        healthBarImage.fillAmount = healthLeft;
        healthBarImage.color = ColorGradient.Evaluate(1 - healthBarImage.fillAmount);
    }    
}
