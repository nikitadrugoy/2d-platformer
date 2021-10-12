namespace Player
{
    public class PlayerController
    {
        private float _groundLevel = 0f;
        private float _yVelocity = 0f;
        private PlayerView _playerView;

        public PlayerController(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public bool IsGrounded()
        {
            return _playerView.Position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }
    }
}