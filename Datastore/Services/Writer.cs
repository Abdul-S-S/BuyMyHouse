﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastore.Interfaces;

namespace Datastore.Services
{
    internal class Writer : IWriter
    {
        public string Read<T>(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
