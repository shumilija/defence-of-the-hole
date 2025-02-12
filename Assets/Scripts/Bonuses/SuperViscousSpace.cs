using DefenceOfTheHole.Enemies;
using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    public class SuperViscousSpace : MonoBehaviour, IBonus
    {
        [SerializeField]
        private float _startEnemyTimeModifier;

        [SerializeField]
        private float _durationInSeconds;

        private bool _isActive;

        private float Acceleration => _startEnemyTimeModifier / _durationInSeconds;

        public void Activate()
        {
            EnemyTime.Modifier = _startEnemyTimeModifier;
            _isActive = true;
        }

        public void Disactivate()
        {
            EnemyTime.Modifier = 1;
            _isActive = false;
        }

        private void FixedUpdate()
        {
            if (_isActive)
            {
                EnemyTime.Modifier -= Acceleration * Time.fixedDeltaTime;
            }
        }
    }
}
