using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    public class CannonSwitch : MonoBehaviour, IBonus
    {
        [SerializeField]
        private GameObject[] _cannonsForDeactivation;

        [SerializeField]
        private GameObject[] _cannonsForActivation;

        public void Activate()
        {
            SetCannonsActive(_cannonsForDeactivation, false);
            SetCannonsActive(_cannonsForActivation, true);
        }

        public void Disactivate()
        {
            SetCannonsActive(_cannonsForDeactivation, true);
            SetCannonsActive(_cannonsForActivation, false);
        }

        private void SetCannonsActive(GameObject[] cannons, bool value)
        {
            foreach (var cannon in cannons)
            {
                cannon.SetActive(value);
            }
        }
    }
}

