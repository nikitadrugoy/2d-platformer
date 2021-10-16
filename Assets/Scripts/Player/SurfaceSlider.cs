using System;
using UnityEngine;

namespace Player
{
    public class SurfaceSlider : MonoBehaviour
    {
        private Vector2 _normal;
        
        public Vector2 Project(Vector2 direction)
        {
            return direction - Vector2.Dot(direction, _normal) * _normal;
        }

        private void OnCollisionEnter(Collision other)
        {
            _normal = other.contacts[0].normal;
        }
    }
}