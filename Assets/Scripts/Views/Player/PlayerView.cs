using UnityEngine;
using ViewModels;
using ViewModels.Interfaces;
using Views.Interfaces;

namespace Views.Player
{
    public class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody;

        private IViewModel _viewModel;

        public Rigidbody2D Rigidbody => _rigidbody;

        public void Init(IViewModel viewModel)
        {
            _viewModel = viewModel;
        }
    }
}