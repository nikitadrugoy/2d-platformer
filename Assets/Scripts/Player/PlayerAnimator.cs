using System;
using Animation;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private SpriteAnimator _spriteAnimator;

        private void Awake()
        {
            var config = Resources.Load<SpriteAnimationsConfig>("PlayerAnimations");

            _spriteAnimator = new SpriteAnimator(config);
        }

        private void Start()
        {
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Idle, true, 10);
        }

        private void Update()
        {
            _spriteAnimator.Update();
        }
    }
}