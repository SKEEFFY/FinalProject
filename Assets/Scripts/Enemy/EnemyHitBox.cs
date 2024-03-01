using UnityEngine;
using UnityEngine.Events;

public class EnemyHitBox : MonoBehaviour
{
    public static UnityEvent EnemyHitPlayer = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyHitPlayer.Invoke();
        }
    }
}
