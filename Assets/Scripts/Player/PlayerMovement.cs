using System;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        // [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private float _speed;

        private Vector2 _direction;

        public void Move(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(
                Time.fixedDeltaTime * _speed * _direction.x,
                _rigidbody.velocity.y
            );
        }
    }
}