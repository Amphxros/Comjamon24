
using UnityEngine;
using Yarn.Unity;

public class GameManager : MonoBehaviour
{
    DialogueRunner dialogueRunner;
    InMemoryVariableStorage variableStorage;

    static GameManager instance;

    public static GameManager Instance {  get { return instance; } }
    public DialogueRunner dialogueSys {  get { return dialogueRunner; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void setDialogueManager(DialogueRunner dialogueRunner, InMemoryVariableStorage variableStorage)
    {
        this.dialogueRunner = dialogueRunner;
        this.variableStorage = variableStorage;
    }


}
