using System;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        
        private void Update()
        {
            var horizontal = 0f;// = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.A))
            {
                horizontal -= 1f;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                horizontal += 1f;
            }

            _movement.Move(new Vector3(horizontal, 0f));
        }
    }
}