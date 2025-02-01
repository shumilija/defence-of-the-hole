using UnityEngine;
using UnityEngine.Events;

namespace DefenceOfTheHole.GameBoard
{
    /// <summary>
    /// Скрипт для настройки размеров игрового поля относительно экрана.
    /// </summary>
    public class SizingByScreen : MonoBehaviour
    {
        [SerializeField]
        [Range(0, 1)]
        private float _fractionOfScreenSize;

        [SerializeField]
        private UnityEvent<float> _resized;

        private void Update()
        {
            var diameter = CalcDiameter();

            if (diameter != transform.localScale.x)
            {
                Resize(diameter);
            }
        }

        private float CalcDiameter()
        {
            var screenHeightInWorldUnits = 2 * Camera.main.orthographicSize;
            var screenWidthInWorlsUnits = Camera.main.aspect * screenHeightInWorldUnits;

            var diameter = Mathf.Min(screenHeightInWorldUnits, screenWidthInWorlsUnits) * _fractionOfScreenSize;

            return diameter;
        }

        private void Resize(float newDiameter)
        {
            transform.localScale = newDiameter * Vector2.one;

            _resized?.Invoke(newDiameter);
        }
    }
}
