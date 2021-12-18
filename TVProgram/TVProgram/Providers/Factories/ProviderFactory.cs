using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers.Factories
{
    class ProviderFactory
    {
        private static ProviderFactory instance = null;

        public CrudProviderBase<Models.TVChannel, int> ChannelProvider { get; init; }
        public CrudProviderBase<Models.TVGenre, int> GenreProvider { get; init; }
        public CrudProviderBase<Models.TVShow, int> ShowProvider { get; init; }
        public CrudProviderBase<Models.TVProgram, TVProgramPK> ProgramProvider { get; init; }

        private ProviderFactory()
        {
            ChannelProvider = new ChannelProvider();
            GenreProvider = new GenreProvider();
            ShowProvider = new ShowProvider();
            ProgramProvider = new ProgramProvider();
        }

        public static ProviderFactory GetInstance()
        {
            return instance == null ? new ProviderFactory() : instance;
        }
    }
}
