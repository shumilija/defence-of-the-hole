using UnityEngine;
using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI.ResearchWindow
{
    /// <summary>
    /// Компонент для отображения информации об исследовании в дереве исследований.
    /// </summary>
    [UxmlElement]
    public partial class ResearchTreeItem : VisualElement
    {
        private const string _UssClassName = "item";
        private const string _ResourcePath = "UI/ResearchTree/research-tree-item";

        private readonly Image _preview;
        private readonly Label _titleField;
        private readonly ResearchLevelBox _levelBox;
        private readonly Research _research;

        private ResearchDetail _detail;

        public ResearchTreeItem()
        {
            AddToClassList(_UssClassName);

            var uxml = Resources.Load<VisualTreeAsset>(_ResourcePath);
            uxml.CloneTree(this);
            
            _preview = this.Q<Image>("Preview");
            _titleField = this.Q<Label>("Title");
            _levelBox = this.Q<ResearchLevelBox>("LevelBox");
        }

        public ResearchTreeItem(Research research)
            : this()
        {
            if (research == null)
            {
                return;
            }

            _research = research;

            _preview.image = research.Preview;
            _titleField.text = research.Title;
            _levelBox.CurrentLevel = research.CurrentLevel;

            research.LevelUp += (level, _) =>
            {
                _levelBox.CurrentLevel = level;
            };

            if (research.Parent != null)
            {
                SetEnabled(research.Parent.IsCurrentLevelMax);

                research.Parent.LevelUp += (_, isLevelMax) =>
                {
                    SetEnabled(isLevelMax);
                };
            }

            RegisterCallback<ClickEvent>(HandleClick);
        }

        private ResearchDetail Detail => _detail ??= GetDetail();

        private void HandleClick(ClickEvent e)
        {
            Detail.RebindResearch(_research);
        }

        private ResearchDetail GetDetail()
        {
            VisualElement root = this;
            while (root.parent != null)
            {
                root = root.parent;
            }

            return root.Q<ResearchDetail>();
        }
    }
}
