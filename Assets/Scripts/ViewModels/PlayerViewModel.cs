using Interfaces;
using Models;
using UnityEngine;
using ViewModels.Interfaces;

namespace ViewModels
{
    public class PlayerViewModel : IViewModel, IFixedUpdatable
    {
        private readonly PlayerModel _model;
        private readonly Rigidbody2D _rigidbody;

        private float _speed = 240f;

        public PlayerViewModel(PlayerModel model, Rigidbody2D rigidbody)
        {
            _model = model;
            _rigidbody = rigidbody;
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _rigidbody.velocity = new Vector2(
                Time.fixedDeltaTime * _speed * Input.GetAxis("Horizontal"),
                _rigidbody.velocity.y
            );
        }
    }
}