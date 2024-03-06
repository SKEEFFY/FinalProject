using UnityEngine;

public class PlayerMass : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlayerControll _playerControll;
    [SerializeField] private CharacterController ch_controller;
    [SerializeField] private float _force = 100f;
    [SerializeField] private float _offset;
    [SerializeField] private float radius;

    private Collider[] _colliders = new Collider[1];

    private void FixedUpdate()
    {
        Physics.OverlapSphereNonAlloc(transform.position - new Vector3(0, _offset, 0), radius, _colliders , layerMask);

        if (_colliders[0])
        {
            foreach (var collider in _colliders)
            {
                Rigidbody rigidForce;
                if(collider.TryGetComponent<Rigidbody>(out rigidForce))
                {
                    rigidForce.velocity += new Vector3(0, _playerControll.GetGravityForce() * _force, 0); ;
                }
            }
        }
        _colliders[0] = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * -_offset), radius);
        Gizmos.DrawRay(transform.position, -transform.up);
    }
}
