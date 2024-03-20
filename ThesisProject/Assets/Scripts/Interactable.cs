using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactRange = 1f;
    public Vector2 offset;

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E) && !PauseMenuScript.isPaused && !DialogueManager.instance.InDialogue) //checks if player is pressing the button
    //    {
    //        if ((((Vector2)transform.position + offset) - (Vector2)References.instance.playerTransform.position).sqrMagnitude < interactRange * interactRange)
    //        //bunch of math, basically checks if player is inside range
    //        {
    //            Interact();
    //        }
    //    }
    //}
    public virtual void Interact() // this will be overridden
    {

    }
    private void OnDrawGizmosSelected() //draws the range in the scene view so you can visualize it easier
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + (Vector3)offset, interactRange);
    }
}