using System.Collections.Generic;
using Init.Interfaces;
using Interfaces;
using ViewModels.Interfaces;

namespace Init
{
    public class Initializer : IGameInitializer
    {
        private List<IViewModel> _viewModels;
        
        public Initializer(IViewModel playerViewModel)
        {
            _viewModels = new List<IViewModel>
            {
                playerViewModel
            };

            Init();
        }
        
        public void Init()
        {
            foreach (IViewModel viewModel in _viewModels)
            {
                if (viewModel is IInitable initable)
                {
                    initable.Init();
                }
            }
        }

        public void Update(float deltaTime)
        {
            foreach (IViewModel viewModel in _viewModels)
            {
                if (viewModel is IUpdatable updatable)
                {
                    updatable.Update(deltaTime);
                }
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            foreach (IViewModel viewModel in _viewModels)
            {
                if (viewModel is IFixedUpdatable fixedUpdatable)
                {
                    fixedUpdatable.FixedUpdate(fixedDeltaTime);
                }
            }
        }
    }
}