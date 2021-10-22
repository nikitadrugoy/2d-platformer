using System;
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
        private readonly IInput _input;
        private readonly IGroundChecker _groundChecker;

        private float _speed = 240f;
        private float _jumpForce = 5f;
        
        private bool _haveToJump;
        private bool _isGrounded;

        public event Action<Vector2> VelocityChanged;
        public bool IsGrounded => _isGrounded;
        
        public PlayerViewModel(PlayerModel model, IInput input, IGroundChecker groundChecker)
        {
            _model = model;
            _input = input;
            _groundChecker = groundChecker;
        }

        public void Update(float deltaTime)
        {
            _isGrounded = _groundChecker.IsGrounded;
            
            if (_input.Jump && _isGrounded)
            {
                _haveToJump = true;
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            float velocityX = fixedDeltaTime * _speed * _input.HorizontalAxis;
            var velocityY = 0f;

            if (_haveToJump)
            {
                velocityY = _jumpForce;
                _haveToJump = false;
            }
            
            VelocityChanged?.Invoke(new Vector2(velocityX, velocityY));
        }
    }
}