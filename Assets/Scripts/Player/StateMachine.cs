using Player.Interfaces;

namespace Player
{
    public class StateMachine : IStateMachine
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
            _state.Enter();
        }

        public void Update(float deltaTime)
        {
            _state.Update(deltaTime);
        }
    }
}