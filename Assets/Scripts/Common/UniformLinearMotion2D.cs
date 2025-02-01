using UnityEngine;

namespace DefenceOfTheHole.Common
{
    /// <summary>
    /// Скрипт, моделирующий равномерное прямолинейное движение на плоскости.
    /// </summary>
    public class UniformLinearMotion2D : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        private void FixedUpdate()
        {
            transform.position += _speed * Time.fixedDeltaTime * transform.right;
        }
    }
}
