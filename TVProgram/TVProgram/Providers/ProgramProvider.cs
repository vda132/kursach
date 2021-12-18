using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    class ProgramProvider : CrudProviderBase<TVProgramPK, Models.TVProgram>
    {
        public override void Add(TVProgramPK entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Models.TVProgram pk)
        {
            throw new NotImplementedException();
        }

        public override TVProgramPK Get(Models.TVProgram pk)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<TVProgramPK> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(Models.TVProgram pk, TVProgramPK entity)
        {
            throw new NotImplementedException();
        }
    }
}
