using UnityEngine;

namespace DefenceOfTheHole.Bullets
{
    /// <summary>
    /// Скрипт для уничтожения снарядов.
    /// </summary>
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("GameBoardCenter"))
            {
                Destroy(gameObject);
            }
        }
    }
}
