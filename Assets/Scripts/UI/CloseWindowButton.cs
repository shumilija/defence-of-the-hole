using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI
{
    /// <summary>
    /// Компонент кнопки для закрытия модального окна.
    /// </summary>
    [UxmlElement]
    public partial class CloseWindowButton : Button
    {
        private VisualElement _window;

        private VisualElement Window => _window ??= GetWindow();

        public CloseWindowButton()
            : base()
        {
            RegisterCallback<ClickEvent>(e =>
            {
                Window.SetEnabled(false);
            });
        }

        private VisualElement GetWindow()
        {
            VisualElement root = this;
            while (root.parent != null)
            {
                root = root.parent;
            }

            return root.Q<VisualElement>("Window");
        }
    }
}
