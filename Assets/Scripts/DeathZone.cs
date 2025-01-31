using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        manager.GameOver();
    }
}
