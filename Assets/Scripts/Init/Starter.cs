using System;
using Controls;
using Models;
using UnityEngine;
using Views.Player;

namespace Init
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;

        private Initializer _initializer;

        private void Awake()
        {
            var playerModel = new PlayerModel();
            var input = new PlayerInput();

            _playerView.Init(playerModel, input);

            _initializer = new Initializer(_playerView.ViewModel);
        }

        private void Update()
        {
            _initializer.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _initializer.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}