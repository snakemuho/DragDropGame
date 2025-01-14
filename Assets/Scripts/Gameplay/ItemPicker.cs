using DragDropGame.Items;
using UnityEngine;

namespace DragDropGame.Gameplay
{
    public class ItemPicker : MonoBehaviour
    {
        [SerializeField] private LayerMask _itemLayer;

        private Camera _camera;
        private Item _currentItem;

        public bool HasPickedItem => _currentItem != null;

        public void Initialize(Camera cam)
        {
            _camera = cam;
        }

        public bool TryPickItem(Vector2 touchPosition)
        {
            Collider2D hit = Physics2D.OverlapPoint(touchPosition, _itemLayer);
            if (hit == null || !hit.TryGetComponent(out _currentItem)) return false;

            _currentItem.DragComponent.StartDragging(touchPosition);
            return true;
        }
        
        public void MovePickedItem(Vector2 inputPosition)
        {
            Vector2 worldPosition = _camera.ScreenToWorldPoint(inputPosition);
            _currentItem.DragComponent.Drag(worldPosition);
        }
        
        public void StopMovingPickedItem()
        {
            _currentItem.DragComponent.StopDragging();
            _currentItem = null;
        }
    }
}