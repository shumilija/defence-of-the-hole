using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI.ResearchWindow
{
    /// <summary>
    /// Компонент для отображения дерева исследований.
    /// </summary>
    [UxmlElement]
    public partial class ResearchTree : VisualElement
    {
        private const string _UssClassName = "research-tree";
        private const string _BranchUssClassName = "branch";
        private const string _LineUssClassName = "line";
        private const string _ResourcePath = "UI/ResearchTree/research-tree";

        private Research[] _researches;
        private string _pathToResearches;
        private int _sizeOfGapsInPixels;

        public ResearchTree()
        {
            AddToClassList(_UssClassName);

            var uxml = Resources.Load<VisualTreeAsset>(_ResourcePath);
            uxml.CloneTree(this);
        }

        /// <summary>
        /// Путь до директории, где хранятся модели с исследованиями.
        /// </summary>
        [UxmlAttribute]
        public string PathToResearches
        {
            get => _pathToResearches;
            set
            {
                _pathToResearches = value;

                if (!string.IsNullOrEmpty(_pathToResearches))
                {
                    _researches = Resources.LoadAll<Research>(_pathToResearches);

                    Redraw();
                }
            }
        }

        /// <summary>
        /// Размер промежутков между элементами дерева.
        /// </summary>
        [UxmlAttribute]
        public int SizeOfGapsInPixels
        {
            get => _sizeOfGapsInPixels;
            set 
            {
                _sizeOfGapsInPixels = value;

                Redraw();
            }
        }

        private void Redraw()
        {
            Clear();

            if (_researches.Length == 0)
            {
                return;
            }

            var rootResearches = _researches
                .Where(r => r.Parent == null)
                .ToArray();
            AddBranchTo(this, rootResearches);
        }

        private void AddBranchTo(VisualElement root, Research[] researches)
        {
            var branch = new VisualElement();
            branch.AddToClassList(_BranchUssClassName);

            AddLineTo(branch, researches[0]);

            for (int i = 1; i < researches.Length; i++)
            {
                AddVerticalGapTo(branch);
                AddLineTo(branch, researches[i]);
            }

            root.Add(branch);
        }

        private void AddLineTo(VisualElement root, Research research)
        {
            var line = new VisualElement();
            line.AddToClassList(_LineUssClassName);

            AddItemTo(line, research);

            root.Add(line);
        }

        private void AddItemTo(VisualElement root, Research research)
        {
            root.Add(new ResearchTreeItem(research));

            var children = _researches
                .Where(r => r.Parent == research)
                .ToArray();

            if (children.Length > 0)
            {
                AddHorizontalGapTo(root);

                if (children.Length == 1)
                {
                    AddItemTo(root, children[0]);
                }
                else
                {
                    AddBranchTo(root, children);
                }
            }
        }

        private void AddHorizontalGapTo(VisualElement root)
        {
            var gap = new VisualElement { name = "Gap", };
            gap.style.height = new Length(100, LengthUnit.Percent);
            gap.style.width = new Length(_sizeOfGapsInPixels, LengthUnit.Pixel);

            root.Add(gap);
        }

        private void AddVerticalGapTo(VisualElement root)
        {
            var gap = new VisualElement { name = "Gap", };
            gap.style.height = new Length(_sizeOfGapsInPixels, LengthUnit.Pixel);
            gap.style.width = new Length(100, LengthUnit.Percent);

            root.Add(gap);
        }
    }
}

