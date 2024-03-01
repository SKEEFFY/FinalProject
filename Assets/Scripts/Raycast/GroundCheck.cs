using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _distance = 0.1f;
    [SerializeField] private LayerMask _ignoreLayers;
    
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;

    private bool _isGrounded;
    
    void Update() {
        UpdateInputs();
    }

    private bool IsGrounded() {
        var hit = Physics2D.Raycast(transform.position + _offset, Vector2.down, _distance, ~_ignoreLayers);
        
        return hit.collider != null;
    }

    private void UpdateInputs() {
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            _rb.AddForce(Vector2.up * 300); 
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        var origin = transform.position + _offset;
        Gizmos.DrawLine(origin, origin + Vector3.down * _distance);
    }
}
