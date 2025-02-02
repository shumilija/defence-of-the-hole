using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий врага с игровым полем.
    /// </summary>
    public class GameBoardInteraction : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _interacted;

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("GameBoard"))
            {
                _interacted?.Invoke();
            }
        }
    }
}
