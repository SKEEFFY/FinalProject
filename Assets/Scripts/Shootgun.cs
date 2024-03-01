using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shootgun : MonoBehaviour
{
     private static int _bulletsCount = 5;
     private RaycastHit[] _raycastHits = new RaycastHit[_bulletsCount];
    
     [Range(0f,1f)][SerializeField] private float _spread = 1f;
     [SerializeField] private float _lenght = 1f;
        
     private void ShootShootgun() {
         for (var i = 0; i < _bulletsCount; i++) {
                var rndXDir = Random.Range(-_spread, _spread);
                var rndYDir = Random.Range(-_spread, _spread);

                var dir = new Vector3(rndXDir * _spread, rndYDir * _spread);
                Physics.Raycast(transform.position, dir, _lenght);

                //_raycastHits[i] = hit;
         }
     }

     private void OnDrawGizmos() {
         Gizmos.color = Color.red;

         for (var i = 0; i < _bulletsCount; i++) {
             DrawLine();
         }
     }

     private void DrawLine() {
         var rndXDir = Random.Range(-_spread, _spread);
         var rndYDir = Random.Range(-_spread, _spread);
         
         Gizmos.DrawLine(transform.position, transform.position + new Vector3(rndXDir, rndYDir, 1) * _lenght);
     }
}
