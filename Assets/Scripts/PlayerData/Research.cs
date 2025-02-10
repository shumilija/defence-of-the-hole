using System;
using UnityEngine;

namespace DefenceOfTheHole.UI
{
    /// <summary>
    /// Модель исследования.
    /// </summary>
    [CreateAssetMenu(fileName = "Research", menuName = "UI/Research")]
    public class Research : ScriptableObject
    {
        private const int _MaxLevel = 3;

        [SerializeField]
        private Texture2D _preview;

        [SerializeField]
        [Range(0, _MaxLevel)]
        private int _currentLevel;

        [SerializeField]
        private string _title;

        [SerializeField]
        [TextArea]
        private string _description;

        [SerializeField]
        private Research _parent;

        /// <summary>
        /// Событие повышения уровня.
        /// </summary>
        public event Action<int, bool> LevelUp;

        /// <summary>
        /// Текстура для предпросмотра исследования.
        /// </summary>
        public Texture2D Preview => _preview;
        
        /// <summary>
        /// Текущий уровень исследования.
        /// </summary>
        public int CurrentLevel => _currentLevel;

        /// <summary>
        /// Является ли текущий уровень исследования максимальным.
        /// </summary>
        public bool IsCurrentLevelMax => _currentLevel == _MaxLevel;

        /// <summary>
        /// Заголовок исследования.
        /// </summary>
        public string Title => _title;

        /// <summary>
        /// Описание исследования.
        /// </summary>
        public string Description => _description;

        /// <summary>
        /// Исследование, которое предшествует данному в дереве исследований.
        /// </summary>
        public Research Parent => _parent;

        /// <summary>
        /// Попытаться повысить уровень исследования.
        /// </summary>
        /// <param name="value">Значение, на которое требуется повысить уровень исследования.</param>
        /// <returns>
        ///     <c>true</c>, если удалось повысить уровень исследования,
        ///     <c>false</c>, если текущий уровень исследования - максимальный.
        /// </returns>
        public bool TryIncreaseLevel(int value)
        {
            if (_currentLevel + value > _MaxLevel)
            {
                return false;
            }

            _currentLevel += value;
            LevelUp?.Invoke(CurrentLevel, IsCurrentLevelMax);

            return true;
        }
    }
}
