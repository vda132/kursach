using TVProgram.Models;
using TVProgram.Providers.Abstract;

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
            ChannelProvider = new ChannelProvider();
            GenreProvider = new GenreProvider();
            ShowProvider = new ShowProvider();
            ProgramProvider = new ProgramProvider();
            UserProvider = new UserProvider();
        }
        #endregion

        // Providers
        public CrudProviderBase<Models.TVChannel, int> ChannelProvider { get; init; }
        public CrudProviderBase<Models.TVGenre, int> GenreProvider { get; init; }
        public CrudProviderBase<Models.TVShow, int> ShowProvider { get; init; }
        public CrudProviderBase<Models.TVProgram, TVProgramPK> ProgramProvider { get; init; }
        public UserProvider UserProvider { get; init; }
    }
}
