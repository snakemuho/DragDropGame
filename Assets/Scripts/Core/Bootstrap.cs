using DragDropGame.Gameplay;
using DragDropGame.Items;
using UnityEngine;
using VContainer;

namespace DragDropGame.Core
{
    public class Bootstrap : MonoBehaviour
    {
        private CameraScroller _cameraScroller;
        private ItemPicker _itemPicker;
        private InputHandler _inputHandler;
        private Camera _camera;
        private Item[] _items;

        [Inject]
        private void Construct(CameraScroller cameraScroller, ItemPicker itemPicker, InputHandler inputHandler)
        {
            _cameraScroller = cameraScroller;
            _itemPicker = itemPicker;
            _inputHandler = inputHandler;
        }

        private void Awake()
        {
            _camera = Camera.main;
            _inputHandler.Initialize(_cameraScroller, _itemPicker, _camera);
            _itemPicker.Initialize(_camera);

            _items = FindObjectsOfType<Item>();
            foreach (var item in _items)
            {
                item.Initialize();
            }
        }
    }
}