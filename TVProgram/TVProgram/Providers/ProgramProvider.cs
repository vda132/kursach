﻿using System;
using System.Collections.Generic;
using TVProgram.Models;
using TVProgram.Providers.Abstract;

namespace TVProgram.Providers
{
    class ProgramProvider : CrudProviderBase<Models.TVProgram, TVProgramPK>
    {
        public ProgramProvider() 
        {         
        }

        public override void Add(Models.TVProgram entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(TVProgramPK pk)
        {
            throw new NotImplementedException();
        }

        public override Models.TVProgram Get(TVProgramPK pk)
        {
            throw new NotImplementedException();
        }

        public override IReadOnlyCollection<Models.TVProgram> GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update(TVProgramPK pk, Models.TVProgram entity)
        {
            throw new NotImplementedException();
        }
    }
}
