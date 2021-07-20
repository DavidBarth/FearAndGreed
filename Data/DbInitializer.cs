namespace FearAndGreed.Data
{
    public static class DbInitializer
    {
        public static bool Initialize(FearAndGreedContext context)
        {
            return context.Database.EnsureCreated();
        }
    }
}
