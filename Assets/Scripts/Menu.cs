using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PanelToHide;
    public GameObject PanelToShow;
    public void LoadScene() => SceneManager.LoadScene(gameObject.name == "menu" || gameObject.name == "menuBtn" ? 0 : 1);

    public void CloseApp() => Application.Quit();

    public void ReturnToMenu()
    {
        PanelToHide.SetActive(false);
        PanelToShow.SetActive(true);
    }
}