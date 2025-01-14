using System;
using System.Collections.Generic;
using UnityEngine;

namespace DragDropGame.Items.Components
{
    public class CollisionTracker : MonoBehaviour
    {
        public readonly HashSet<Collider2D> OverlappingFurniture = new();
        public bool IsOnFloor { get; private set; }
        public Action OnFurnitureEnter;
        public Action OnFloorEnter;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Furniture"))
            {
                OverlappingFurniture.Add(other);
                OnFurnitureEnter?.Invoke();
            }
            else if (other.CompareTag("Floor"))
            {
                IsOnFloor = true;
                OnFloorEnter?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Furniture"))
            {
                OverlappingFurniture.Remove(other);
            }
            else if (other.CompareTag("Floor"))
            {
                IsOnFloor = false;
            }
        }
    }
}