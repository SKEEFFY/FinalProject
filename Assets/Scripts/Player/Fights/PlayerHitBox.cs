using UnityEngine;
using UnityEngine.Events;

public class PlayerHitBox : MonoBehaviour
{
    public static UnityEvent PlayerHitEnemy = new();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerHitEnemy.Invoke();
        }
    }
}
