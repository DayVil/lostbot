using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Manager _manager = Manager.GetInstance;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "NPCPlayer")
        {
            Time.timeScale = 0f;
            Debug.Log("You Win!");
            _manager.GameOver = true;
        }
    }
}
