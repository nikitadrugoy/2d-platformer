using Animation;
using Player.Interfaces;
using UnityEngine;

namespace Player.States
{
    public class Jump : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerInput _playerInput;
        private readonly PlayerView _playerView;
        private readonly float _startVelocity = 5f;
        
        private float _velocity;
        private float _gForce = -9.8f;

        public Jump(IStateMachine stateMachine, IPlayerInput playerInput, PlayerView playerView)
        {
            _stateMachine = stateMachine;
            _playerInput = playerInput;
            _playerView = playerView;
        }

        public void Enter()
        {
            if (_playerView.IsGrounded() && _velocity == 0f)
            {
                _velocity = _startVelocity;
                
                _playerView.StartAnimation(Track.Jump, true);
            }
        }

        public void Update(float deltaTime)
        {
            _playerView.Move(_playerInput.MovingVelocity);
            
            if (_playerView.IsGrounded() && _velocity < 0)
            {
                _velocity = 0;
                _playerView.Position = new Vector3(
                    _playerView.Position.x, 
                    _playerView.GroundLevel,
                    _playerView.Position.z
                );
                
                _stateMachine.SetState(new Idle(_stateMachine, _playerInput, _playerView));
            }
            else
            {
                _velocity += _gForce * deltaTime;
                _playerView.Position += Vector3.up * (Time.deltaTime * _velocity);
            }
        }
    }
}