using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    class GenreProvider : CrudProviderBase<Models.TVGenre, int>
    {
        public override void Add(TVGenre entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int pk)
        {
            throw new NotImplementedException();
        }

        public override TVGenre Get(int pk)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TVGenre> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(int pk, TVGenre entity)
        {
            throw new NotImplementedException();
        }
    }
}
