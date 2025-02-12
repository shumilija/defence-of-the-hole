using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    public class ExtraShips : MonoBehaviour, IBonus
    {
        [SerializeField]
        private GameObject[] _additionalShips;

        public void Activate()
        {
            foreach (var ship in _additionalShips)
            {
                ship.SetActive(true);
            }
        }

        public void Disactivate()
        {
            foreach (var ship in _additionalShips)
            {
                ship.SetActive(false);
            }
        }
    }
}
