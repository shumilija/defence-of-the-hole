using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.PlayerShip
{
    /// <summary>
    /// Скрипт для прослушивания взаимодействий мышью с кораблем игрока.
    /// </summary>
    public class MouseListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _mouseDown;

        [SerializeField]
        private UnityEvent _mouseUp;

        private void OnMouseDown()
        {
            _mouseDown?.Invoke();
        }

        private void OnMouseUp()
        {
            _mouseUp?.Invoke();
        }
    }
}
