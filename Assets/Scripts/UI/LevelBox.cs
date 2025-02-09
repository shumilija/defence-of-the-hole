using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DefenceOfTheHole.UI
{
    /// <summary>
    /// Поле, отражающее уровень исследования.
    /// </summary>
    [UxmlElement]
    public partial class LevelBox : VisualElement
    {
        private const string _UssClassName = "level-box";
        private const int _MaxLevel = 3;

        private readonly List<VisualElement> _icons;
        private readonly List<VisualElement> _gaps;

        private int _currentLevel;
        private int _sizeOfIconsInPixels;
        private int _widthOfGapsInPixels;

        /// <summary>
        /// Текущий уровень исследования.
        /// </summary>
        [UxmlAttribute]
        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = Mathf.Clamp(value, 0, _MaxLevel) ;

                for (int i = 0; i < _icons.Count; i++)
                {
                    _icons[i].SetEnabled(i < _currentLevel);
                }
            }
        }

        /// <summary>
        /// Размер иконок в пикселях.
        /// </summary>
        [UxmlAttribute]
        public int SizeOfIconsInPixels
        {
            get => _sizeOfIconsInPixels;
            set
            {
                _sizeOfIconsInPixels = value;

                for (int i = 0; i < _icons.Count; i++)
                {
                    _icons[i].style.width = _sizeOfIconsInPixels;
                    _icons[i].style.height = _sizeOfIconsInPixels;
                }
            }
        }

        /// <summary>
        /// Ширина отступов между иконками в пикселях.
        /// </summary>
        [UxmlAttribute]
        public int WidthOfGapsInPixels
        {
            get => _widthOfGapsInPixels;
            set
            {
                _widthOfGapsInPixels = value;

                for (int i = 0; i < _gaps.Count; i++)
                {
                    _gaps[i].style.width = _widthOfGapsInPixels;
                }
            }
        }

        public LevelBox()
        {
            AddToClassList(_UssClassName);

            var uxml = Resources.Load<VisualTreeAsset>("UI/LevelBox/level-box");
            uxml.CloneTree(this);

            _icons = this
                .Query<VisualElement>("LevelIcon")
                .ToList();

            _gaps = this
                .Query<VisualElement>("Gap")
                .ToList();
        }
    }
}
