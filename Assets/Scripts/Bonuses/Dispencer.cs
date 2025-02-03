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

        /// <summary>
        /// Выдать бонус игроку.
        /// </summary>
        public void Activate()
        {
            Debug.Log("Бонус активирован!");

            _activated?.Invoke();
        }

        /// <summary>
        /// Забрать бонус у игрока.
        /// </summary>
        public void Disactivate()
        {
            Debug.Log("Бонус дезактивирован!");

            _disactivated?.Invoke();
        }
    }
}
