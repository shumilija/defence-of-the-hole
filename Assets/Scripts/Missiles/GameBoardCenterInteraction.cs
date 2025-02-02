using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Bullets
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий снаряда с центром игрового поля.
    /// </summary>
    public class GameBoardCenterInteraction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _interacted;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("GameBoardCenter"))
            {
                _interacted?.Invoke();
            }
        }
    }
}
