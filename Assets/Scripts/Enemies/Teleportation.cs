using UnityEngine;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Скрипт, телепортирующий врага.
    /// </summary>
    public class Teleportation : MonoBehaviour
    {
        private static readonly int[] _Directions = new int[] { -1, 1 };

        [SerializeField]
        [Range(0, 180)]
        private int _minOffsetOfAngleInDegrees;

        [SerializeField]
        [Range(0, 180)]
        private int _maxOffsetOfAngleInDegrees;

        /// <summary>
        /// Телепортировать врага.
        /// <para>Радиальная координата врага остается прежней. Угловая координата изменяется на случайное значение.</para>
        /// </summary>
        public void Teleport()
        {
            var offsetDirection = _Directions[Random.Range(0, _Directions.Length)];
            var offsetOfAngleInDegrees = offsetDirection * Random.Range(_minOffsetOfAngleInDegrees, _maxOffsetOfAngleInDegrees);
            
            var currentAngleInDegrees = Mathf.Atan2(transform.position.y, transform.position.x) * Mathf.Rad2Deg;

            var newAngleInDegrees = currentAngleInDegrees + offsetOfAngleInDegrees;

            var newPosition = new Vector2
            {
                x = transform.position.magnitude * Mathf.Cos(newAngleInDegrees * Mathf.Deg2Rad),
                y = transform.position.magnitude * Mathf.Sin(newAngleInDegrees * Mathf.Deg2Rad),
            };

            var newRotation = Quaternion.Euler(0, 0, newAngleInDegrees);

            transform.SetPositionAndRotation(newPosition, newRotation);
        }
    }
}
