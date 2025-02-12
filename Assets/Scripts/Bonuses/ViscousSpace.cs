using DefenceOfTheHole.Enemies;
using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    public class ViscousSpace : MonoBehaviour, IBonus
    {
        [SerializeField]
        private float _enemyTimeModifier;

        public void Activate()
        {
            EnemyTime.Modifier = _enemyTimeModifier;
        }

        public void Disactivate()
        {
            EnemyTime.Modifier = 1;
        }
    }
}
