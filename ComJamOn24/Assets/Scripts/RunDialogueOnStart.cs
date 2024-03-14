using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RunDialogueOnStart : MonoBehaviour
{
    [SerializeField] string startingNode;
    bool talked = false;
    void Start()
    {
        GameManager.Instance.dialogueSys.StartDialogue(startingNode);
        Invoke("talk", 1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (talked && !GameManager.Instance.dialogueSys.IsDialogueRunning)
        {
            OnDialogueFinished();
        }
    }

    public abstract void OnDialogueFinished();
    private void talk()
    {
        talked = true;
    }
}
