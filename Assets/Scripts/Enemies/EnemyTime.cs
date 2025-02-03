using UnityEngine;

namespace DefenceOfTheHole.Enemies
{
    /// <summary>
    /// Время, используемое врагами для рассчета передвижения.
    /// </summary>
    public static class EnemyTime
    {
        /// <summary>
        /// Множитель времени.
        /// </summary>
        public static float Modifier { get; set; } = 1;

        /// <summary>
        /// <see cref="Time.deltaTime"/> с учетом <see cref="Modifier"/>.
        /// </summary>
        public static float DeltaTime => Modifier * Time.deltaTime;

        /// <summary>
        /// <see cref="Time.fixedDeltaTime"/> с учетом <see cref="Modifier"/>.
        /// </summary>
        public static float FixedDeltaTime => Modifier * Time.fixedDeltaTime;
    }
}
