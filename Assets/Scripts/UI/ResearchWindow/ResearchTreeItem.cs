using DefenceOfTheHole.Data;
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
        private readonly int _researchId;

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

        public ResearchTreeItem(int researchId) : this()
        {
            _researchId = researchId;

            UserResearchesRepo.LevelIncreased += OnResearchLevelIncreased;
            BindResearch();
            RegisterCallback<ClickEvent>(HandleClick);
        }

        private ResearchDetail Detail => _detail ??= GetDetail();

        private void OnResearchLevelIncreased(UserResearch userResearch)
        {
            if (userResearch.ResearchId == _researchId)
            {
                _levelBox.CurrentLevel = userResearch.Level;
            }

            var research = ResearchesRepo.Get(_researchId);
            if (research.Parent != null && research.Parent.Id == userResearch.ResearchId)
            {
                SetEnabled(userResearch.IsLevelMax);
            }
        }

        private void BindResearch()
        {
            var research = ResearchesRepo.Get(_researchId);
            _preview.image = research.Preview;
            _titleField.text = research.Title;

            var userResearch = UserResearchesRepo.Get(UsersRepo.CurrentUserId, _researchId);
            _levelBox.CurrentLevel = userResearch.Level;

            if (research.Parent != null)
            {
                var parentUserResearch = UserResearchesRepo.Get(UsersRepo.CurrentUserId, research.Parent.Id);
                SetEnabled(parentUserResearch.IsLevelMax);
            }
        }

        private void HandleClick(ClickEvent e)
        {
            Detail.SetResearchId(_researchId);
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
