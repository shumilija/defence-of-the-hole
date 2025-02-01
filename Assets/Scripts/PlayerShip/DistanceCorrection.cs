using UnityEngine;

namespace DefenceOfTheHole.PlayerShip
{
    /// <summary>
    /// Скрипт для корректировки расстояния, на котором находится корабль игрока, в соответвие с размерами игрового поля.
    /// </summary>
    public class DistanceCorrection : MonoBehaviour
    {
        public void CorrectByGameBoardSize(float gameBoardSize)
        {
            transform.position = gameBoardSize / 2 * Vector2.right;
        }
    }
}
