using UnityEngine;

namespace DragDropGame.Gameplay
{
    public class CameraScroller : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 0.01f;
        [SerializeField] private float _leftBoundary = -4.5f;
        [SerializeField] private float _rightBoundary = 4.5f;

        private Vector2 _lastTouchPosition;

        public bool IsScrolling { get; private set; }

        public void StartScrolling(Vector2 touchPosition)
        {
            _lastTouchPosition = touchPosition;
            IsScrolling = true;
        }

        public void Scroll(Vector2 touchPosition)
        {
            float deltaX = touchPosition.x - _lastTouchPosition.x;

            Vector3 newPosition = transform.position - Vector3.right * (deltaX * _scrollSpeed);
            newPosition.x = Mathf.Clamp(newPosition.x, _leftBoundary, _rightBoundary);

            transform.position = newPosition;
            _lastTouchPosition = touchPosition;
        }

        public void StopScrolling()
        {
            IsScrolling = false;
        }
    }
}