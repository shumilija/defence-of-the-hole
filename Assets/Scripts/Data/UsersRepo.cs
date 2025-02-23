namespace DefenceOfTheHole.Data
{
    public static class UsersRepo
    {
        private static int currentUserId = 1;

        public static int CurrentUserId => currentUserId;
    }
}