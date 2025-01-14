using DG.Tweening;
using DragDropGame.Items.Components;
using UnityEngine;

namespace DragDropGame.Items
{
    public class Item : MonoBehaviour
    {
        public DragComponent DragComponent { get; private set; }
        
        private GravityComponent _gravityComponent;
        private SnapComponent _snapComponent;
        private CollisionTracker _collisionTracker;
        private AudioComponent _audioComponent;

        private Tween _scaleTween;
        private Tween _snapToFurnitureTween;
        private Tween _snapToFloorTween;
        
        public void Initialize()
        {
            DragComponent = GetComponent<DragComponent>();
            _gravityComponent = GetComponent<GravityComponent>();
            _snapComponent = GetComponent<SnapComponent>();
            _collisionTracker = GetComponent<CollisionTracker>();
            _audioComponent = GetComponent<AudioComponent>();
            
            _snapComponent.Initialize(_collisionTracker);
            
            DragComponent.OnStartDragging += OnStartDragging;
            DragComponent.OnStopDragging += OnStopDragging;

            _snapComponent.OnSnapToFurniture += OnSnapToFurniture;
            _snapComponent.OnSnapToFloor += OnSnapToFloor;
            
            _collisionTracker.OnFurnitureEnter += CheckCollisionWithBackground;
            _collisionTracker.OnFloorEnter += CheckCollisionWithBackground;
        }

        private void OnStartDragging()
        {
            _scaleTween?.Kill();
            _snapToFloorTween?.Kill();
            _snapToFurnitureTween?.Kill();

            transform.localScale = Vector3.one * 1.1f;
            
            _gravityComponent.StopFalling();

            _audioComponent.PlayPickupSound();
        }

        private void OnStopDragging()
        {
            _scaleTween?.Kill();
            _scaleTween = transform.DOScale(Vector3.one, 0.5f);
            
            DoSnappingChecks();
        }

        private void OnSnapToFurniture(Vector2 position)
        {
            _snapToFurnitureTween?.Kill();
            _snapToFurnitureTween = transform.DOMove(position, 0.5f);
        }

        private void OnSnapToFloor()
        {
            if (_gravityComponent.Velocity.magnitude < 1) return;
            
            _snapToFloorTween?.Kill();
            _snapToFloorTween = transform.DOLocalMove(transform.position + Vector3.down * 0.05f, 0.3f).SetEase(Ease.OutBounce);
        }

        private void CheckCollisionWithBackground()
        {
            if (DragComponent.IsDragging) return;
            
            DoSnappingChecks();
            _gravityComponent.StopFalling();
        }

        private void DoSnappingChecks()
        {
            if (_collisionTracker.OverlappingFurniture.Count > 0)
            {
                _snapComponent.SnapToClosestFurniture();
            }
            else if (_collisionTracker.IsOnFloor)
            {
                _snapComponent.SnapToFloor();
            }
            else
            {
                _gravityComponent.StartFalling();
            }
        }
    }
}