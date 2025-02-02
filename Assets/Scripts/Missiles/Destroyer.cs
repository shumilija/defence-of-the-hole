using UnityEngine;

namespace DefenceOfTheHole.Bullets
{
    /// <summary>
    /// Скрипт для уничтожения снарядов.
    /// </summary>
    public class Destroyer : MonoBehaviour
    {
        /// <summary>
        /// Уничтожить снаряд.
        /// </summary>
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
