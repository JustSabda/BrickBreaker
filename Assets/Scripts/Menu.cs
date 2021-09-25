using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject creditPanel;
    public GameObject levelPanel;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        creditPanel.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MenuBtn()
    {
        menuPanel.SetActive(true);
        levelPanel.SetActive(false);
        creditPanel.SetActive(false);
    }
    public void LevelBtn()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(true);
        creditPanel.SetActive(false);
    }
    public void CreditBtn()
    {
        menuPanel.SetActive(false);
        levelPanel.SetActive(false);
        creditPanel.SetActive(true);
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
}
