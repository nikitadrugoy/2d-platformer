using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using ViewModels;
using Views.Interfaces;

namespace Views
{
    public class WorldGeneratorView : MonoBehaviour, IView
    {
        [SerializeField] private int _width = 20;
        [SerializeField] private int _height = 20;
        [Range(1, 100)]
        [SerializeField] private int _fillPercent = 20;
        [SerializeField] private int _smoothFactor = 2;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _tile;

        private WorldGeneratorViewModel _viewModel;

        private void Awake()
        {
            _viewModel = new WorldGeneratorViewModel();
            
            Generate();
        }

        [ContextMenu("Generate new world")]
        public void Generate()
        {
            _viewModel.Generate(_width, _height, _fillPercent, _smoothFactor, _tilemap, _tile);
        }
    }
}