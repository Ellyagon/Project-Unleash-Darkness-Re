using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueForInteraction dialogue;

    public void TriggerDialogue ()
    {
      FindAnyObjectByType<DIalogueManager>().StartDialogue(dialogue);
    }
}
