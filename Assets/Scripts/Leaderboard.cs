using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Leaderboard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (MainManager.instance != null)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = MainManager.instance.ToString();
        }
    }
}
