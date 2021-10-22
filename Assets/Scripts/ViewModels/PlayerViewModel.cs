using Controls.Interfaces;
using Interfaces;
using Models;
using UnityEngine;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class PlayerViewModel : IViewModel, IUpdatable, IFixedUpdatable
    {
        private readonly PlayerModel _model;
        private readonly Rigidbody2D _rigidbody;
        private readonly IInput _input;

        private float _speed = 240f;
        private float _jumpForce = 5f;
        
        private bool _isGrounded;
        private bool _haveToJump;
        
        public PlayerViewModel(PlayerModel model, Rigidbody2D rigidbody, IInput input)
        {
            _model = model;
            _rigidbody = rigidbody;
            _input = input;
        }

        public void Update(float deltaTime)
        {
            if (_input.Jump)
            {
                _haveToJump = true;
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            float velocityX = fixedDeltaTime * _speed * _input.HorizontalAxis;
            float velocityY = _rigidbody.velocity.y;

            if (_haveToJump)
            {
                velocityY = _jumpForce;
                _haveToJump = false;
            }
            
            _rigidbody.velocity = new Vector2(velocityX, velocityY);
        }
    }
}