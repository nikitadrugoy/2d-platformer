using System;
using Animation;
using Player.Interfaces;
using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _speed = 1f;

        private SpriteAnimator _spriteAnimator;
        private IStateMachine _stateMachine;
        private IPlayerInput _playerInput;
        
        private float _groundLevel = 0f;
        private float _yVelocity = 0f;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public float Speed => _speed;
        public float GroundLevel => _groundLevel;

        private void Awake()
        {
            LoadAnimations();
            InitStateMachine();
        }

        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);
            _spriteAnimator.Update();
        }

        public void StartAnimation(Track track, bool loop)
        {
            _spriteAnimator.StartAnimation(_spriteRenderer, track, loop, 10);
        }

        public bool IsGrounded()
        {
            return Position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }

        public void Move(float velocity)
        {
            transform.position += Vector3.right * velocity * Time.deltaTime * _speed;
        }

        private void LoadAnimations()
        {
            var config = Resources.Load<SpriteAnimationsConfig>("PlayerAnimations");

            _spriteAnimator = new SpriteAnimator(config);
        }

        private void InitStateMachine()
        {
            _playerInput = new PlayerInput();
            _stateMachine = new StateMachine();
            _stateMachine.SetState(new Idle(_stateMachine, _playerInput, this));
        }
    }
}