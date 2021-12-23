using Controls.Interfaces;
using UnityEngine;

namespace Controls
{
    public class PlayerInput : IInput
    {
        public float HorizontalAxis => Input.GetAxis("Horizontal");
        public bool Jump => Input.GetKeyDown(KeyCode.Space);
    }
}