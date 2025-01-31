using UnityEngine;

public class MainManager : MonoBehaviour
{
    public MainManager instance;

    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = $"{name}";
    }
}
