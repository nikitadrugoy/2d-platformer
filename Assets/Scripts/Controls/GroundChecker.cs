using Controls.Interfaces;
using UnityEngine;

namespace Controls
{
    public class GroundChecker : IGroundChecker
    {
        private readonly Collider2D _collider;
        private readonly LayerMask _floorLayerMask;
        private readonly float _groundedThrash = 0.05f;

        public bool IsGrounded => Check();

        public GroundChecker(Collider2D collider, LayerMask floorLayerMask)
        {
            _collider = collider;
            _floorLayerMask = floorLayerMask;
        }

        private bool Check()
        {
            Bounds bounds = _collider.bounds;
            RaycastHit2D hit = Physics2D.BoxCast(
                bounds.center, 
                bounds.size, 
                0f, 
                Vector2.down, 
                bounds.extents.y + _groundedThrash, 
                _floorLayerMask
            );
            
            return hit.collider != null;
        }
    }
}