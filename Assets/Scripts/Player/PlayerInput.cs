using Player.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerInput : IPlayerInput
    {
        private const string AxisX = "Horizontal";
        
        public bool IsMoving => Mathf.Abs(Input.GetAxis(AxisX)) > _movingThreshold;
        public float MovingVelocity => Input.GetAxis(AxisX);
        
        public bool JumpPressed => Input.GetKeyDown(KeyCode.Space);

        private float _movingThreshold = 0.05f;
    }
}