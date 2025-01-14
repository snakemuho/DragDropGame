using UnityEngine;

namespace DragDropGame.Gameplay
{
    public class InputHandler : MonoBehaviour
    {
        private CameraScroller _cameraScroller;
        private ItemPicker _itemPicker;
        private Camera _camera;
        private bool _isTouching;

        public void Initialize(CameraScroller cameraScroller, ItemPicker itemPicker, Camera cam)
        {
            _cameraScroller = cameraScroller;
            _itemPicker = itemPicker;
            _camera = cam;
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                HandleTouchInput();
            }
#if UNITY_EDITOR
            else
            {
                HandleMouseInput();
            }
#endif 
        }

        private void HandleTouchInput()
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnInputBegan(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnInputMoved(touch.position);
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    OnInputEnded();
                    break;
            }
        }

#if UNITY_EDITOR
        private void HandleMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnInputBegan(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                OnInputMoved(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnInputEnded();
            }
        }
#endif

        private void OnInputBegan(Vector2 inputPosition)
        {
            _isTouching = true;
            Vector2 worldPosition = _camera.ScreenToWorldPoint(inputPosition);

            if (!_itemPicker.TryPickItem(worldPosition))
            {
                _cameraScroller.StartScrolling(inputPosition);
            }
        }

        private void OnInputMoved(Vector2 screenPosition)
        {
            if (_isTouching)
            {
                if (_itemPicker.HasPickedItem)
                {
                    _itemPicker.MovePickedItem(screenPosition);
                }
                else if (_cameraScroller.IsScrolling)
                {
                    _cameraScroller.Scroll(screenPosition);
                }
            }
        }

        private void OnInputEnded()
        {
            _isTouching = false;
            if (_itemPicker.HasPickedItem)
            {
                _itemPicker.StopMovingPickedItem();
            }
            else if (_cameraScroller.IsScrolling)
            {
                _cameraScroller.StopScrolling();
            }
        }
    }
}
