using UnityEngine;

namespace DefenceOfTheHole.Common
{
    /// <summary>
    /// Скрипт для поворота объекта на случайный угол вокруг оси Z.
    /// </summary>
    public class RandomRotator2D : MonoBehaviour
    {
        /// <summary>
        /// Повернуть объект на случайный угол вокруг оси Z.
        /// </summary>
        public void Rotate()
        {
            var newAngleInDegrees = Random.Range(0, 360);

            transform.rotation = Quaternion.Euler(0, 0, newAngleInDegrees);
        }
    }
}
