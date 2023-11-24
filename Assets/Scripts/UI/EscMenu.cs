using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);

            Time.timeScale = menuPanel.activeSelf ? 0f : 1f;
        }
        
    }
}
