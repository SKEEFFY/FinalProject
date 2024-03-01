using UnityEngine;

public class RaycastAllExample : MonoBehaviour
{
    private RaycastHit2D[] _hits = new RaycastHit2D[5];

    void Update() {
        var origin = transform.position;
        
        //order is not guaranteed
        Physics2D.RaycastNonAlloc(origin, Vector2.down, _hits);
    }
}
