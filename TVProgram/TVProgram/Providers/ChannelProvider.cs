using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    class ChannelProvider : CrudProviderBase<Models.TVChannel, int>
    {
        public override void Add(TVChannel entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int pk)
        {
            throw new NotImplementedException();
        }

        public override TVChannel Get(int pk)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TVChannel> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(int pk, TVChannel entity)
        {
            throw new NotImplementedException();
        }
    }
}
