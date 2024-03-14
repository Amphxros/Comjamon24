using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComunicationDialogueRunnerToGameManager : ICommunicator {

    private DialogueRunner dialogueRunner;
    private InMemoryVariableStorage memVar;
        
    void Awake()
    { 
        dialogueRunner= GetComponent<DialogueRunner>();  
        memVar= GetComponent<InMemoryVariableStorage>();
        this.transform.parent = GameManager.Instance.gameObject.transform;
        Communicate();
    }
    public override void Communicate()
    {
            GameManager.Instance.setDialogueManager(dialogueRunner, memVar);
            Destroy(this);
        
    }

}
