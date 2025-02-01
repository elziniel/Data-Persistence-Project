#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInputField;

    private void Start()
    {
        if (MainManager.instance != null && playerNameInputField != null)
        {
            playerNameInputField.text = MainManager.instance.playerName;
        }
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void SetPlayerName(string name)
    {
        if (MainManager.instance != null)
        {
            MainManager.instance.playerName = $"{name}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void HighScoreMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
