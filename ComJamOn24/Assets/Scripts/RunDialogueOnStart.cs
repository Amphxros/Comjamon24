using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunDialogueOnStart : MonoBehaviour
{
    [SerializeField]string dialogueScript;
    void Start()
    {
        GameManager.Instance.dialogueSys.StartDialogue(dialogueScript);
    }

}
