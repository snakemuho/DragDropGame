using System;
using UnityEngine;

namespace DragDropGame.Items.Components
{
    public class SnapComponent : MonoBehaviour
    {
        private CollisionTracker _collisionTracker;
        
        public Action OnSnapToFloor;
        public Action<Vector2> OnSnapToFurniture;
        
        public void Initialize(CollisionTracker collisionTracker)
        {
            _collisionTracker = collisionTracker;
        }

        public void SnapToClosestFurniture()
        {
            if (_collisionTracker.OverlappingFurniture.Count == 0) return;

            Collider2D closestFurniture = null;
            float closestDistance = float.MaxValue;

            closestFurniture = FindClosestFurniture(closestDistance, closestFurniture);

            if (closestFurniture != null)
            {
                Vector2 targetPosition = new Vector2(
                    closestFurniture.ClosestPoint(transform.position).x,
                    closestFurniture.bounds.min.y
                );
                OnSnapToFurniture?.Invoke(targetPosition);
            }
        }

        private Collider2D FindClosestFurniture(float closestDistance, Collider2D closestFurniture)
        {
            foreach (var furniture in _collisionTracker.OverlappingFurniture)
            {
                float distance = Vector2.Distance(transform.position, furniture.bounds.center);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestFurniture = furniture;
                }
            }

            return closestFurniture;
        }

        public void SnapToFloor()
        {
            OnSnapToFloor?.Invoke();
        }
    }
}