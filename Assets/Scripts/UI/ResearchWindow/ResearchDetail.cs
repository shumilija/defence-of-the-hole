using DefenceOfTheHole.Data;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI.ResearchWindow
{
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

        private int _activeResearchId;

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

            UserResearchesRepo.LevelIncreased += OnResearchLevelIncreased;

            SetEnabled(false);
        }

        public void SetResearchId(int researchId)
        {
            _activeResearchId = researchId;

            SetEnabled(true);
            BindResearch();
        }

        private void OnResearchLevelIncreased(UserResearch userResearch)
        {
            if (userResearch.ResearchId == _activeResearchId)
            {
                _levelBox.CurrentLevel = userResearch.Level;
                _examineButton.SetEnabled(!userResearch.IsLevelMax);
            }
        }

        private void BindResearch()
        {
            var research = ResearchesRepo.Get(_activeResearchId);
            _preview.image = research.Preview;
            _titleField.text = research.Title;
            _descriptionField.text = research.Description;

            var userResearch = UserResearchesRepo.Get(UsersRepo.CurrentUserId, _activeResearchId);
            _levelBox.CurrentLevel = userResearch.Level;
            _examineButton.SetEnabled(!userResearch.IsLevelMax);
        }

        private void HandleExamineButtonClick(ClickEvent e)
        {
            UserResearchesRepo.IncreaseLevel(UsersRepo.CurrentUserId, _activeResearchId, 1);
        }
    }
}
