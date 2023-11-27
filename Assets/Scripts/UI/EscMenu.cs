using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;

    private readonly Manager _manager = Manager.GetInstance;
   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);

            if(_manager.GameOver == false) 
            {
                Debug.Log("Game not over");
                Time.timeScale = menuPanel.activeSelf ? 0f : 1f;
            }
        
        }
            
    }
}
