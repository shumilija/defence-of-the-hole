using UnityEngine;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Скрипт, контролирующий здоровье врага.
    /// </summary>
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _health;

        /// <summary>
        /// Отнять у врага указанное кол-во единиц здоровья.
        /// </summary>
        /// <param name="value">Кол-во единиц здоровья, которое требуетя отнять у врага.</param>
        public void LowerHealth(int value)
        {
            _health -= value;

            if (_health <= 0)
            {
                Kill();
            }
        }

        /// <summary>
        /// Уничтожить врага.
        /// </summary>
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}
