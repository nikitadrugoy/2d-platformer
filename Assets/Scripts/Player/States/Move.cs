using Player.Interfaces;
using UnityEngine;

namespace Player.States
{
    public class Move : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IPlayerInput _playerInput;
        private readonly PlayerView _playerView;

        public Move(IStateMachine stateMachine, IPlayerInput playerInput, PlayerView playerView)
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
            if (!_playerInput.IsMoving)
            {
                _stateMachine.SetState(new Idle(_stateMachine, _playerInput, _playerView));
            }
            else
            {
                float velocity = _playerInput.MovingVelocity * deltaTime * _playerView.Speed;
                Debug.Log(Vector3.right * velocity);
                _playerView.Position += Vector3.right * velocity;
            }
        }
    }
}