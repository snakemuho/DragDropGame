using DragDropGame.Gameplay;
using VContainer;
using VContainer.Unity;

namespace DragDropGame.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<InputHandler>();
            builder.RegisterComponentInHierarchy<CameraScroller>();
            builder.RegisterComponentInHierarchy<ItemPicker>();
        }
    }
}