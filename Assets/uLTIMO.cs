using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uLTIMO : MonoBehaviour
{
    [SerializeField]
    private GameManagerSO gM;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //gM.OnTodoListo += ActivarANim;
    }

    private void ActivarANim()
    {
        anim.SetTrigger("DALE");
    }

    public void TerminaAnim()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
}
