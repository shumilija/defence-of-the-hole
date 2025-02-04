using UnityEngine;

namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Скрипт для создания звезд на фоне.
    /// </summary>
    public class StarsCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _prefabs;

        [SerializeField]
        private int _count;

        [SerializeField]
        private float _minSize;

        [SerializeField]
        private float _maxSize;

        [SerializeField]
        private float _offset;

        private void Start()
        {
            var maxY = Camera.main.orthographicSize - _offset;
            var maxX = Camera.main.aspect * Camera.main.orthographicSize - _offset;

            for (int i = 0; i < _count; i++)
            {
                var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
                var size = Random.Range(_minSize, _maxSize);
                var position = new Vector2
                {
                    x = Random.Range(-maxX, maxX),
                    y = Random.Range(-maxY, maxY),
                };

                var createdObject = Instantiate(prefab, position, Quaternion.identity);
                createdObject.transform.localScale = size * Vector2.one;
            }
        }
    }
}
