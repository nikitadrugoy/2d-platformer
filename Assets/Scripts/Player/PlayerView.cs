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
        private PlayerController _playerController;

        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public float Speed => _speed;

        private void Awake()
        {
            _playerController = new PlayerController(this);
            
            LoadAnimations();
            InitStateMachine();
        }

        private void Start()
        {
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Idle, true, 10);
        }

        private void Update()
        {
            _stateMachine.Update(Time.deltaTime);
            _spriteAnimator.Update();
        }

        private void LoadAnimations()
        {
            var config = Resources.Load<SpriteAnimationsConfig>("PlayerAnimations");

            _spriteAnimator = new SpriteAnimator(config);
        }

        private void InitStateMachine()
        {
            var input = new PlayerInput();

            _stateMachine = new StateMachine();
            _stateMachine.SetState(new Idle(_stateMachine, input, this));
        }
    }
}