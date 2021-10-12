namespace Player.Interfaces
{
    public interface IStateMachine
    {
        void SetState(IState state);
        void Update(float deltaTime);
    }
}