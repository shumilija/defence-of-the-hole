using UnityEngine;
using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI.ResearchWindow
{
    /// <summary>
    /// Компонент для отображения детальной информации об исследовании.
    /// </summary>
    [UxmlElement]
    public partial class ResearchDetail : VisualElement
    {
        private const string _UssClassName = "research-detail";
        private const string _ResourcePath = "UI/ResearchDetail/research-detail";

        private readonly Image _preview;
        private readonly ResearchLevelBox _levelBox;
        private readonly Label _titleField;
        private readonly Label _descriptionField;
        private readonly Button _examineButton;

        private Research _activeResearch;

        public ResearchDetail()
        {
            AddToClassList(_UssClassName);

            var uxml = Resources.Load<VisualTreeAsset>(_ResourcePath);
            uxml.CloneTree(this);

            _preview = this.Q<Image>("Preview");
            _levelBox = this.Q<ResearchLevelBox>("LevelBox");
            _titleField = this.Q<Label>("Title");
            _descriptionField = this.Q<Label>("Description");
            _examineButton = this.Q<Button>("ExamineButton");

            _examineButton.RegisterCallback<ClickEvent>(HandleExamineButtonClick);

            SetEnabled(false);
        }

        /// <summary>
        /// Перебиндить модель исследования.
        /// </summary>
        /// <param name="newResearch">Новая модель исследования.</param>
        public void RebindResearch(Research newResearch)
        {
            ClearBinding();
            SetEnabled(newResearch != null);
            BindResearch(newResearch);

            _activeResearch = newResearch;
        }

        private void ClearBinding()
        {
            if (_activeResearch != null)
            {
                _activeResearch.LevelUp -= HandleLevelUp;
            }
        }

        private void BindResearch(Research newResearch)
        {
            if (newResearch == null)
            {
                Debug.LogWarning("Произведена попытка забиндить null вместо корректной модели исследования.");

                return;
            }

            _preview.image = newResearch.Preview;
            _levelBox.CurrentLevel = newResearch.CurrentLevel;
            _titleField.text = newResearch.Title;
            _descriptionField.text = newResearch.Description;
            _examineButton.SetEnabled(!newResearch.IsCurrentLevelMax);

            newResearch.LevelUp += HandleLevelUp;
        }

        private void HandleExamineButtonClick(ClickEvent e)
        {
            _activeResearch.TryIncreaseLevel(1);
        }

        private void HandleLevelUp(int level, bool isLevelMax)
        {
            _levelBox.CurrentLevel = level;
            _examineButton.SetEnabled(!isLevelMax);
        }
    }
}
