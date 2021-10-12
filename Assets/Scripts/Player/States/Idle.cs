using Player.Interfaces;
using UnityEngine;

namespace Player.States
{
    public class Idle : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerInput _playerInput;
        private readonly PlayerView _playerView;

        public Idle(IStateMachine stateMachine, IPlayerInput playerInput, PlayerView playerView)
        {
            _stateMachine = stateMachine;
            _playerInput = playerInput;
            _playerView = playerView;
        }
        
        public void Enter()
        {
            
        }

        public void Update(float deltaTime)
        {
            if (_playerInput.IsMoving)
            {
                _stateMachine.SetState(new Move(_stateMachine, _playerInput, _playerView));
            }
        }
    }
}