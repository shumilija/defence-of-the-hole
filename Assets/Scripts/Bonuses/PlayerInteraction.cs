using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий с кораблем игрока.
    /// </summary>
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _interacted;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _interacted?.Invoke();
            }
        }
    }
}
