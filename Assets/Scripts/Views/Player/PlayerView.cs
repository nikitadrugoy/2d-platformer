using System;
using Controls;
using Controls.Interfaces;
using Models;
using UnityEngine;
using ViewModels;
using ViewModels.Interfaces;
using Views.Interfaces;

namespace Views.Player
{
    public class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private LayerMask _platformLayer;
        
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        private PlayerViewModel _viewModel;
        
        private Vector3 _scaleRight = new Vector3(1f, 1f, 1f);
        private Vector3 _scaleLeft = new Vector3(-1f, 1f, 1f);

        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        public IViewModel ViewModel => _viewModel;

        public void Init(PlayerModel model, IInput input)
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            
            var groundChecker = new GroundChecker(_collider, _platformLayer);
            
            _viewModel = new PlayerViewModel(model, input, groundChecker);
        }

        private void OnEnable()
        {
            _viewModel.VelocityChanged += OnVelocityChanged;
        }

        private void OnDisable()
        {
            _viewModel.VelocityChanged -= OnVelocityChanged;
        }

        private void OnVelocityChanged(Vector2 velocity)
        {
            Vector2 currentVelocity = _rigidbody.velocity;

            var newVelocity = new Vector2(
                velocity.x != 0f ? velocity.x : currentVelocity.x,
                velocity.y != 0f ? velocity.y : currentVelocity.y
            );
            
            _rigidbody.velocity = newVelocity;

            _animator.SetBool(IsGrounded, _viewModel.IsGrounded);
            _animator.SetBool(IsRunning, Mathf.Abs(newVelocity.x) > 0.01f);

            transform.localScale = newVelocity.x >= 0f ? _scaleRight : _scaleLeft;
        }
    }
}