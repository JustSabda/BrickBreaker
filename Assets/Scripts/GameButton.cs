using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Playlevel1Btn()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Playlevel2Btn()
    {
        SceneManager.LoadScene("Level2");
    }
    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
