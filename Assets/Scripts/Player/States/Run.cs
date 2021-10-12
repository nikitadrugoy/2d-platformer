using Animation;
using Player.Interfaces;
using UnityEngine;

namespace Player.States
{
    public class Run : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerInput _playerInput;
        private readonly PlayerView _playerView;

        public Run(IStateMachine stateMachine, IPlayerInput playerInput, PlayerView playerView)
        {
            _stateMachine = stateMachine;
            _playerInput = playerInput;
            _playerView = playerView;
        }
        
        public void Enter()
        {
            _playerView.StartAnimation(Track.Run, true);
        }

        public void Update(float deltaTime)
        {
            if (_playerInput.JumpPressed)
            {
                _stateMachine.SetState(new Jump(_stateMachine, _playerInput, _playerView));
            }
            else if (!_playerInput.IsMoving)
            {
                _stateMachine.SetState(new Idle(_stateMachine, _playerInput, _playerView));
            }
            else
            {
                _playerView.Move(_playerInput.MovingVelocity);
            }
        }
    }
}