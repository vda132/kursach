namespace TVProgram.Providers.Factories
{
    class ProviderFactory
    {
        // Use pattern Singleton
        #region Singleton
        private static ProviderFactory instance = null;
        public static ProviderFactory Instance { get => instance == null ? (instance = new ProviderFactory()) : instance; }
        private ProviderFactory()
        {
            ChannelProvider = new();
            GenreProvider = new();
            ShowProvider = new();
            ProgramProvider = new();
            UserProvider = new();
        }
        #endregion

        // Providers
        public ChannelProvider ChannelProvider { get; init; }
        public GenreProvider GenreProvider { get; init; }
        public ShowProvider ShowProvider { get; init; }
        public ProgramProvider ProgramProvider { get; init; }
        public UserProvider UserProvider { get; init; }
    }
}
