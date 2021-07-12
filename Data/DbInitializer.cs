namespace FearAndGreed.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FearAndGreedContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
