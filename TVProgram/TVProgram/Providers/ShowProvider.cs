using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    class ShowProvider : CrudProviderBase<Models.TVShow, int>
    {
        public override void Add(TVShow entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int pk)
        {
            throw new NotImplementedException();
        }

        public override TVShow Get(int pk)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TVShow> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(int pk, TVShow entity)
        {
            throw new NotImplementedException();
        }
    }
}
