using DefenceOfTheHole.Enemies;
using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Скрипт бонуса "Вязкая среда".
    /// <para>Понижает скорость движения врагов в <see cref="_modifier"/> раз.</para>
    /// </summary>
    public class ViscousSpace : MonoBehaviour, IBonus
    {
        [SerializeField]
        private float _modifier;

        public void Activate()
        {
            EnemyTime.Modifier /= _modifier;
        }

        public void Disactivate()
        {
            EnemyTime.Modifier *= _modifier;
        }
    }
}
