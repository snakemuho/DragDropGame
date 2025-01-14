using UnityEngine;

namespace DragDropGame.Items.Components
{
    public class GravityComponent : MonoBehaviour
    {
        public Vector2 Velocity { get; private set; }
        
        [SerializeField] private float gravityScale = 1f;

        private bool _isFalling;

        private void FixedUpdate()
        {
            if (!_isFalling) return;

            Velocity += Physics2D.gravity * (gravityScale * Time.deltaTime);
            transform.position += (Vector3)Velocity * Time.deltaTime;
        }

        public void StartFalling()
        {
            _isFalling = true;
        }

        public void StopFalling()
        {
            Velocity = Vector2.zero;
            _isFalling = false;
        }
    }
}