using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene() => SceneManager.LoadScene(gameObject.name == "menu" || gameObject.name == "menuBtn" ? 0 : 1);
    
    public void CloseApp() => Application.Quit();
}
