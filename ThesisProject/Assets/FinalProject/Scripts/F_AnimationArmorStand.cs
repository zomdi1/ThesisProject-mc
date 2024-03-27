using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_AnimationArmorStand : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        if (GetComponent<Animation>().isPlaying)
        {
            return;
        }
        GetComponent<Animation>().Play();
    }

   
}
