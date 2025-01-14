using System;
using UnityEngine;

namespace DragDropGame.Items.Components
{
    public class DragComponent : MonoBehaviour
    {
        private Vector2 _dragOffset;
        
        public bool IsDragging { get; private set; }

        public Action OnStartDragging;
        public Action OnStopDragging;

        public void StartDragging(Vector2 touchPosition)
        {
            IsDragging = true;
            _dragOffset = (Vector2)transform.position - touchPosition;
            OnStartDragging?.Invoke();
        }

        public void Drag(Vector2 touchPosition)
        {
            transform.position = touchPosition + _dragOffset;
        }

        public void StopDragging()
        {
            IsDragging = false;
            OnStopDragging?.Invoke();
        }
    }
}