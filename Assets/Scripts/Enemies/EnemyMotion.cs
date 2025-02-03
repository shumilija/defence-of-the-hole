using UnityEngine;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Скрипт, моделирующий движение врагов.
    /// </summary>
    public class EnemyMotion : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        private void FixedUpdate()
        {
            transform.position += _speed * EnemyTime.FixedDeltaTime * transform.right;
        }
    }
}
