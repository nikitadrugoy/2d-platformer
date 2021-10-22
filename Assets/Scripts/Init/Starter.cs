using System;
using Controls;
using Models;
using UnityEngine;
using ViewModels;
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
            var playerViewModel = new PlayerViewModel(playerModel, _playerView.Rigidbody, input);

            _playerView.Init(playerViewModel);

            _initializer = new Initializer(playerViewModel);
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