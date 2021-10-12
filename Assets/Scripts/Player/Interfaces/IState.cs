namespace Player.Interfaces
{
    public interface IState
    {
        void Enter();
        void Update(float deltaTime);
    }
}