using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ComunicationDialogueRunnerToGameManager : ICommunicator {

    private DialogueRunner dialogueRunner;
    private InMemoryVariableStorage memVar;
        
    void Start()
    { 
        dialogueRunner= GetComponent<DialogueRunner>();  
        memVar= GetComponent<InMemoryVariableStorage>();
        Communicate();
    }
    public override void Communicate()
    {
        if(dialogueRunner != null)
        {
            GameManager.Instance.setDialogueManager(dialogueRunner, memVar);
            DontDestroyOnLoad(this.gameObject);
            Destroy(this);
        }
    }

}
