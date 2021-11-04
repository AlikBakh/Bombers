using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private int num;
    public void TaskOnClick()
    {
        num = (gameObject.name == "menu" || gameObject.name == "menuBtn") ? 0 : 1;
        SceneManager.LoadScene(num);
    }
}
