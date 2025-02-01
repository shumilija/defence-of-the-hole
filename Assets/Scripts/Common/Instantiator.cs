using UnityEngine;

namespace DefenceOfTheHole.Common
{
    /// <summary>
    /// Скрипт для периодического создания копии некоторого префаба.
    /// </summary>
    public class Instantiator : MonoBehaviour
    {
        [SerializeField]
        private float _instancePerSecond;

        [SerializeField]
        private GameObject _prefab;
        
        private float _timeFromLastInstantiation;

        private float DelayBetweenInstantiations => 1 / _instancePerSecond;

        private void Update()
        {
            if (_timeFromLastInstantiation >= DelayBetweenInstantiations)
            {
                _timeFromLastInstantiation = 0;

                Instantiate(_prefab, transform.position, transform.rotation);
            }
            else
            {
                _timeFromLastInstantiation += Time.deltaTime;
            }
        }
    }
}
