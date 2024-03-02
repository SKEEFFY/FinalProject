using UnityEngine;

public class PlayerMass : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlayerControll _playerControll;
    [SerializeField] private CharacterController ch_controller;
    [SerializeField] private float _force = 100f;
    [SerializeField] private float _offset;
    [SerializeField] private float radius;

    private float _gravityForce;
    public float GravityForce 
    {
        get => _gravityForce;
        set => _gravityForce = value;
    }

    private Collider[] _colliders = new Collider[1];

    private void Update()
    {
        GamingGravity();        
    }

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
                    rigidForce.velocity += new Vector3(0, _gravityForce * _force, 0); ;
                }
            }
        }
        _colliders[0] = null;
    }

    private void GamingGravity()
    {
        if (!ch_controller.isGrounded)
        {
            _gravityForce -= 9f * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (Vector3.up * -_offset), radius);
        Gizmos.DrawRay(transform.position, -transform.up);
    }
}
