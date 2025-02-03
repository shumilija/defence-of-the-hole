using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.Common
{
    /// <summary>
    /// Скрипт таймера.
    /// </summary>
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private float _duration;

        [SerializeField]
        private UnityEvent _timeUp;

        private float _timeFromLastActivation;

        private void Update()
        {
            if (_timeFromLastActivation >= _duration)
            {
                _timeFromLastActivation = 0;

                enabled = false;

                _timeUp?.Invoke();
            }
            else
            {
                _timeFromLastActivation += Time.deltaTime;
            }
        }
    }
}
