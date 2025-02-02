using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Bullets
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий снаряда с врагом.
    /// </summary>
    public class EnemyInteraction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _interacted;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                _interacted?.Invoke();
            }
        }
    }
}
