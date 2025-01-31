using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameManager manager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        manager.GameOver();
    }
}
