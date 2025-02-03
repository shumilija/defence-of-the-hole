using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Скрипт для выдачи бонуса игроку.
    /// </summary>
    public class Dispencer : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _activated;

        [SerializeField]
        private UnityEvent _disactivated;

        private IBonus[] _bonuses;
        private IBonus _activatedBonus;

        /// <summary>
        /// Выдать бонус игроку.
        /// </summary>
        public void Activate()
        {
            _activatedBonus = _bonuses[Random.Range(0, _bonuses.Length)];
            _activatedBonus.Activate();

            _activated?.Invoke();
        }

        /// <summary>
        /// Забрать бонус у игрока.
        /// </summary>
        public void Disactivate()
        {
            _activatedBonus.Disactivate();
            _activatedBonus = null;

            _disactivated?.Invoke();
        }

        private void Start()
        {
            _bonuses = GetComponentsInChildren<IBonus>();
        }
    }
}
