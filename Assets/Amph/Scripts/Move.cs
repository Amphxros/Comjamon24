using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [SerializeField] float limit;
    [SerializeField] float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKeyDown|| transform.position.y > limit)
        {
            onCreditsFinished();
        }
        else
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }


        
    }

    public void onCreditsFinished()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
