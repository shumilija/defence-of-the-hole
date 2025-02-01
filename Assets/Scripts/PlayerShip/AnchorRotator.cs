using UnityEngine;

namespace DefenceOfTheHole.PlayerShip
{
    /// <summary>
    /// Скрипт для управления вращением якоря корабля игрока.
    /// </summary>
    public class AnchorRotator : MonoBehaviour
    {
        private void Update()
        {
            var mousePositionInWorldUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var newAngleInDegrees = Mathf.Atan2(mousePositionInWorldUnits.y, mousePositionInWorldUnits.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(newAngleInDegrees, Vector3.forward);
        }
    }
}
