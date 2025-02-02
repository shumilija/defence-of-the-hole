using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий врага со снарядом.
    /// </summary>
    public class MissileInteraction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _interacted;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Missile"))
            {
                _interacted?.Invoke();
            }
        }
    }
}
