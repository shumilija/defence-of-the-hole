using DefenceOfTheHole.Common;
using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Скрипт бонуса "Беглый огонь".
    /// <para>Повышает скорость стрельбы игрока в <see cref="_modifier"/> раз.</para>
    /// </summary>
    public class RapidFire : MonoBehaviour, IBonus
    {
        [SerializeField]
        private float _modifier;

        [SerializeField]
        private Instantiator _shooter;

        public void Activate()
        {
            _shooter.InstancePerSecond *= _modifier;
        }

        public void Disactivate()
        {
            _shooter.InstancePerSecond /= _modifier;
        }
    }
}
