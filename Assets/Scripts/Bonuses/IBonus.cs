namespace DefenceOfTheHole.Bonuses
{
    /// <summary>
    /// Интерфейс бонуса, который выдается игроку.
    /// </summary>
    public interface IBonus
    {
        /// <summary>
        /// Активировать бонус.
        /// </summary>
        void Activate();

        /// <summary>
        /// Дезактивровать бонус.
        /// </summary>
        void Disactivate();
    }
}
