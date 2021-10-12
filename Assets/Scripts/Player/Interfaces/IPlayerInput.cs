namespace Player.Interfaces
{
    public interface IPlayerInput
    {
        bool IsMoving { get; }
        float MovingVelocity { get; }
        bool JumpPressed { get; }
    }
}